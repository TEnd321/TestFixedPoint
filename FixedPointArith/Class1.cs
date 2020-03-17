using System;
using System.Text;

namespace Cuni.Arithmetics.FixedPoint
{
    public interface IFixed
    {
        int Point { get; }
        long Number { get; }
    }
    public interface IFixedArith
    {

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
    public class Fixed
    {

    }
}
