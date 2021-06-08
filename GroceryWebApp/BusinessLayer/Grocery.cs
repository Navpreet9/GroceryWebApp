using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryWebApp.BusinessLayer
{
    public class Grocery
    {
        public int GroceryID { get; set; }

        public string GroceryName { get; set; }

        public float Price { get; set; }

        public int CategoryID { get; set; }

        public Category Category { get; set; }

        public int BrandID { get; set; }

        public Brand Brand { get; set; }
    }
}
