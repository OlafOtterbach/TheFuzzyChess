using System;
using Xunit;

namespace FuzzyChess.Mathmatics.Test
{
    public class Context
    {
        public double Value { get; set; }
    }

    public class FuzzyStatementTest
    {
        [Fact]
        public void AndTest1()
        {
            Func<Context, Fuzzy> first = context => Fuzzy.Create(context.Value);
            Fuzzy second(Context context) => Fuzzy.Create(context.Value).Not();

            var context = new Context() { Value = 0.7 };

            var firstFunc = STMNT.Is(first.And(second));
            var secondFunc = STMNT.Is(first).And(second);

            var resultFirst = firstFunc(context);
            var resultSecond = secondFunc(context);

            Assert.Equal(resultFirst.Value, resultSecond.Value);
        }

        [Fact]
        public void AndTest_True_and_true()
        {
            var a = 0;
            var b = 0;

            Fuzzy First(int x)
            {
                a = 1;
                return Fuzzy.Create(x == 1);
            }

            Fuzzy Second(int x)
            {
                b = 1;
                return Fuzzy.Create(x == 1);
            }

            var result = STMNT.And<int>(First, Second)(1);

            Assert.Equal(1.0, result.Value);
            Assert.Equal(1, a);
            Assert.Equal(1, b);
        }

        [Fact]
        public void AndTest_False_and_false()
        {
            var a = 0;
            var b = 0;

            Fuzzy First(int x)
            {
                a = 1;
                return Fuzzy.Create(x == 1);
            }

            Fuzzy Second(int x)
            {
                b = 1;
                return Fuzzy.Create(x == 1);
            }

            var result = STMNT.And<int>(First, Second)(0);

            Assert.Equal(0.0, result.Value);
            Assert.Equal(1, a);
            Assert.Equal(0, b);
        }


        [Fact]
        public void OrTest1()
        {
            Func<Context, Fuzzy> first = context => Fuzzy.Create(context.Value);
            Fuzzy second(Context context) => Fuzzy.Create(context.Value).Not();

            var context = new Context() { Value = 0.7 };

            var firstFunc = STMNT.Is(first.Or(second));
            var secondFunc = STMNT.Is(first).Or(second);

            var resultFirst = firstFunc(context);
            var resultSecond = secondFunc(context);

            Assert.Equal(resultFirst.Value, resultSecond.Value);
        }
    }
}
