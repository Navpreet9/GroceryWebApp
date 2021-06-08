using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryWebApp.BusinessLayer
{
    public class Order
    {
        public int OrderID { get; set; }

        public int GroceryID { get; set; }

        public Grocery Grocery { get; set; }

        public int Quantity { get; set; }

        public string CustomerName { get; set; }

        public string ContactNo { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
