using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sasarman_Andra_Proiect1.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string HotelName { get; set; }
        public string Facilități { get; set; }
        public ICollection<Vacanță> Vacanțe { get; set; }//navigation property
        public ICollection<HotelCategory> HotelCategories { get; set; }
    }
}
