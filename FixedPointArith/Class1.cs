using System;
using System.Text;

namespace Cuni.Arithmetics.FixedPoint
{
    public interface IFixedPoint
    {
        static int Point { get; }
    }
    public interface IFixedArith<T> where T : IFixedPoint
    { 
        long Number { get; }
        IFixedArith<T> Add(IFixedArith<T> a);
        IFixedArith<T> Subtract(IFixedArith<T> a);
        IFixedArith<T> Multiply(IFixedArith<T> a);
        IFixedArith<T> Divide(IFixedArith<T> a);
    }

    public struct Fixed<T> : IFixedArith<T> where T : IFixedPoint
    {

    }

    public struct Q8_24 : IFixedPoint
    {
        static int Point { get; }
        static Q8_24()
        {
            Point = 24;    
        }
    }

    public struct Q16_16 : IFixedPoint
    {
        static int Point { get; }
        static Q16_16()
        {
            Point = 16;
        }
    }

    public struct Q24_8 : IFixedPoint
    {
        static int Point { get; }
        static Q24_8()
        {
            Point = 8;
        }
    }

    public sealed class Printer
    {
        public static Printer Instance => new Printer();
        Printer() { }
        public string Print(long input, int point)
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
    }

}
