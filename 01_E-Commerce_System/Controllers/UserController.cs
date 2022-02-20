using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _01_E_Commerce_System.Data;
using _01_E_Commerce_System.Models;
using _01_E_Commerce_System.Models.Models;
using _01_E_Commerce_System.Models.Models.User;
using _01_E_Commerce_System.Models.Models.Adress;
using _01_E_Commerce_System.Models.Input;
using _01_E_Commerce_System.Filters;
using Microsoft.AspNetCore.Authorization;
using _01_E_Commerce_System.Entities;

namespace _01_E_Commerce_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UserController : ControllerBase
    {
        private readonly SqlContext _context;

        public UserController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        [UseAdminApiKey]
        public async Task<ActionResult<IEnumerable<UserGetModel>>> GetUsers()
        {
            var users = new List<UserGetModel>();
            foreach (var user in await _context.Users
                .Include(x => x.Adresses)
                .ToListAsync())

                users.Add(new UserGetModel(
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                        new AdressModel(
                            user.Adresses.AdressLine, 
                            user.Adresses.PostalCode,
                            user.Adresses.City)));

            return users;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        [UseAdminApiKey]
        public async Task<ActionResult<UserGetModel>> GetUser(int id)
        {
            var userEntity = await _context.Users
                .Include(x => x.Adresses)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (userEntity == null)
            {
                return NotFound("User Id doesn't exist! Try again!");
            }

            return new UserGetModel(
                userEntity.Id,
                userEntity.FirstName,
                userEntity.LastName,
                userEntity.Email,
                    new AdressModel(
                        userEntity.Adresses.AdressLine,
                        userEntity.Adresses.PostalCode,
                        userEntity.Adresses.City));
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        [UseAdminApiKey]
        public async Task<ActionResult<UserPutModel>> UpdateUser(int id, UserPutModel model)
        {
            {
                if (id != model.Id)
                {
                    return BadRequest("User Id doesn't exist! Try again!");
                }

                var userEntity = await _context.Users
                    .FindAsync(model.Id);

                userEntity.FirstName = model.FirstName;
                userEntity.LastName = model.LastName;
                userEntity.Email = model.Email;

                var adresses = await _context.Adresses
                    .FirstOrDefaultAsync(x => x.AdressLine == model.AdressLine && x.PostalCode == model.PostalCode);

                if (adresses != null)
                    userEntity.AdressesId = adresses.Id;
                else
                    userEntity.Adresses = new AdressEntity(
                        model.AdressLine,
                        model.PostalCode,
                        model.City);

                _context.Entry(userEntity).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserEntityExists(id))
                    {
                        return NotFound("Something went wrong! Try again!");
                    }
                    else
                    {
                        throw;
                    }
                }

                return Ok("Your User is updated!");
            }
        }

        // POST: api/User
        [HttpPost]
        [UseAdminApiKey]
        public async Task<ActionResult<UserPostModel>> PostUser(UserInput model)
        {
            if (await _context.Users
                .AnyAsync(x => x.Email == model.Email))

                return BadRequest("A User with the same Email already exist! Try again!");

            var userEntity = new UserEntity(
                model.FirstName,
                model.LastName,
                model.Email);

            userEntity.CreatePassword(model.Password);

            var adresses = await _context.Adresses
                .FirstOrDefaultAsync(x => x.AdressLine == model.AdressLine && x.PostalCode == model.PostalCode);

            if (adresses != null)
                userEntity.AdressesId = adresses.Id;
            else
                userEntity.Adresses = new AdressEntity(
                    model.AdressLine,
                    model.PostalCode,
                    model.City);

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = userEntity.Id },
                new UserPostModel(
                userEntity.Id,
                userEntity.FirstName,
                userEntity.LastName,
                userEntity.Email,
                    new AdressModel(
                        userEntity.Adresses.AdressLine,
                        userEntity.Adresses.PostalCode,
                        userEntity.Adresses.City)));
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        [UseAdminApiKey]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userEntity = await _context.Users
                .FindAsync(id);

            if (userEntity == null)
            {
                return NotFound("User Id doesn't exist! Try again!");
            }

            _context.Users
                .Remove(userEntity);

            await _context.SaveChangesAsync();

            return Ok("Your User is deleted!");
        }

        private bool UserEntityExists(int id)
        {
            return _context.Users
                .Any(e => e.Id == id);
        }
    }
}