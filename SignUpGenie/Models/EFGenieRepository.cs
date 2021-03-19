using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignUpGenie.Models
{
    public class EFGenieRepository : IGenieRepository
    {
        // Create a context from GenieDbContext
        private GenieDbContext _context;

        // Constructor
        public EFGenieRepository (GenieDbContext context)
        {
            _context = context;
        }

        // Requirements from the interface - basically the properties we need to have
        public IQueryable<Tour> Tours => _context.Tours;

    }
}
