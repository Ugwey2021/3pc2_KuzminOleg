using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz9
{
    internal class Client : Origin,ITarget
    {
        public void ClientDouble(double d)
        {
            base.OriginDouble(d);
        }
        public void ClientInt(int i)
        {
            base.OriginInt(i*2);
        }
        public void ClientChar(char c)
        {
            for (int i = 0; i <= 5; i++)
            {
                base.OriginChar(c);
            }
        }
    }
}
