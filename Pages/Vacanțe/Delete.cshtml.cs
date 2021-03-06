﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sasarman_Andra_Proiect1.Data;
using Sasarman_Andra_Proiect1.Models;

namespace Sasarman_Andra_Proiect1.Pages.Vacanțe
{
    public class DeleteModel : PageModel
    {
        private readonly Sasarman_Andra_Proiect1.Data.Sasarman_Andra_Proiect1Context _context;

        public DeleteModel(Sasarman_Andra_Proiect1.Data.Sasarman_Andra_Proiect1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Vacanță Vacanță { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vacanță = await _context.Vacanță.FirstOrDefaultAsync(m => m.ID == id);

            if (Vacanță == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vacanță = await _context.Vacanță.FindAsync(id);

            if (Vacanță != null)
            {
                _context.Vacanță.Remove(Vacanță);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
