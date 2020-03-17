using System;
using System.Text;

namespace Cuni.Arithmetics.FixedPoint
{
    public interface IFixedPoint
    {
        int Point { get; }
    }
    public interface IFixedArith<T> where T : IFixedPoint, new()
    {
        T Fraction { get; }
        long Number { get; }
        IFixedArith<T> Add(IFixedArith<T> other);
        IFixedArith<T> Subtract(IFixedArith<T> other);
        IFixedArith<T> Multiply(IFixedArith<T> other);
        IFixedArith<T> Divide(IFixedArith<T> other);
    }

    public struct Fixed<T> : IFixedArith<T> where T : IFixedPoint, new()
    {
        public Fixed(long number)
        {
            Number = number;
            Fraction = new T();
        }

        public long Number { get; }

        public T Fraction { get; }

        public IFixedArith<T> Add(IFixedArith<T> other)
        {
            return new Fixed<T>(this.Number + other.Number);
        }

        public IFixedArith<T> Divide(IFixedArith<T> other)
        {
            return null;
        }

        public IFixedArith<T> Multiply(IFixedArith<T> other)
        {
            return new Fixed<T>((this.Number * other.Number) >> Fraction.Point);
        }

        public IFixedArith<T> Subtract(IFixedArith<T> other)
        {
            return new Fixed<T>(this.Number - other.Number);
        }
    }

    public class Q8_24 : IFixedPoint
    {
        public int Point { get; }
        public Q8_24()
        {
            Point = 24;
        }
    }

    public class Q16_16 : IFixedPoint
    {
        public int Point { get; }
        public Q16_16()
        {
            Point = 16;
        }
    }

    public class Q24_8 : IFixedPoint
    {
        public int Point { get; }
        public Q24_8()
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
