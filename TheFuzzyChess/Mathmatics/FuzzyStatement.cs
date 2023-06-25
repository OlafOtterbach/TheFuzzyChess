using System;

namespace FuzzyChess.Mathmatics
{
    public static class STMNT
    {
        public static Rating Rate(double rating) => new Rating(rating);
        public static Func<TParameter, double> For<TParameter>(this Rating rating, Func<TParameter, Fuzzy> f) => ctx => rating * f(ctx);


        public static Func<TParameter, Fuzzy> Is<TParameter>(Func<TParameter, Fuzzy> f) => f;
        public static Func<TParameter, Fuzzy> Is<TParameter>(Fuzzy val) => ctx => val;
        public static Func<TParameter, Fuzzy> Is<TParameter>(Func<TParameter, bool> f) => ctx => Fuzzy.Create(f(ctx));


        public static Fuzzy Not(this Fuzzy value) => !value;
        public static Func<TParameter, Fuzzy> Not<TParameter>(Func<TParameter, Fuzzy> func) => ctx => !func(ctx);
        public static Func<TParameter, Fuzzy> Not<TParameter>(Func<TParameter, bool> func) => ctx => Fuzzy.Create(!func(ctx));


        public static Fuzzy And(this Fuzzy first, Fuzzy second) => first & second;

        public static Func<TParameter, Fuzzy> And<TParameter>(this Fuzzy first, Func<TParameter, Fuzzy> second) => ctx =>
        {
            if (first.IsZero)
                return first;

            return first & second(ctx);
        };

        public static Func<TParameter, Fuzzy> And<TParameter>(this Func<TParameter, Fuzzy> first, Fuzzy second) => ctx => first(ctx) & second;

        public static Func<TParameter, Fuzzy> And<TParameter>(this Func<TParameter, Fuzzy> first, Func<TParameter, Fuzzy> second) => ctx =>
        {
            var firstVal = first(ctx);
            if (firstVal.IsZero)
                return firstVal;

            return firstVal & second(ctx);
        };

        public static Func<TParameter, Fuzzy> And<TParameter>(this Func<TParameter, Fuzzy> first, Func<TParameter, bool> second) => ctx =>
        {
            var firstVal = first(ctx);
            if (firstVal.IsZero)
                return firstVal;

            return firstVal & Fuzzy.Create(second(ctx));
        };

        public static Fuzzy Or(this Fuzzy first, Fuzzy second) => first | second;
        public static Func<TParameter, Fuzzy> Or<TParameter>(this Fuzzy first, Func<TParameter, Fuzzy> second) => ctx => first | second(ctx);
        public static Func<TParameter, Fuzzy> Or<TParameter>(this Func<TParameter, Fuzzy> first, Fuzzy second) => ctx => first(ctx) | second;
        public static Func<TParameter, Fuzzy> Or<TParameter>(this Func<TParameter, Fuzzy> first, Func<TParameter, Fuzzy> second) => ctx => first(ctx) | second(ctx);


        public static Fuzzy Xor(this Fuzzy first, Fuzzy second) => first ^ second;
        public static Func<TParameter, Fuzzy> Xor<TParameter>(this Fuzzy first, Func<TParameter, Fuzzy> second) => ctx => first ^ second(ctx);
        public static Func<TParameter, Fuzzy> Xor<TParameter>(this Func<TParameter, Fuzzy> first, Fuzzy second) => ctx => first(ctx) ^ second;
        public static Func<TParameter, Fuzzy> Xor<TParameter>(this Func<TParameter, Fuzzy> first, Func<TParameter, Fuzzy> second) => ctx => first(ctx) ^ second(ctx);


        public static Fuzzy Mult(this Fuzzy first, Fuzzy second) => first * second;
        public static Func<TParameter, Fuzzy> Mult<TParameter>(this Fuzzy first, Func<TParameter, Fuzzy> second) => ctx => first * second(ctx);
        public static Func<TParameter, Fuzzy> Mult<TParameter>(this Func<TParameter, Fuzzy> first, Fuzzy second) => ctx => first(ctx) * second;
        public static Func<TParameter, Fuzzy> Mult<TParameter>(this Func<TParameter, Fuzzy> first, Func<TParameter, Fuzzy> second) => ctx => first(ctx) * second(ctx);
    }
}
