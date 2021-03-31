namespace FuzzyChess.Mathmatics
{
    public class Rating
    {
        public Rating(double value)
        {
            Value = value;
        }

        public double Value { get; }

        public static double operator *(Rating left, Fuzzy right) => left.Value * right.Value;

        public static double operator *(Fuzzy left, Rating right) => left.Value * right.Value;
    }
}
