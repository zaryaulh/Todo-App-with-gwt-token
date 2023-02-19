using Integrify.Domain.Todo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Integrify.Data.Todo
{
    public class TodoContext : IdentityDbContext<IdentityUser>

    {
        protected readonly IConfiguration Configuration;
        public TodoContext() : base()
        {

        }
        public TodoContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql("Server=localhost;Port=5432;Database=TodoApp;User Id=postgres;Password=15113137;");
        }
        public DbSet<TodoL> Todos { get; set; }
        public DbSet<User> Users { get; set; }
    }
    
}
