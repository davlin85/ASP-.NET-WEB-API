using _01_E_Commerce_System.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01_E_Commerce_System.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        public virtual DbSet<AdressEntity> Adresses { get; set; }
        public virtual DbSet<CategoryEntity> Categories { get; set; }
        public virtual DbSet<OrderEntity> Orders { get; set; }
        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }
    }
}
