using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DependencyInjectionTest.Models;

namespace DependencyInjectionTest.Data
{
    public class DependencyInjectionTestContext : DbContext
    {
        public DependencyInjectionTestContext (DbContextOptions<DependencyInjectionTestContext> options)
            : base(options)
        {
        }

        public DbSet<DependencyInjectionTest.Models.Dummy> Dummy { get; set; } = default!;
    }
}
