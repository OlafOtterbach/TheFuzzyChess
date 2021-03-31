using FuzzyChess.Chess;
using FuzzyChess.RunTime.Evaluation;
using FuzzyChess.RunTime.Moving;
using System;
using System.Threading;

namespace FuzzyChess.RunTime
{
    public class ChessRunTime
    {
        private readonly IEvaluator _evaluator;
        private readonly IMoveGenerator _moveGenerator;

        public ChessRunTime(IEvaluator evaluator, IMoveGenerator moveGenerator)
        {
            _evaluator = evaluator;
            _moveGenerator = moveGenerator;
        }

        public void Run(Game game)
        {
            Output.Print(game);
            Thread.Sleep(500);
            while (game.WhiteChessPieces.Length > 0 && game.BlackChessPieces.Length > 0)
            {
                var whiteMoves = _moveGenerator.NextMoves(game.WhiteChessPieces, game);
                var bestWhiteMove = _evaluator.GetBestMove(whiteMoves, game);
                if (bestWhiteMove == null) 
                    break;
                Animate(bestWhiteMove, game);
                game = Execute(bestWhiteMove, game);
                Output.Print(game);
                Thread.Sleep(250);
                if (game.WhiteWins) break;

                var blackMoves = _moveGenerator.NextMoves(game.BlackChessPieces, game);
                var bestBlackMove = _evaluator.GetBestMove(blackMoves, game);
                if (bestBlackMove == null) 
                    break;
                Animate(bestBlackMove, game);
                game = Execute(bestBlackMove, game);
                Output.Print(game);
                Thread.Sleep(250);
                if (game.BlackWins) break;
            }

            if (game.WhiteWins)
                Output.PrintMessage("White wins.");
            else if(game.BlackWins)
                Output.PrintMessage("Black wins.");
        }


        private void Animate(Move move, Game game)
        {
            var deltaX = move.ToX - move.FromX;
            var deltaY = move.ToY - move.FromY;
            var stepX = deltaX < 0 ? -1 : deltaX > 0 ? 1 : 0;
            var stepY = deltaY < 0 ? -1 : deltaY > 0 ? 1 : 0;
            var n = Math.Max(Math.Abs(deltaX), Math.Abs(deltaY));
            var x = move.FromX;
            var y = move.FromY;
            for(var i = 0; i < n; i++)
            {
                if(x != move.ToX)
                {
                    x = x + stepX;
                }
                if(y != move.ToY)
                {
                    y = y + stepY;
                }

                var newGame = game.Move(move.ChessPiece, x, y);
                Output.Print(newGame);
                Thread.Sleep(250);
            }
        }

        private Game Execute(Move move, Game game)
        {
            if (move is MoveAndChangePawnToQueen moveAndChangePawnToQueen)
            {
                return game.MoveAndReplaceByQueen(moveAndChangePawnToQueen.Pawn, moveAndChangePawnToQueen.ToX, moveAndChangePawnToQueen.ToY);
            }
            else if (move is MoveAndChangePawnToKnight moveAndChangePawnToKnight)
            {
                return game.MoveAndReplaceByKnight(moveAndChangePawnToKnight.Pawn, moveAndChangePawnToKnight.ToX, moveAndChangePawnToKnight.ToY);
            }
            else
            {
                return game.Move(move.ChessPiece, move.ToX, move.ToY);
            }
        }
    }
}
