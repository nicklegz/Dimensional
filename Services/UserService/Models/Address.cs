using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Models
{
    public record Address
    {
        public int Id { get; set; }

        //foreign key from user table
        public Guid UserId { get; set; }
        public string Country { get; set; }

        //Province or State
        public string AdminArea { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StreetAddress { get; set; }

    }
}
