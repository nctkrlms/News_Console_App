using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.AppDbContext
{
    internal class DataContext : DbContext
    {
        public DataContext() : base("dbConnection") { }
        public DbSet<New> New { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Comment> Comment { get; set; }

    }
}
