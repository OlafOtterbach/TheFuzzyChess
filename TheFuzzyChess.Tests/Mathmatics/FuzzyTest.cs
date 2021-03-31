using Xunit;

namespace FuzzyChess.Mathmatics.Test
{
    
    public class FuzzyTest
    {
        [Fact]
        public void CreateTest()
        {
            Assert.Equal(0.5, Fuzzy.Create(0.5).Value, MathConstants.Precision);
            Assert.Equal(0.0, Fuzzy.Create(-1.0).Value, MathConstants.Precision);
            Assert.Equal(1.0, Fuzzy.Create(2.0).Value, MathConstants.Precision);
        }

        [Fact]
        public void CreateMaxTest()
        {
            Assert.Equal(0.1, Fuzzy.Create(10, 100).Value, MathConstants.Precision);
            Assert.Equal(0.0, Fuzzy.Create(-1.0, 100).Value, MathConstants.Precision);
            Assert.Equal(1.0, Fuzzy.Create(200.0, 100).Value, MathConstants.Precision);
        }

        [Fact]
        public void TruePositiveTest()
        {
            Assert.True(new Fuzzy(0.7) ? true : false);
        }

        [Fact]
        public void TruePositiveLimitTest()
        {
            Assert.True(new Fuzzy(0.5) ? true : false);
        }

        public void FalsePositiveTest()
        {
            Assert.False(new Fuzzy(0.3) ? true : false);
        }

        public void FalsePositiveLimitTest()
        {
            Assert.False(new Fuzzy(0.5 - MathConstants.Epsilon) ? true : false);
        }

        [Fact]
        public void AndTest()
        {
            var x = Fuzzy.Create(0.9);
            var y = Fuzzy.Create(0.7);
            var xAndY = x && y;

            Assert.Equal(y, xAndY);
        }

        [Fact]
        public void OrTest()
        {
            var x = Fuzzy.Create(0.9);
            var y = Fuzzy.Create(0.7);
            var xOrY = x || y;

            Assert.Equal(x, xOrY);
        }

        [Fact]
        public void XorTest()
        {
            var x = Fuzzy.Create(0.9);
            var y = Fuzzy.Create(0.3);
            var xXorY = x ^ y;

            Assert.Equal(Fuzzy.Create(0.7), xXorY);
        }
    }
}