using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace _01_E_Commerce_System.Entities
{
    [Index(nameof(Email), IsUnique = true)]

    public class UserEntity
    {

        public UserEntity(string firstName, string lastName, string email)
        {
            FirstName=firstName;
            LastName=lastName;
            Email=email;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; private set; }

        [Required]
        public byte[] Security { get; private set; }

        [Required]
        public int AdressesId { get; set; }
        public virtual AdressEntity Adresses { get; set; }


        public void CreatePassword(string password)
        {
            using var hmac = new HMACSHA512();
            Security = hmac.Key;
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool ComparePassword(string password)
        {
            using (var hmac = new HMACSHA512(Security))
            {
                var _hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < _hash.Length; i++)
                {
                        if (_hash[i] != PasswordHash[i])
                            return false;
                }
            }

            return true;
        }

    }
}
