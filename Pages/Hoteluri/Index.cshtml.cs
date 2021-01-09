using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sasarman_Andra_Proiect1.Data;
using Sasarman_Andra_Proiect1.Models;

namespace Sasarman_Andra_Proiect1.Pages.Hoteluri
{
    public class IndexModel : PageModel
    {
        private readonly Sasarman_Andra_Proiect1.Data.Sasarman_Andra_Proiect1Context _context;

        public IndexModel(Sasarman_Andra_Proiect1.Data.Sasarman_Andra_Proiect1Context context)
        {
            _context = context;
        }

        public IList<Hotel> Hotel { get;set; }
        public HotelData HotelD { get; set; }
        public int HotelID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            HotelD = new HotelData();
            HotelD.Hoteluri = await _context.Hotel
                .Include(h=>h.HotelCategories)
                .ThenInclude(h=>h.Category)
                .AsNoTracking()
                .ToListAsync();

            if (id != null)
            {
                HotelID = id.Value;
                Hotel book = HotelD.Hoteluri
                .Where(i => i.ID == id.Value).Single();
                HotelD.Categories = book.HotelCategories.Select(s => s.Category);
            }

        }
    }
}
