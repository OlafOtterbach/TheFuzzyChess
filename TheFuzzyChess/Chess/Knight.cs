using System;

namespace FuzzyChess.Chess
{
    public class Knight : ChessPiece
    {
        public Knight(ChessId id, int x, int y) : base(id, x, y) { }

        public override ChessPiece Copy(int x, int y) => new Knight(Id, x, y);
    }
}
