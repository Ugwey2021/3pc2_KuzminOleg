using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz9
{
    interface ITarget
    {
        public void ClientDouble(double d);
        public void ClientInt(int i);
        public void ClientChar(char c);
    }
}
