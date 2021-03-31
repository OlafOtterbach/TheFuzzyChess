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
