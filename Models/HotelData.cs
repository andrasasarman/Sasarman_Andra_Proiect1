using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sasarman_Andra_Proiect1.Models
{
    public class HotelData
    {
        public IEnumerable<Hotel> Hoteluri { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<HotelCategory> HotelCategories { get; set; }
    }
}
