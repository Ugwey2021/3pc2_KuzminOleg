using System;

namespace pz9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Origin o = new Origin();
            Console.WriteLine("Введите дробное число:");
            double d = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите целое число:");
            int i  = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите символ:");
            char c = char.Parse(Console.ReadLine());
            Console.WriteLine("Вывод методами Origin");
            o.OriginDouble(d);
            o.OriginInt(i);
            o.OriginChar(c);
            Console.WriteLine("Вывод методами Client");
            ITarget target = new Client();
            target.ClientDouble(d);
            target.ClientInt(i);
            target.ClientChar(c);
        }
    }
}
