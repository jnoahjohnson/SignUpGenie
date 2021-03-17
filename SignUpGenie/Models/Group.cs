﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignUpGenie.Models
{
    public class Group
    {
        // Group Properties
        [Key]
        public int GroupId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Size { get; set; }

        [Required]
        public string Email { get; set; }

        public int? Phone { get; set; }
    }
}
