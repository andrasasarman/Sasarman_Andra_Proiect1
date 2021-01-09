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
    public class DetailsModel : PageModel
    {
        private readonly Sasarman_Andra_Proiect1.Data.Sasarman_Andra_Proiect1Context _context;

        public DetailsModel(Sasarman_Andra_Proiect1.Data.Sasarman_Andra_Proiect1Context context)
        {
            _context = context;
        }

        public Hotel Hotel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hotel = await _context.Hotel.FirstOrDefaultAsync(m => m.ID == id);

            if (Hotel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
