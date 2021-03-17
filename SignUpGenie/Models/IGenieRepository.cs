﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignUpGenie.Models
{
    public interface IGenieRepository
    {
        // Requirements for this interface
        IQueryable<Group> Groups { get; }
        IQueryable<Tour> Tours { get; }

    }
}
