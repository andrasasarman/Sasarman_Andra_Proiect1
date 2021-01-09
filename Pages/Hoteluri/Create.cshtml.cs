using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sasarman_Andra_Proiect1.Data;
using Sasarman_Andra_Proiect1.Models;

namespace Sasarman_Andra_Proiect1.Pages.Hoteluri
{
    public class CreateModel : HotelCategoriesPageModel
    {
        private readonly Sasarman_Andra_Proiect1.Data.Sasarman_Andra_Proiect1Context _context;

        public CreateModel(Sasarman_Andra_Proiect1.Data.Sasarman_Andra_Proiect1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var hotel = new Hotel();
            hotel.HotelCategories = new List<HotelCategory>();
            PopulateAssignedCategoryData(_context, hotel);
            return Page();
        }

        [BindProperty]
        public Hotel Hotel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newHotel = new Hotel();
            if (selectedCategories != null)
            {
                newHotel.HotelCategories = new List<HotelCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new HotelCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newHotel.HotelCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Hotel>(
            newHotel,
            "Hotel",
            i => i.HotelName,
            i=>i.Facilități,
            i =>i.HotelCategories))
            {
                _context.Hotel.Add(newHotel);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newHotel);
            return Page();
        }
    }
}
