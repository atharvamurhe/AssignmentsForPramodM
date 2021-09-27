using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFirstCoreAppUsingMVC.Models;

namespace MyFirstCoreAppUsingMVC.Data
{
    public class MyFirstCoreAppUsingMVCContext : DbContext
    {
        public MyFirstCoreAppUsingMVCContext (DbContextOptions<MyFirstCoreAppUsingMVCContext> options)
            : base(options)
        {
        }

        public DbSet<MyFirstCoreAppUsingMVC.Models.Test> Test { get; set; }

        public DbSet<MyFirstCoreAppUsingMVC.Models.EnumTest> EnumTest { get; set; }
    }
}
