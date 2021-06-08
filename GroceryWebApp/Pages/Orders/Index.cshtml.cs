using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroceryWebApp.BusinessLayer;
using GroceryWebApp.Data;

namespace GroceryWebApp.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly GroceryWebApp.Data.GroceryDBContext _context;

        public IndexModel(GroceryWebApp.Data.GroceryDBContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.Grocery)
                .OrderByDescending(o => o.OrderDate).ToListAsync();
        }
    }
}
