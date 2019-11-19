using System;
using Lab_20_Coffee_Shop_Part_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_20_Coffee_Shop_Part_3.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext()
        {
        }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
