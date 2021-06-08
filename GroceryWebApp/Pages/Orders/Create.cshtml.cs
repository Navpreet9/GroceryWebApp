using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroceryWebApp.BusinessLayer;
using GroceryWebApp.Data;

namespace GroceryWebApp.Pages.Orders
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
        ViewData["GroceryID"] = new SelectList(_context.Groceries, "GroceryID", "GroceryName");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
