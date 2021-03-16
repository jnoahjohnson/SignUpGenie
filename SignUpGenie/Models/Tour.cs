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

        public Group? Group { get; set; }

    }
}
#nullable disable