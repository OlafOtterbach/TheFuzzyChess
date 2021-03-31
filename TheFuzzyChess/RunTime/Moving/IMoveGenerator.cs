using FuzzyChess.Chess;
using System.Collections.Generic;

namespace FuzzyChess.RunTime.Moving
{
    public interface IMoveGenerator
    {
        IEnumerable<Move> NextMoves(IEnumerable<ChessPiece> chessPieces, Game game);
    }
}
