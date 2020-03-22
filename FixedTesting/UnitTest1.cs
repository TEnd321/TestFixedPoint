using System;
using Xunit;
using Cuni.Arithmetics.FixedPoint;

namespace FixedTesting
{
    public class UnitQ16_16
    {
        [Theory]
        [InlineData(3, 2, "5")]
        [InlineData(42, 8, "50")]
        [InlineData(14, 12, "26")]
        public void AdditionTestingSameTypesQ16_16(int in1, int in2, string exp)
        {
            var f1 = new Fixed<Q16_16>(in1);
            var f2 = new Fixed<Q16_16>(in2);
            Assert.Equal(exp, f1.Add(f2).ToString());
            Assert.Equal(exp, f2.Add(f1).ToString());
        }

        [Theory]
        [InlineData(3, 2, "1")]
        [InlineData(42, 8, "34")]
        [InlineData(14, 12, "2")]
        public void SubtractionTestingSameTypesQ16_16(int in1, int in2, string exp)
        {
            var f1 = new Fixed<Q16_16>(in1);
            var f2 = new Fixed<Q16_16>(in2);
            Assert.Equal(exp, f1.Subtract(f2).ToString());
            Assert.Equal('-' + exp, f2.Subtract(f1).ToString());
        }

        [Theory]
        [InlineData(3, 2, "6")]
        [InlineData(19, 13, "247")]
        [InlineData(14, 12, "168")]
        public void MultiplicationTestingSameTypesQ16_16(int in1, int in2, string exp)
        {
            var f1 = new Fixed<Q16_16>(in1);
            var f2 = new Fixed<Q16_16>(in2);
            Assert.Equal(exp, f1.Multiply(f2).ToString());
            Assert.Equal(exp, f2.Multiply(f1).ToString());
        }

        [Theory]
        [InlineData(248, 10, "24.7999877929688")]
        [InlineData(625, 1000, "0.625")]
        //[InlineData(14, 12, "26")]
        public void DivisionTestingSameTypesQ16_16(int in1, int in2, string exp)
        {
            var f1 = new Fixed<Q16_16>(in1);
            var f2 = new Fixed<Q16_16>(in2);
            Assert.Equal(exp, f1.Divide(f2).ToString());
        }
    }
    public class UnitQ24_8
    {
        [Theory]
        [InlineData(3, 2, "5")]
        [InlineData(3, 0, "3")]
        public void AdditionTestingSameTypesQ24_8(int in1, int in2, string exp)
        {
            var f1 = new Fixed<Q24_8>(in1);
            var f2 = new Fixed<Q24_8>(in2);
            Assert.Equal(exp, f1.Add(f2).ToString());
        }

        [Theory]
        [InlineData(360, 42, "318")]
        [InlineData(14, 12, "2")]
        public void SubtractionTestingSameTypesQ24_8(int in1, int in2, string exp)
        {
            var f1 = new Fixed<Q24_8>(in1);
            var f2 = new Fixed<Q24_8>(in2);
            Assert.Equal(exp, f1.Subtract(f2).ToString());
        }

        [Theory]
        [InlineData(3, 2, "6")]
        [InlineData(19, 13, "247")]
        public void MultiplicationTestingSameTypesQ24_8(int in1, int in2, string exp)
        {
            var f1 = new Fixed<Q24_8>(in1);
            var f2 = new Fixed<Q24_8>(in2);
            Assert.Equal(exp, f1.Multiply(f2).ToString());
        }

        [Theory]
        [InlineData(248, 10, "24.796875")]
        [InlineData(625, 1000, "0.625")]
        //[InlineData(14, 12, "26")]
        public void DivisionTestingSameTypesQ24_8(int in1, int in2, string exp)
        {
            var f1 = new Fixed<Q24_8>(in1);
            var f2 = new Fixed<Q24_8>(in2);
            Assert.Equal(exp, f1.Divide(f2).ToString());
        }

    }
    public class UnitQ8_24
    {
        [Theory]
        [InlineData(3, 2, "5")]
        [InlineData(3, 0, "3")]
        public void AdditionTestingSameTypesQ8_24(int in1, int in2, string exp)
        {
            var f1 = new Fixed<Q8_24>(in1);
            var f2 = new Fixed<Q8_24>(in2);
            Assert.Equal(exp, f1.Add(f2).ToString());
        }

        [Theory]
        [InlineData(360, 42, "62")]
        [InlineData(25, 12, "13")]
        public void SubtractionTestingSameTypesQ8_24(int in1, int in2, string exp)
        {
            var f1 = new Fixed<Q8_24>(in1);
            var f2 = new Fixed<Q8_24>(in2);
            Assert.Equal(exp, f1.Subtract(f2).ToString());
        }

