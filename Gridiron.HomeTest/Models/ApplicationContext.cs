using System;
using Microsoft.EntityFrameworkCore;

namespace Gridiron.HomeTest.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Application> Applications { get; set; }
    }
}
