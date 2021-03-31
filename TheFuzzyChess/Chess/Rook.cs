using System;

namespace FuzzyChess.Chess
{
    public class Rook : ChessPiece
    {
        public Rook(ChessId id, int x, int y) : base(id, x, y) { }

        public override ChessPiece Copy(int x, int y) => new Rook(Id, x, y);
    }
}
