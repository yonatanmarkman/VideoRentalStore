using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Vidly.Dtos
{
    public class NewRentalDto
    {
        public int customerId { get; set; }
        public List<int> movieIds { get; set; }
    }
}