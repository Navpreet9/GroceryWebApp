using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroceryWebApp.BusinessLayer;
using GroceryWebApp.Data;

namespace GroceryWebApp.Pages.Groceries
{
    public class EditModel : PageModel
    {
        private readonly GroceryWebApp.Data.GroceryDBContext _context;

        public EditModel(GroceryWebApp.Data.GroceryDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Grocery Grocery { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grocery = await _context.Groceries
                .Include(g => g.Brand)
                .Include(g => g.Category).FirstOrDefaultAsync(m => m.GroceryID == id);

            if (Grocery == null)
            {
                return NotFound();
            }
           ViewData["BrandID"] = new SelectList(_context.Brands, "BrandID", "BrandName");
           ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Grocery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryExists(Grocery.GroceryID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GroceryExists(int id)
        {
            return _context.Groceries.Any(e => e.GroceryID == id);
        }
    }
}
