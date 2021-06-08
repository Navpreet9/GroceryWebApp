using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroceryWebApp.BusinessLayer;
using GroceryWebApp.Data;

namespace GroceryWebApp.Pages.Groceries
{
    public class CreateModel : PageModel
    {
        private readonly GroceryWebApp.Data.GroceryDBContext _context;

        public CreateModel(GroceryWebApp.Data.GroceryDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BrandID"] = new SelectList(_context.Brands, "BrandID", "BrandName");
        ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
            return Page();
        }

        [BindProperty]
        public Grocery Grocery { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Groceries.Add(Grocery);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
