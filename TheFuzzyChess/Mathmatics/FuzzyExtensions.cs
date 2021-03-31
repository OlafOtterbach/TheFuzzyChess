namespace FuzzyChess.Mathmatics.Extensions
{
    public static class FuzzyExtensions
    {
        public static Fuzzy ToFuzzy(this bool value) => Fuzzy.Create(value);

        public static Fuzzy ToFuzzy(this double value) => Fuzzy.Create(value);
    }
}
