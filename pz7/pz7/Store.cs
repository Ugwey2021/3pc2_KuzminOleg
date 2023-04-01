using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz7
{
    internal class Store
    {
        public string AllPurshares { get; set; }
        public void SaveOrder(Client c,Product[] pr)
        {
            AllPurshares += '\n'+$"Клиент {c.Name}"+'\n'+"Покупка:";
            foreach (Product p in pr) 
            {
                AllPurshares += p.Name + ' ';
                c.AllPurchases += p.Price*p.GetDiscount(c);
            }
        }
    }
}
