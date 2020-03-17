using System;
using Xunit;
using Cuni.Arithmetics.FixedPoint;

namespace FixedTesting
{
    public class UnitTest1
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
        [InlineData(248, 10, "-0.799999952316284")]
        [InlineData(625, 1000, "-4,70833331346512")]
        //[InlineData(14, 12, "26")]
        public void DivisionTestingSameTypesQ8_24(int in1, int in2, string exp)
        {
            var f1 = new Fixed<Q8_24>(in1);
            var f2 = new Fixed<Q8_24>(in2);
            Assert.Equal(exp, f1.Divide(f2).ToString());
        }
    }
}

