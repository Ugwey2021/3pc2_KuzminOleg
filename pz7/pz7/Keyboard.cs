using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz7
{
    internal class Keyboard : Product
    {
        public string Type { get; set; }
        public bool IsAdditionalKey { get; set; }
        public override double GetDiscount(Client c)
        {
            return base.GetDiscount(c)+0.1;
        }
    }
}
