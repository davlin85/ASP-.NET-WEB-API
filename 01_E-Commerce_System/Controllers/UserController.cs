using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _01_E_Commerce_System.Data;
using _01_E_Commerce_System.Models.Entities;
using _01_E_Commerce_System.Models;
using _01_E_Commerce_System.Models.Output;
using _01_E_Commerce_System.Models.Forms;
using _01_E_Commerce_System.Models.Models;

namespace _01_E_Commerce_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SqlContext _context;

        public UserController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGetModel>>> GetUsers()
        {
           var users = new List<UserGetModel>();
            foreach (var user in await _context.Users.Include(x => x.Adresses).ToListAsync())
                users.Add(new UserGetModel(
                    user.Id, 
                    user.FirstName, 
                    user.LastName, 
                    user.Email, 
                    new AdressModel(
                        user.Adresses.AdressLine, 
                        user.Adresses.PostalCode, 
                        user.Adresses.City, 
                        user.Adresses.Country)));

            return users;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGetModel>> GetUser(int id)
        {
            var userEntity = await _context.Users.Include(x => x.Adresses).FirstOrDefaultAsync(x => x.Id == id);

            if (userEntity == null)
            {
                return NotFound();
            }

            return new UserGetModel(
                userEntity.Id, 
                userEntity.FirstName, 
                userEntity.LastName, 
                userEntity.Email, 
                new AdressModel(
                    userEntity.Adresses.AdressLine, 
                    userEntity.Adresses.PostalCode, 
                    userEntity.Adresses.City, 
                    userEntity.Adresses.Country)
                );
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserPutModel>>UpdateUser(int id, UserPutModel model)
        {
            {
                if (id != model.Id)
                {
                    return BadRequest();
                }

                var userEntity = await _context.Users.FindAsync(model.Id);
                userEntity.FirstName = model.FirstName;
                userEntity.LastName = model.LastName;
                userEntity.Email = model.Email;
                new AdressEntity(
                    model.AdressLine, 
                    model.PostalCode, 
                    model.City, 
                    model.Country);

                _context.Entry(userEntity).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserEntityExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<UserPostModel>> PostUser(UserInput model)
        {
            if(await _context.Users.AnyAsync(x => x.Email == model.Email))
                return BadRequest();

            var userEntity = new UserEntity(
                model.FirstName, 
                model.LastName, 
                model.Email, 
                model.Password);

            var adresses = await _context.Adresses.FirstOrDefaultAsync(x => x.AdressLine == model.AdressLine && x.PostalCode == model.PostalCode);
            if (adresses != null)
                userEntity.AdressesId = adresses.Id;
            else
                userEntity.Adresses = new AdressEntity(
                    model.AdressLine, 
                    model.PostalCode, 
                    model.City, 
                    model.Country);

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new {id = userEntity.Id}, 
                new UserPostModel(
                userEntity.Id, 
                userEntity.FirstName, 
                userEntity.LastName, 
                userEntity.Email, 
                userEntity.Password, 
                new AdressModel(
                    userEntity.Adresses.AdressLine, 
                    userEntity.Adresses.PostalCode, 
                    userEntity.Adresses.City, 
                    userEntity.Adresses.Country)
                ));
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userEntity = await _context.Users.FindAsync(id);
            if (userEntity == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserEntityExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
