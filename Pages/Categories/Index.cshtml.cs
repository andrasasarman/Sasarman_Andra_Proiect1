using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sasarman_Andra_Proiect1.Data;
using Sasarman_Andra_Proiect1.Models;

namespace Sasarman_Andra_Proiect1.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Sasarman_Andra_Proiect1.Data.Sasarman_Andra_Proiect1Context _context;

        public IndexModel(Sasarman_Andra_Proiect1.Data.Sasarman_Andra_Proiect1Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
