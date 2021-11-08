using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBIT_2.Models
{
    public class Resident
    {
        public int Id { get; set; }
        public string StreetNumber { get; set; } // because street number could be with letters, like 1B
        public string City { get; set; }
        public string Country { get; set; }
        public string Post_index { get; set; }
        public int ApartmentId { get; set; }

    }

}
