using _01_E_Commerce_System.Data;
using _01_E_Commerce_System.Entities;
using _01_E_Commerce_System.Models.Input;
using _01_E_Commerce_System.Models.Models.Admin;
using _01_E_Commerce_System.Models.Models.SignInUp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _01_E_Commerce_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SqlContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationController(SqlContext context, IConfiguration configuration)
        {
            _context=context;
            _configuration=configuration;
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn(SignInModel model)
        {
            if(string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                return BadRequest();

            var admin = await _context.Admins
                .FirstOrDefaultAsync(x => x.Email == model.Email);
            if(admin == null)
                return BadRequest();

            if (!admin.ComparePassword(model.Password))
                return BadRequest();

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", admin.Id.ToString()),
                    new Claim(ClaimTypes.Email, admin.Email),
                    new Claim(ClaimTypes.Name, admin.Id.ToString()),
                    new Claim("code", _configuration.GetValue<string>("AdminApiKey"))
                }),

                Expires = DateTime.UtcNow.AddMinutes(60),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("SecretKey"))),
                    SecurityAlgorithms.HmacSha512Signature)

            };

            var acesstoken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            return Ok(acesstoken);

        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<AdminModel>> SignUp(AdminInput model)
        {
            if (await _context.Admins
                .AnyAsync(x => x.Email == model.Email))

                return BadRequest("A Admin with the same Email already exist! Try again!");

            var adminEntity = new AdminEntity(
                model.FirstName,
                model.LastName,
                model.Email);

            adminEntity.CreatePassword(model.Password);

            _context.Admins.Add(adminEntity);
            await _context.SaveChangesAsync();


            return Ok("A new Admin have been created!");
        }
    }

}
