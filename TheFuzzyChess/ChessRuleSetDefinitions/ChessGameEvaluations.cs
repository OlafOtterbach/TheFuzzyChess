using FuzzyChess.Chess;
using FuzzyChess.Mathmatics;
using FuzzyChess.Mathmatics.Extensions;
using FuzzyChess.RunTime.Evaluation;
using System;
using System.Linq;

namespace FuzzyChess.ChessRuleSetDefinitions
{
    public static class ChessGameEvaluations
    {
        public static Func<ChessContext, Fuzzy>
        Zielfeld_von_Gegner_Besetz
            = ctx => (!ctx.GameBeforeMove.IsEmptyField(ctx.Move.ToX, ctx.Move.ToY) && ctx.GameBeforeMove.GetField(ctx.Move.ToX, ctx.Move.ToY).IsWhite != ctx.ChessPiece.IsWhite).ToFuzzy();

        public static Func<ChessContext, Fuzzy>
        Besetzender_Gegner_Ist_Hoeher = ctx =>
        {
            var worthFieldChessPiece = ctx.GameBeforeMove?.GetField(ctx.Move.ToX, ctx.Move.ToY)?.Value ?? 0;
            var worthMyChessPiece = ctx.ChessPiece.Value;
            return (((worthFieldChessPiece - worthMyChessPiece) / 9.0).ToFuzzy());
        };

        public static Func<ChessContext, Fuzzy> Bedrohender_Gegner_ist_niedriger
            = ctx => ctx.NextOpponentMoves.Where(move => move.ToX == ctx.Move.ToX && move.ToY == ctx.Move.ToY)
                                       .Any(move => move.ChessPiece.Value < ctx.Move.ChessPiece.Value).ToFuzzy();

        public static Func<ChessContext, Fuzzy> Bedrohender_Gegner_ist_hoeher_oder_gleich
            = ctx => ctx.NextOpponentMoves.Where(move => move.ToX == ctx.Move.ToX && move.ToY == ctx.Move.ToY)
                                       .Any(move => move.ChessPiece.Value >= ctx.Move.ChessPiece.Value).ToFuzzy();

        public static Func<ChessContext, Fuzzy>
        Eigenes_Feld_ist_bedroht
           = ctx => ctx.NextOpponentMoves.Where(move => move.ToX == ctx.ChessPiece.X && move.ToY == ctx.ChessPiece.Y).Any().ToFuzzy();

        public static Func<ChessContext, Fuzzy>
        Zielfeld_ist_leer
            = ctx => (ctx.GameAfterMove.GetField(ctx.Move.ToX, ctx.Move.ToY) != null).ToFuzzy();

        public static Func<ChessContext, Fuzzy>
        Zielfeld_ist_bedroht
           = ctx => ctx.NextOpponentMoves.Where(move => move.ToX == ctx.Move.ToX && move.ToY == ctx.Move.ToY).Any().ToFuzzy();

        public static Func<ChessContext, Fuzzy>
        Zielfeld_ist_gedeckt
           = ctx => ctx.NextFriendMoves.Where(move => move.ToX == ctx.Move.ToX && move.ToY == ctx.Move.ToY).Any().ToFuzzy();

        public static Func<ChessContext, Fuzzy>
        Zug_springt_zurück = ctx =>
        {
            var history = ctx.GameBeforeMove.GetHistory(ctx.ChessPiece);

            // Skip firt because it is the move to evaluate.
            var found = history.Reverse().Select((p,i) => new { Place = p, Index = i })
                               .FirstOrDefault(pair => pair.Place.X == ctx.Move.ToX && pair.Place.Y == ctx.Move.ToY);
            if(found == null) return Fuzzy.Create(0.0);
            switch (found.Index)
            {
                case 0: return Fuzzy.Create(1.00);
                case 1: return Fuzzy.Create(0.75);
                case 2: return Fuzzy.Create(0.50);
                case 3: return Fuzzy.Create(0.25);
                case 4: return Fuzzy.Create(0.20);
                case 5: return Fuzzy.Create(0.15);
                case 6: return Fuzzy.Create(0.10);
                case 7: return Fuzzy.Create(0.05);
                default: return Fuzzy.Create(0.0);
            }
        };

        public static Func<ChessContext, Fuzzy>
        Figur_hat_erst_gezogen = ctx =>
        {
            if (ctx.GameAfterMove.CurrentMove == 1) return Fuzzy.Create(0.0);
            var history = ctx.GameBeforeMove.GetHistory(ctx.ChessPiece);
            var lastMove = history.Reverse().Select(h => h.Move).First();
            var delta = ctx.GameAfterMove.CurrentMove - lastMove;
            switch (delta)
            {
                case 0: return Fuzzy.Create(1.00);
                case 1: return Fuzzy.Create(1.00);
                case 2: return Fuzzy.Create(0.75);
                case 3: return Fuzzy.Create(0.50);
                case 4: return Fuzzy.Create(0.25);
                case 5: return Fuzzy.Create(0.20);
                case 6: return Fuzzy.Create(0.15);
                case 7: return Fuzzy.Create(0.10);
                case 8: return Fuzzy.Create(0.05);
                default: return Fuzzy.Create(0.0);
            }
        };

        public static ChessPiece Ist_Ziel_Platz_von_Gegner_bedroht(ChessContext ctx)
        {
            var lowestopponent = ctx.NextOpponentMoves.Where(move => move.ToX == ctx.Move.ToX && move.ToY == ctx.Move.ToY).Select(m => m.ChessPiece).OrderBy(m => m.Value).FirstOrDefault();
            return lowestopponent;
        }

        public static ChessPiece Ist_aktueller_Platz_von_Gegner_bedroht(ChessContext ctx)
        {
            var lowestopponent = ctx.NextOpponentMoves.Where(move => move.ToX == ctx.Move.FromX && move.ToY == ctx.Move.FromY).Select(m => m.ChessPiece).OrderBy(m => m.Value).FirstOrDefault();
            return lowestopponent;
        }

        public static ChessPiece Ist_Zielfeld_gedeckt(ChessContext ctx)
        {
            var lowestFriend = ctx.NextFriendMoves.Where(move => move.ToX == ctx.Move.ToX && move.ToY == ctx.Move.ToY).Select(m => m.ChessPiece).OrderBy(m => m.Value).FirstOrDefault();
            return lowestFriend;
        }

        public static ChessPiece Ist_aktuelles_Feld_gedeckt(ChessContext ctx)
        {
            var lowestFriend = ctx.NextFriendMoves.Where(move => move.ToX == ctx.Move.FromX && move.ToY == ctx.Move.FromY).Select(m => m.ChessPiece).OrderBy(m => m.Value).FirstOrDefault();
            return lowestFriend;
        }

        public static bool Mein_Wert_hoeher_als_Angreifer(ChessPiece iam, ChessPiece opponent)
        => iam.Value > opponent.Value;

        public static bool Mein_Wert_gleich_wie_Angreifer(ChessPiece iam, ChessPiece opponent)
        => iam.Value == opponent.Value;

        public static bool Mein_Wert_kleiner_Angreifer(ChessPiece iam, ChessPiece opponent)
        => iam.Value == opponent.Value;
    }
}
