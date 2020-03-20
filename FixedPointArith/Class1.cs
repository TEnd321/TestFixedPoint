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
            return this.Number == other.Number;
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
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
            return this.Number != 0;
        }

        public byte ToByte(IFormatProvider provider)
        {
            return (byte)(this.Number >> this.Fraction.Point);
        }

        public char ToChar(IFormatProvider provider)
        {
            return (char)(this.Number >> this.Fraction.Point);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            var thisi = this.ToInt32(null);
            var thisd = this.ToDouble(null);
            var i = thisd - thisi;
            var dt = new DateTime(2000 + thisi, 1, 1);
            if (DateTime.IsLeapYear(2000 + thisi))
                dt = dt.AddDays(366 * i);
            else
                dt = dt.AddDays(365 * i);
            return dt;
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return (this.Number >> this.Fraction.Point) + ((decimal)(this.Number & ((1 << this.Fraction.Point) - 1)) / (decimal)(Math.Pow(4, this.Fraction.Point / 4) * Math.Pow(4, this.Fraction.Point / 4)));
        }

        public double ToDouble(IFormatProvider provider)
        { 
            return (this.Number >> this.Fraction.Point) + ((double)(this.Number & ((1 << this.Fraction.Point) - 1)) / (Math.Pow(4, this.Fraction.Point / 4) * Math.Pow(4, this.Fraction.Point / 4)));
        }

        public short ToInt16(IFormatProvider provider)
        {
            var thisNumber = this.Number;
            if (this.Number < 0)
            {
                thisNumber = ~this.Number;
                thisNumber++;
                thisNumber >>= this.Fraction.Point;
                thisNumber *= -1;
                return (short)thisNumber;
            }
            return (short)(thisNumber >> this.Fraction.Point);
        }

        public int ToInt32(IFormatProvider provider)
        {
            var thisNumber = this.Number;
            if (this.Number < 0)
            {
                thisNumber = ~this.Number;
                thisNumber++;
                thisNumber >>= this.Fraction.Point;
                thisNumber *= -1;
                return thisNumber;
            }
            return thisNumber >> this.Fraction.Point;
        }

        public long ToInt64(IFormatProvider provider)
        {
            return (this.ToInt32(null));
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            var thisNumber = this.Number;
            if (this.Number < 0)
            {
                thisNumber = ~this.Number;
                thisNumber++;
                thisNumber >>= this.Fraction.Point;
                thisNumber *= -1;
                return (sbyte)thisNumber;
            }
            return (sbyte)(thisNumber >> this.Fraction.Point);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return (float)this.ToDouble(null);
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
            return this.ToString();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return this;
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return (ushort)((uint)this.Number >> this.Fraction.Point);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return ((uint)this.Number >> this.Fraction.Point);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return ((uint)this.Number >> this.Fraction.Point);
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
