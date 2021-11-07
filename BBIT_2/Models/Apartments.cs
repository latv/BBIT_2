using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
  



namespace BBIT_2.Models
{
    
    public class Apartments
    {

        public int Id { get; set; }
        public int Number { get; set; } 
        public int Story { get; set; }
        public int NumberOfRooms { get; set; }
        public int Area { get; set; }
        public int LivingSpace { get; set; }

        public int? HomeId { get; set; }
        public ICollection<Homes> Homes{ get; set; }




    }
}
