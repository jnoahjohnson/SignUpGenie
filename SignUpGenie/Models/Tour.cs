#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignUpGenie.Models
{
    public class Tour
    {
        // Tour properties
        [Key]
        public int TourId { get; set; }
        
        [Required]
        public DateTime DateTime { get; set; }

<<<<<<< HEAD
	
	// Group information
=======
>>>>>>> bb523be0cff99b9cd97ed9c489dcade56d2dc831
        public string? Name { get; set; }
        
        public int? Size { get; set; }
       
        public string? Email { get; set; }

        public string? Phone { get; set; }

    }
}
#nullable disable
