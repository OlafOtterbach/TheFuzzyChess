using System;

namespace FuzzyChess.Chess
{
    public class Pawn : ChessPiece
    {
        public Pawn(ChessId id, int x, int y) : base(id, x, y) { }

        public override ChessPiece Copy(int x, int y) => new Pawn(Id, x, y);
    }
}
