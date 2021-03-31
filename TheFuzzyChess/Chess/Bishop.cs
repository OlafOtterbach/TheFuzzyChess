using System;

namespace FuzzyChess.Chess
{
    public class Bishop : ChessPiece
    {
        public Bishop(ChessId id, int x, int y) : base(id, x, y) { }

        public override ChessPiece Copy(int x, int y) => new Bishop(Id, x, y);
    }
}
