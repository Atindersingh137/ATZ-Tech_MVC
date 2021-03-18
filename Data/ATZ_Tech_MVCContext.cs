using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ATZ_Tech_MVC.Models;

namespace ATZ_Tech_MVC.Data
{
    public class ATZ_Tech_MVCContext : DbContext  // DB Context class
    {
        public ATZ_Tech_MVCContext (DbContextOptions<ATZ_Tech_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<ATZ_Tech_MVC.Models.User> User { get; set; }

        public DbSet<ATZ_Tech_MVC.Models.Product> Product { get; set; }

        public DbSet<ATZ_Tech_MVC.Models.Order> Order { get; set; }
    }
}
