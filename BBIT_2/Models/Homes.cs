using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBIT_2.Models
{
    public class Homes
    {
        public int Id { get; set; }
        public string StreetNumber { get; set; } // because street number could be with letters, like 1B
        public int Story{ get; set; }
        public int Residents_count{ get; set; }
        public int Area{ get; set; } // because sqlite doesnt support date type
        public int Living_area{ get; set; }



    }

}
