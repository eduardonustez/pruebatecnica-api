using Microsoft.EntityFrameworkCore;
using System;
using test.Domain;

namespace test.Data
{
    public class testContext:DbContext
    {
        public testContext(DbContextOptions<testContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(testContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
