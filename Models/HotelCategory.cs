using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sasarman_Andra_Proiect1.Models
{
    public class HotelCategory
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public Hotel Hotel { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
