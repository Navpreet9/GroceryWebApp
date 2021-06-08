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
    public class IndexModel : PageModel
    {
        private readonly GroceryWebApp.Data.GroceryDBContext _context;

        public IndexModel(GroceryWebApp.Data.GroceryDBContext context)
        {
            _context = context;
        }

        public IList<Grocery> Grocery { get;set; }

        public async Task OnGetAsync()
        {
            Grocery = await _context.Groceries
                .Include(g => g.Brand)
                .Include(g => g.Category).ToListAsync();
        }
    }
}
