using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignUpGenie.Models
{
    // Creating the DbContext to be able to interface with the database
    public class GenieDbContext : DbContext
    {
        public GenieDbContext (DbContextOptions<GenieDbContext> options) : base (options)
        {

        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Tour> Tours { get; set; }

    }
}
