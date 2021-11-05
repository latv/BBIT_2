using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBIT_2.Models
{
    public class Homes
    {
        public int Id { get; set; }
        public string Name { get; set; } // because street number could be with letters, like 1B
        public string Surname { get; set; }
        public string Persona_code { get; set; }
        public string Birthday { get; set; } // because sqlite doesnt support date type
        public string Phone_number { get; set; }
        public string Email { get; set; }
        public int? ApartmentId { get; set; }
        //public List<Apartments> Apartments { get; set; }

    }

}
