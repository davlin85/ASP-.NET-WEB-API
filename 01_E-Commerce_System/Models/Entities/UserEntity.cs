using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_E_Commerce_System.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]

    public class UserEntity
    {

        public UserEntity(string firstName, string lastName, string email, string password)
        {
            FirstName=firstName;
            LastName=lastName;
            Email=email;
            Password=password;
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
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }


        [Required]
        public int AdressesId { get; set; }
        public virtual AdressEntity Adresses { get; set; }

    }
}
