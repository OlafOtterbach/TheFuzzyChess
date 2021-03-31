using FuzzyChess.Chess;
using FuzzyChess.ChessRuleSetDefinitions;
using FuzzyChess.RunTime;
using FuzzyChess.RunTime.Evaluation;
using System.Collections.Generic;
using Xunit;

namespace FuzzyChess.Tests.ChessRuleSetDefinitions
{
    public class ChessRuleSetTest
    {
        [Fact]
        public void Rating_Angriff_Test()
        {
            var pawn = new Pawn(ChessId.pawn_black_of_bishop_of_king, 5, 5);
            var knight = new Knight(ChessId.knight_white_of_queen, 6, 6);
            var game = Game.Create(new List<ChessPiece> { pawn, knight });
            var move = new Move(pawn, 5, 5, 6, 6);
            var gameAfterMove = game.Move(pawn, 6, 6);
            var ruleSet = new ChessRuleSet();
            var ctx = new ChessContext() { Move = move, GameBeforeMove = game, GameAfterMove = gameAfterMove, NextFriendMoves = new Move[0], NextOpponentMoves = new Move[0] };

            var rating = ruleSet.Rating_Angriff(ctx);

            Assert.NotEqual(0, rating);
        }

        [Fact]
        public void Rating_Angriff_Test2()
        {
            var pawn = new Pawn(ChessId.pawn_black_of_bishop_of_king, 5, 5);
            var game = Game.Create(new List<ChessPiece> { pawn });
            var move = new Move(pawn, 5, 5, 6, 6);
            var gameAfterMove = game.Move(pawn, 6, 6);
            var ruleSet = new ChessRuleSet();
            var ctx = new ChessContext() { Move = move, GameBeforeMove = game, GameAfterMove = gameAfterMove, NextFriendMoves = new Move[0], NextOpponentMoves = new Move[0] };

            var rating = ruleSet.Rating_Angriff(ctx);

            Assert.Equal(0, rating);
        }

        [Fact]
        public void EvaluateMove_Test1()
        {
            var pawn = new Pawn(ChessId.pawn_black_of_bishop_of_king, 5, 5);
            var knight = new Knight(ChessId.knight_white_of_queen, 6, 6);
            var game = Game.Create(new List<ChessPiece> { pawn, knight });
            var move = new Move(pawn, 5, 5, 6, 6);
            var gameAfterMove = game.Move(pawn, 6, 6);
            var ruleSet = new ChessRuleSet();
            var ctx = new ChessContext() { Move = move, GameBeforeMove = game, GameAfterMove = gameAfterMove, NextFriendMoves = new Move[0], NextOpponentMoves = new Move[0] };

            var rating = ruleSet.EvaluateMove(ctx);

            Assert.NotEqual(0, rating);
        }
    }
}