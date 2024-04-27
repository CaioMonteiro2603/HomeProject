using HomeProject.Controllers;
using HomeProject.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeProject.Data
{
    public class Context : DbContext
    {
        public DbSet<UserModel> User {  get; set; }

        public DbSet<VehicleModel> Vehicle { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
        }

        protected Context()
        {
        }
    }
}
