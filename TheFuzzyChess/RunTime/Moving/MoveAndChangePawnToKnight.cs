using FuzzyChess.Chess;

namespace FuzzyChess.RunTime.Moving
{
    public class MoveAndChangePawnToKnight : Move
    {
        public MoveAndChangePawnToKnight(Pawn pawn, int fromX, int fromY, int toX, int toY)
            : base(pawn, fromX, fromY, toX, toY)
        {
        }

        public Pawn Pawn => ChessPiece as Pawn;
    }
}
