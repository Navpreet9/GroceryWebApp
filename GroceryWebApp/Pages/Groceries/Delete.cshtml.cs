using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroceryWebApp.BusinessLayer;
using GroceryWebApp.Data;

namespace GroceryWebApp.Pages.Groceries
{
    public class DeleteModel : PageModel
    {
        private readonly GroceryWebApp.Data.GroceryDBContext _context;

        public DeleteModel(GroceryWebApp.Data.GroceryDBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grocery = await _context.Groceries.FindAsync(id);

            if (Grocery != null)
            {
                _context.Groceries.Remove(Grocery);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