        [Theory]
        [InlineData(3, 2, "6")]
        [InlineData(19, 13, "-9")]
        public void MultiplicationTestingSameTypesQ8_24(int in1, int in2, string exp)
        {
            var f1 = new Fixed<Q8_24>(in1);
            var f2 = new Fixed<Q8_24>(in2);
            Assert.Equal(exp, f1.Multiply(f2).ToString());
        }

        [Theory]
        [InlineData(248, 10, "-0.799999952316284")]
        [InlineData(625, 1000, "-4.70833331346512")]
        public void DivisionTestingSameTypesQ8_24(int in1, int in2, string exp)
        {
            var f1 = new Fixed<Q8_24>(in1);
            var f2 = new Fixed<Q8_24>(in2);
            Assert.Equal(exp, f1.Divide(f2).ToString());
        }
    }
    public class UnitTestingMixed
    {
        [Fact]
        public void TestTwoDistinct()
        {
            Fixed<Q16_16> f1 = new Fixed<Q16_16>(15);
            Fixed<Q24_8> f2 = new Fixed<Q24_8>(15);
            //Build will fail with error code CS1503: Cannot convert from Fixed<Q24_8> to Fixed<Q16_16>
            //Console.WriteLine(f1.Add(f2));
            Assert.True(true);
        }
    }
    public class UnitGenericIComparable
    {
        [Fact]
        public void ToDoubleTesting()
        {
            var f1 = new Fixed<Q16_16>(7);
            var f2 = new Fixed<Q16_16>(2);
            double d = f1.Divide(f2).ToDouble(null);

            Assert.Equal(3.5d, d);
        }

        [Fact]
        public void ToDecimalTesting()
        {
            var f1 = new Fixed<Q16_16>(7);
            var f2 = new Fixed<Q16_16>(2);
            decimal m = f1.Divide(f2).ToDecimal(null);

            Assert.Equal(3.5m, m);
        }

        [Fact]
        public void ToStringTesting()
        {
            var f1 = new Fixed<Q24_8>(14);
            string s = f1.ToString(null);

            Assert.Equal("14", s);
        }

        [Fact]
        public void ToSingleTesting()
        {
            var f1 = new Fixed<Q16_16>(7);
            var f2 = new Fixed<Q16_16>(2);
            float f = f1.Divide(f2).ToSingle(null);

            Assert.Equal(3.5f, f);
        }

        [Fact]
        public void ToCharTesting()
        {
            var f1 = new Fixed<Q16_16>(70);
            char ch = f1.ToChar(null);

            Assert.Equal('F', ch);
        }

        [Fact]
        public void ToBooleanTesting()
        {
            var f1 = new Fixed<Q16_16>(70);
            bool b = f1.ToBoolean(null);

            Assert.True(b);

            f1 = new Fixed<Q16_16>(0);
            b = f1.ToBoolean(null);

            Assert.False(b);
        }

        [Fact]
        public void ToByteTesting()
        {
            var f1 = new Fixed<Q16_16>(256);
            byte b = f1.ToByte(null);

            Assert.Equal(0, b);
        }

        [Fact]
        public void ToInt16Testing()
        {
            var f1 = new Fixed<Q24_8>(65536);
            short s = f1.ToInt16(null);

            Assert.Equal(0, s);
            var f2 = new Fixed<Q8_24>(-1);
            s = f2.ToInt16(null);

            Assert.Equal(-1, s);
        }

        [Fact]
        public void ToInt32Testing()
        {
            var f1 = new Fixed<Q24_8>(65536);
            int i = f1.ToInt32(null);

            Assert.Equal(65536, i);
            var f2 = new Fixed<Q8_24>(-1);
            i = f2.ToInt32(null);

            Assert.Equal(-1, i);
        }

        [Fact]
        public void ToInt64Testing()
        {
            var f1 = new Fixed<Q24_8>(65536);
            long l = f1.ToInt64(null);

            Assert.Equal(65536, l);
            var f2 = new Fixed<Q8_24>(-1);
            l = f2.ToInt64(null);

            Assert.Equal(-1, l);
        }

        [Fact]
        public void ToSByteTesting()
        {
            var f1 = new Fixed<Q24_8>(128);
            sbyte sb = f1.ToSByte(null);

            Assert.Equal(-128, sb);
            var f2 = new Fixed<Q24_8>(-1);
            sb = f2.ToSByte(null);

            Assert.Equal(-1, sb);
        }

