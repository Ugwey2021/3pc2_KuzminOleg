using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz7
{
    internal class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public virtual double GetDiscount(Client c)
        {
            if (c.AllPurchases > 1000) return 0.85;
            else if (c.AllPurchases > 4000) return 0.5;
            else if (c.AllPurchases > 8000) return 0.25;
            else return 1;
        }
    }
    
}
