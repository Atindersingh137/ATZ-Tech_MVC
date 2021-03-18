using ATZ_Tech_MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATZ_Tech_MVC.Data
{
    public class ATZtechDbContext : IdentityDbContext  // db context 
    {// Here we add in all the tables we are using.
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }

        // We need 2 constructors, one is empty, and the other injects in DbContextOptions
        public ATZtechDbContext(DbContextOptions<ATZtechDbContext> options)
        : base(options)
        {
        }
        public ATZtechDbContext()
        {
        }
    }
}
