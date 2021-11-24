using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class NewRentalDto
    {
        public int customerId { get; set; }
        public List<int> moviesIds { get; set; }
    }
}