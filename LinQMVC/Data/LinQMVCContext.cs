using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LinQMVC.Models;

namespace LinQMVC.Data
{
    public class LinQMVCContext : DbContext
    {
        public LinQMVCContext (DbContextOptions<LinQMVCContext> options)
            : base(options)
        {
        }

        public DbSet<LinQMVC.Models.Student> Student { get; set; }
    }
}
