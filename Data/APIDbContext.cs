using CRUD_WithAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_WithAPI.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
