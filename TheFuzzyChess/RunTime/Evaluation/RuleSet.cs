using System;
using System.Linq;

namespace FuzzyChess.RunTime.Evaluation
{
    public abstract class RuleSet : IRuleSet
    {
        private readonly Func<ChessContext, double>[] _ratings;

        public RuleSet()
        {
            _ratings = GetRatings();
        }

        private Func<ChessContext, double>[] GetRatings()
        {
            var properties = GetType().GetProperties();
            var funcProperties = properties.Where(p => p.PropertyType == typeof(Func<ChessContext, double>)).ToList();
            var values = funcProperties.Select(p => (Func<ChessContext, double>)p.GetValue(this, null)).ToArray();
            return values;
        }

        public double EvaluateMove(ChessContext ctx)
        {
            var rating = _ratings.Select(f => f(ctx)).Sum();
            return rating;
        }
    }
}
