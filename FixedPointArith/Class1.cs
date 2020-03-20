using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Cuni.Arithmetics.FixedPoint
{
    public interface IFixedPoint
    {
        int Point { get; }
    }
    public interface IFixedArith<T> : IEquatable<IFixedArith<T>>, IConvertible, IComparable, IComparable<IFixedArith<T>> where T : IFixedPoint, new()
    {
        T Fraction { get; }
        int Number { get; }
        IFixedArith<T> Add(IFixedArith<T> other);
        IFixedArith<T> Subtract(IFixedArith<T> other);
        IFixedArith<T> Multiply(IFixedArith<T> other);
        IFixedArith<T> Divide(IFixedArith<T> other);
    }

    public struct Fixed<T> : IFixedArith<T> where T : IFixedPoint, new()
    {
        public Fixed(int number, bool shouldShift = true)
        {
            Fraction = new T();
            Number = number;
            if (shouldShift)
                Number <<= Fraction.Point;
        }

        public int Number { get; }

        public T Fraction { get; }

        public IFixedArith<T> Add(IFixedArith<T> other)
        {
            return new Fixed<T>(this.Number + other.Number, false);
        }

        public int CompareTo(object obj)
        {
            if (obj is IFixedArith<T> ifa)
            {
                if (this.Number < ifa.Number)
                    return -1;
                else if (this.Number == ifa.Number)
                    return 0;
                else
                    return 1;
            }
            throw new InvalidOperationException();
        }

        public int CompareTo([AllowNull] IFixedArith<T> other)
        {
            if (this.Number < other.Number)
                return -1;
            else if (this.Number == other.Number)
                return 0;
            else
                return 1;
        }

        public IFixedArith<T> Divide(IFixedArith<T> other)
        {
            return new Fixed<T>((int)((((long)this.Number) << this.Fraction.Point) / other.Number), false);
        }

        public bool Equals([AllowNull] IFixedArith<T> other)
        {
            throw new NotImplementedException();
        }

        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public IFixedArith<T> Multiply(IFixedArith<T> other)
        {
            long thisNumber = this.Number;
            thisNumber *= other.Number;
            thisNumber >>= Fraction.Point;
            return new Fixed<T>((int)thisNumber, false);
        }

        public IFixedArith<T> Subtract(IFixedArith<T> other)
        {
            return new Fixed<T>(this.Number - other.Number, false);
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            int input = Number;
            StringBuilder sb = new StringBuilder();
            if ((uint)input >= 0x8000_0000)
            {
                sb.Append('-');
                input = ~input;
                input += 1;
            }
            sb.Append((input >> Fraction.Point));
            for (int i = 0; ((input & ((1 << Fraction.Point) - 1)) > 0) && (i < Fraction.Point); i++)
            {
                if (i == 0)
                    sb.Append('.');
                input &= (1 << Fraction.Point) - 1;
                input *= 10;
                sb.Append(input >> Fraction.Point);
            }
            return sb.ToString();
        }

        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
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
