using System;

namespace FuzzyChess.Mathmatics
{
    public struct Fuzzy
    {
        private const double Epsilon = 1.0 * 1E-5;

        public Fuzzy(double value)
        {
            if (value < 0.0) value = 0.0;
            if (value > 1.0) value = 1.0;
            Value = value;
        }

        public Fuzzy ChangeValue(double value)
        {
            return new Fuzzy(value);
        }

        public double Value { get; }

        public bool IsZero
        {
            get
            {
                return Math.Abs(Value) < Epsilon;
            }
        }

        public static bool operator true(Fuzzy fuzzy)
        {
            return fuzzy.Value >= 0.5;
        }

        public static bool operator false(Fuzzy fuzzy)
        {
            return fuzzy.Value < 0.5;
        }

        public static Fuzzy operator &(Fuzzy left, Fuzzy right)
        {
			if(left.IsZero || right.IsZero)
			{
			    return new Fuzzy(0.0);
			}
			else
			{
				return new Fuzzy(Math.Min(left.Value, right.Value));
			}
        }

        public static Fuzzy operator |(Fuzzy left, Fuzzy right)
        {
            return new Fuzzy(Math.Max(left.Value, right.Value));
        }

        public static Fuzzy operator ^(Fuzzy first, Fuzzy second)
        {
            return (first & (!second)) | ((!first) & second);
        }

        public static Fuzzy operator !(Fuzzy fuzzyValue)
        {
            return new Fuzzy(Math.Max(1.0 - fuzzyValue.Value, 0.0));
        }
		
        public static Fuzzy operator *(Fuzzy left, Fuzzy right)
        {
			var res = new Fuzzy(Math.Min(Math.Max(left.Value * right.Value, 0.0), 1.0));
            return res;
        }

        public static double operator *(Fuzzy left, double right)
        {
            var res = left.Value * right;
            return res;
        }

        public static double operator *(double left, Fuzzy right)
        {
            var res = left * right.Value;
            return res;
        }

        public static bool operator ==(Fuzzy first, Fuzzy second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Fuzzy first, Fuzzy second)
        {
            return !first.Equals(second);
        }

        public static bool operator <(Fuzzy first, Fuzzy second)
        {
            return first.Value < second.Value;
        }

        public static bool operator <=(Fuzzy first, Fuzzy second)
        {
            return first.Value <= second.Value;
        }

        public static bool operator >(Fuzzy first, Fuzzy second)
        {
            return first.Value > second.Value;
        }

        public static bool operator >=(Fuzzy first, Fuzzy second)
        {
            return first.Value >= second.Value;
        }

        public bool Equals(Fuzzy other)
        {
            return (Math.Abs(Value - other.Value) < Epsilon);
        }

        public override bool Equals(object obj)
        {
            return (obj is Fuzzy) && Equals((Fuzzy)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool ToBool()
        {
            return Value >= 0.5;
        }

        public override string ToString()
        {
            return $"{Value}";
        }

        public static Fuzzy Create(bool value)
        {
            return new Fuzzy(value ? 1.0 : 0.0);
        }

        public static Fuzzy Create(double value)
        {
            return new Fuzzy(value);
        }

        public static Fuzzy Create(double value, double max)
        {
            if (max < 0.0)
            {
                new ArgumentException("Argument should not be negative", nameof(max));
            }

            return Create(value, 0.0, max);
        }

        public static Fuzzy Create(double value, double min, double max)
        {
            if (value < min) value = min;
            if (value > max) value = max;

            var absValue = value - min;
            var absMax = max - min;
            value = absMax == 0.0 ? 0.0 : absValue / absMax;

            return new Fuzzy(value);
        }

        public int CompareTo(Fuzzy other)
        {
            var result = this < other ? -1 : this > other ? 1 : 0;
            return result;
        }
    }
}