using System;

namespace FuzzyChess.Chess
{
    public class King : ChessPiece
    {
        public King(ChessId id, int x, int y) : base(id, x, y) { }

        public override ChessPiece Copy(int x, int y) => new King(Id, x, y);
    }
}
