using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroceryWebApp.BusinessLayer;
using GroceryWebApp.Data;

namespace GroceryWebApp.Pages.Brands
{
    public class DeleteModel : PageModel
    {
        private readonly GroceryWebApp.Data.GroceryDBContext _context;

        public DeleteModel(GroceryWebApp.Data.GroceryDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Brand Brand { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Brand = await _context.Brands.FirstOrDefaultAsync(m => m.BrandID == id);

            if (Brand == null)
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

            Brand = await _context.Brands.FindAsync(id);

            if (Brand != null)
            {
                _context.Brands.Remove(Brand);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
