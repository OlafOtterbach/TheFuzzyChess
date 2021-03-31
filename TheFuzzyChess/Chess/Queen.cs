using System;

namespace FuzzyChess.Chess
{
    public class Queen : ChessPiece
    {
        public Queen(ChessId id, int x, int y) : base(id,  x, y) { }

        public override ChessPiece Copy(int x, int y) => new Queen(Id, x, y);
    }
}
