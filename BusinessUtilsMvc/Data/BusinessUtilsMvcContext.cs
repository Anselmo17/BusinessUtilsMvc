using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessUtilsMvc.Models
{
    public class BusinessUtilsMvcContext : DbContext
    {
        public BusinessUtilsMvcContext (DbContextOptions<BusinessUtilsMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public  DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
