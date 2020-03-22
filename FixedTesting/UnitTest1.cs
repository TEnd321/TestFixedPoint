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
}

