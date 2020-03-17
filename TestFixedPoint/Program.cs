using System;
using System.Text;

namespace TestFixedPoint
{
    class Program
    {
        static string FixedPointPrinter(long input, int point)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(input >> point);
            for (int i = 0; ((input & ((1 << point) - 1)) > 0) && (i < point); i++)
            {
                if (i == 0)
                    sb.Append('.');
                input &= (1 << point) - 1;
                input *= 10;
                sb.Append(input >> point);
            }
            return sb.ToString();
        }
        class A
        {
            public static A Instance => new A();
            A()
            {
            }
            public void PrintMe()
            {
                Console.WriteLine("hello from singleton A");

            }
        }
        static void Main(string[] args)
        {
            long a = 13;
            int point = 2;
            Console.WriteLine(FixedPointPrinter(a, point));

            A.Instance.PrintMe();

        }
    }
}