        [Fact]
        public void ToUInt16Testing()
        {
            var f1 = new Fixed<Q24_8>(65535);
            ushort us = f1.ToUInt16(null);

            Assert.Equal(65535, us);
            var f2 = new Fixed<Q24_8>(-1);
            us = f2.ToUInt16(null);

            Assert.Equal(65535, us);
        }

        [Fact]
        public void ToUInt32Testing()
        {
            var f1 = new Fixed<Q24_8>(56);
            uint ui = f1.ToUInt32(null);

            Assert.Equal(56u, ui);
            var f3 = new Fixed<Q24_8>(-1);
            ui = f3.ToUInt32(null);

            Assert.Equal(16777215u, ui);
        }

        [Fact]
        public void ToUInt64Testing()
        {
            var f1 = new Fixed<Q24_8>(56);
            ulong ul = f1.ToUInt64(null);

            Assert.Equal(56ul, ul);
            var f3 = new Fixed<Q24_8>(-1);
            ul = f3.ToUInt64(null);

            Assert.Equal(72057594037927935ul, ul);
        }

        [Fact]
        public void ToDateTimeTesting()
        {
            var f1 = new Fixed<Q24_8>(205);
            var f2 = new Fixed<Q24_8>(10);
            DateTime dt = f1.Divide(f2).ToDateTime(null);

            Assert.Equal(new DateTime(2020, 7, 2), dt);
        }
    }
    public class UnitIEquatable
    {
        [Theory]
        [InlineData(7, 7)]
        [InlineData(57, 57)]
        [InlineData(-7, -7)]
        [InlineData(0, 0)]
        public void AreEqualTest(int in1, int in2)
        {
            var f161 = new Fixed<Q16_16>(in1);
            var f162 = new Fixed<Q16_16>(in2);
            Assert.True(f161.Equals(f162));

            var f241 = new Fixed<Q24_8>(in1);
            var f242 = new Fixed<Q24_8>(in2);
            Assert.True(f241.Equals(f242));

            var f81 = new Fixed<Q8_24>(in1);
            var f82 = new Fixed<Q8_24>(in2);
            Assert.True(f81.Equals(f82));
        }

        [Theory]
        [InlineData(7, 6)]
        [InlineData(57, 67)]
        [InlineData(-7, -6)]
        [InlineData(0, 1)]
        public void AreNotEqualTest(int in1, int in2)
        {
            var f161 = new Fixed<Q16_16>(in1);
            var f162 = new Fixed<Q16_16>(in2);
            Assert.False(f161.Equals(f162));

            var f241 = new Fixed<Q24_8>(in1);
            var f242 = new Fixed<Q24_8>(in2);
            Assert.False(f241.Equals(f242));

            var f81 = new Fixed<Q8_24>(in1);
            var f82 = new Fixed<Q8_24>(in2);
            Assert.False(f81.Equals(f82));
        }
    }
    public class UnitIComparable
    {
        [Theory]
        [InlineData(17, 16, 1)]
        [InlineData(17, 18, -1)]
        [InlineData(0, 0, 0)]
        public void CompareTesting(int in1, int in2, int exp)
        {
            var f161 = new Fixed<Q16_16>(in1);
            var f162 = new Fixed<Q16_16>(in2);
            Assert.Equal(exp, f161.CompareTo(f162));

            var f241 = new Fixed<Q24_8>(in1);
            var f242 = new Fixed<Q24_8>(in2);
            Assert.Equal(exp, f241.CompareTo(f242));

            var f81 = new Fixed<Q8_24>(in1);
            var f82 = new Fixed<Q8_24>(in2);
            Assert.Equal(exp, f81.CompareTo(f82));
        }

        [Theory]
        [InlineData(17, 16, 1)]
        [InlineData(17, 18, -1)]
        [InlineData(0, 0, 0)]
        public void CompareTestingObject(int in1, int in2, int exp)
        {
            var f161 = new Fixed<Q16_16>(in1);
            var f162 = new Fixed<Q16_16>(in2);
            Assert.Equal(exp, f161.CompareTo((object)f162));

            var f241 = new Fixed<Q24_8>(in1);
            var f242 = new Fixed<Q24_8>(in2);
            Assert.Equal(exp, f241.CompareTo((object)f242));

            var f81 = new Fixed<Q8_24>(in1);
            var f82 = new Fixed<Q8_24>(in2);
            Assert.Equal(exp, f81.CompareTo((object)f82));

            try
            {
                Assert.Equal(exp, f81.CompareTo(5));
                Assert.False(true);
            }
            catch
            {
                Assert.True(true);
            }
        }
    }
}

