using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBIT_2.Models
{
    [Table("Apartments")]
    public class Apartments
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Number { get; set; } 
        public int Story { get; set; }
        public int NumberOfRooms { get; set; }
        public int Area { get; set; }
        public int LivingSpace { get; set; }
        

 

    }
}
