using System;

namespace FuzzyChess.Chess
{
    public abstract class ChessPiece
    {
        protected ChessPiece(ChessId id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }

        public ChessId Id { get; }

        public int Value => Id.Value();

        public bool IsWhite => Id.IsWhite();

        public bool IsBlack => Id.IsBlack();

        public bool IsPawn => Id.IsPawn();

        public bool IsRook => Id.IsRook();

        public bool IsKnight => Id.IsKnight();

        public bool IsBishop => Id.IsBishop();

        public bool IsQueen => Id.IsQueen();

        public bool IsKing => Id.IsKing();

        public int X { get; }

        public int Y { get; }

        public abstract ChessPiece Copy(int x, int y);
    }
}
