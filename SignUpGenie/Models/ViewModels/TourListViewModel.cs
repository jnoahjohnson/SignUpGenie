using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignUpGenie.Models.ViewModels
{
    public class TourListViewModel
    {
        public IEnumerable<Tour> Tours { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
