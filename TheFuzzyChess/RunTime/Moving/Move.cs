using FuzzyChess.Chess;

namespace FuzzyChess.RunTime
{
    public class Move
    {
        public Move(ChessPiece chessPiece, int fromX, int fromY, int toX, int toY)
        {
            ChessPiece = chessPiece;
            FromX = fromX;
            FromY = fromY;
            ToX = toX;
            ToY = toY;
        }

        public ChessPiece ChessPiece { get; }

        public int FromX { get; }

        public int FromY { get; }

        public int ToX { get; }

        public int ToY { get; }
    }
}
