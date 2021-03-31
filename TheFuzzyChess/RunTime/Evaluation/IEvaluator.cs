using FuzzyChess.Chess;
using System.Collections.Generic;

namespace FuzzyChess.RunTime.Evaluation
{
    public interface IEvaluator
    {
        Move GetBestMove(IEnumerable<Move> moves, Game game);
    }
}
