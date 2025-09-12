using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Crud_MVC.Models;

namespace Crud_MVC.Data
{
    public class Crud_MVCContext : DbContext
    {
        public Crud_MVCContext (DbContextOptions<Crud_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
