using FuzzyChess.Chess;
using FuzzyChess.RunTime.Moving;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyChess.RunTime.Evaluation
{
    public class Evaluator : IEvaluator
    {
        private readonly IRuleSet _knowledge;
        private readonly IMoveGenerator _moveGenerator;

        public Evaluator(IRuleSet knowledge, IMoveGenerator moveGenerator)
        {
            _knowledge = knowledge;
            _moveGenerator = moveGenerator;
        }

        public Move GetBestMove(IEnumerable<Move> moves, Game game)
        {
            var worthAndMoves = moves.Select(move => new WorthOfMove {Move = move, Worth = EvaluateMove(move, game)}).ToList();
            var bestWorthOfMove
                = worthAndMoves
                       .Aggregate(new WorthOfMove { Move = null, Worth = double.NegativeInfinity }, (acc, x) => x.Worth > acc.Worth ? x : acc);
            var bestMove = bestWorthOfMove.Move;

            return bestMove;
        }

        private double EvaluateMove(Move move, Game game)
        {
            var gameWithMove = game.Move(move.ChessPiece, move.ToX, move.ToY);
            var opponents = move.ChessPiece.IsWhite ? gameWithMove.BlackChessPieces : gameWithMove.WhiteChessPieces;
            var nextOpponentMoves = _moveGenerator.NextMoves(opponents, gameWithMove).ToArray();
            var friends = (move.ChessPiece.IsWhite ? gameWithMove.WhiteChessPieces : gameWithMove.BlackChessPieces).Where(x => x.Id != move.ChessPiece.Id);
            var nextFriendMoves = _moveGenerator.NextMoves(friends, gameWithMove).ToArray();

            var ctx = new ChessContext() { Move = move, GameBeforeMove = game, GameAfterMove = gameWithMove, NextOpponentMoves = nextOpponentMoves, NextFriendMoves = nextFriendMoves };

            var rating = _knowledge.EvaluateMove(ctx);
            return rating;
        }
    }
}