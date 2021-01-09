using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sasarman_Andra_Proiect1.Data;
using Sasarman_Andra_Proiect1.Models;

namespace Sasarman_Andra_Proiect1.Pages.Hoteluri
{
    public class EditModel : HotelCategoriesPageModel
    {
        private readonly Sasarman_Andra_Proiect1.Data.Sasarman_Andra_Proiect1Context _context;

        public EditModel(Sasarman_Andra_Proiect1.Data.Sasarman_Andra_Proiect1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Hotel Hotel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hotel = await _context.Hotel
                .Include(h=>h.HotelCategories).ThenInclude(h=>h.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Hotel == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData 
            PopulateAssignedCategoryData(_context, Hotel);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var hotelToUpdate = await _context.Hotel
            .Include(i => i.HotelCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (hotelToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Hotel>(
            hotelToUpdate,
            "Hotel",
            i => i.HotelName,i=>i.Facilități,i=>i.HotelCategories))
            {
                UpdateVacanțăCategories(_context, selectedCategories, hotelToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateVacanțăCategories pentru a aplica informatiile din checkboxuri la entitatea Hoteluri care
            //este editata
            UpdateVacanțăCategories(_context, selectedCategories, hotelToUpdate);
            PopulateAssignedCategoryData(_context, hotelToUpdate);
            return Page();
        }
    }
}

  
