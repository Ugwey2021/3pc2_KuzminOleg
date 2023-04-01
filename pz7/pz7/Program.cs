using System;

namespace pz7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store s = new Store() { AllPurshares=""};
            Client me = new Client() { AllPurchases = 10000, Name="Oleg"};
            Client he = new Client() { AllPurchases=800, Name="NoName"};
            Client she = new Client() { AllPurchases = 1400, Name = "UnknownName" };
            Keyboard k = new Keyboard() { Name="bloody345",Type="механическая"
                ,IsAdditionalKey=true,Price=1800};
            Gamepad g = new Gamepad() { Name="dualshock",Price=2500,
                SupportXInput=true,Model="ps4"};
            Mouse m = new Mouse() { Name="WowMouse",DPI=1500,Wireless=true,Price=1400};
            s.SaveOrder(me, new Product[4]{k,g,m,k});
            s.SaveOrder(he, new Product[3] { g, m,g });
            s.SaveOrder(she, new Product[2] { k, m });
            Console.WriteLine(s.AllPurshares);
        }
    }
}
