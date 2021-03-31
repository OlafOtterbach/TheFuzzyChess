using FuzzyChess.Chess;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuzzyChess.Tests.Chess
{
    public class GameTest
    {
        [Fact]
        public void ConstructorTest()
        {
            var game = Game.Create();

            Assert.Equal(16, game.WhiteChessPieces.Length);
            Assert.Equal(16, game.BlackChessPieces.Length);

            Assert.Equal(8, game.WhiteChessPieces.OfType<Pawn>().Count());
            Assert.Equal(2, game.WhiteChessPieces.OfType<Rook>().Count());
            Assert.Equal(2, game.WhiteChessPieces.OfType<Knight>().Count());
            Assert.Equal(2, game.WhiteChessPieces.OfType<Bishop>().Count());
            Assert.Equal(1, game.WhiteChessPieces.OfType<Queen>().Count());
            Assert.Equal(1, game.WhiteChessPieces.OfType<King>().Count());

            Assert.Equal(8, game.BlackChessPieces.OfType<Pawn>().Count());
            Assert.Equal(2, game.BlackChessPieces.OfType<Rook>().Count());
            Assert.Equal(2, game.BlackChessPieces.OfType<Knight>().Count());
            Assert.Equal(2, game.BlackChessPieces.OfType<Bishop>().Count());
            Assert.Equal(1, game.BlackChessPieces.OfType<Queen>().Count());
            Assert.Equal(1, game.BlackChessPieces.OfType<King>().Count());

            Assert.True(game.WhiteChessPieces.All(cp => cp.IsWhite));
            Assert.True(game.BlackChessPieces.All(cp => cp.IsBlack));

            var whiteRook1 = game.WhiteChessPieces.OfType<Rook>().First();
            var whiteRook2 = game.WhiteChessPieces.OfType<Rook>().Last();
            Assert.Equal((1, 1), (whiteRook1.X, whiteRook1.Y));
            Assert.Equal((8, 1), (whiteRook2.X, whiteRook2.Y));
            var blackRook1 = game.BlackChessPieces.OfType<Rook>().First();
            var blackRook2 = game.BlackChessPieces.OfType<Rook>().Last();
            Assert.Equal((1, 8), (blackRook1.X, blackRook1.Y));
            Assert.Equal((8, 8), (blackRook2.X, blackRook2.Y));

            var whiteKnight1 = game.WhiteChessPieces.OfType<Knight>().First();
            var whiteKnight2 = game.WhiteChessPieces.OfType<Knight>().Last();
            Assert.Equal((2, 1), (whiteKnight1.X, whiteKnight1.Y));
            Assert.Equal((7, 1), (whiteKnight2.X, whiteKnight2.Y));
            var blackKnight1 = game.BlackChessPieces.OfType<Knight>().First();
            var blackKnight2 = game.BlackChessPieces.OfType<Knight>().Last();
            Assert.Equal((2, 8), (blackKnight1.X, blackKnight1.Y));
            Assert.Equal((7, 8), (blackKnight2.X, blackKnight2.Y));

            var whiteBishop1 = game.WhiteChessPieces.OfType<Bishop>().First();
            var whiteBishop2 = game.WhiteChessPieces.OfType<Bishop>().Last();
            Assert.Equal((3, 1), (whiteBishop1.X, whiteBishop1.Y));
            Assert.Equal((6, 1), (whiteBishop2.X, whiteBishop2.Y));
            var blackBishop1 = game.BlackChessPieces.OfType<Bishop>().First();
            var blackBishop2 = game.BlackChessPieces.OfType<Bishop>().Last();
            Assert.Equal((3, 8), (blackBishop1.X, blackBishop1.Y));
            Assert.Equal((6, 8), (blackBishop2.X, blackBishop2.Y));

            var whiteQueen = game.WhiteChessPieces.OfType<Queen>().First();
            Assert.Equal((4, 1), (whiteQueen.X, whiteQueen.Y));

            var blackQueen = game.BlackChessPieces.OfType<Queen>().First();
            Assert.Equal((4, 8), (blackQueen.X, blackQueen.Y));

            var whiteKing = game.WhiteChessPieces.OfType<King>().First();
            Assert.Equal((5, 1), (whiteKing.X, whiteKing.Y));

            var blackKing = game.BlackChessPieces.OfType<King>().First();
            Assert.Equal((5, 8), (blackKing.X, blackKing.Y));
        }

        [Fact]
        public void GetHistoryTest1()
        {
            var game = Game.Create();

            var whiteRook1 = game.WhiteChessPieces.OfType<Rook>().First();
            var whiteRook2 = game.WhiteChessPieces.OfType<Rook>().Last();
            var blackRook1 = game.BlackChessPieces.OfType<Rook>().First();
            var blackRook2 = game.BlackChessPieces.OfType<Rook>().Last();
            var whiteKnight1 = game.WhiteChessPieces.OfType<Knight>().First();
            var whiteKnight2 = game.WhiteChessPieces.OfType<Knight>().Last();
            var blackKnight1 = game.BlackChessPieces.OfType<Knight>().First();
            var blackKnight2 = game.BlackChessPieces.OfType<Knight>().Last();
            var whiteBishop1 = game.WhiteChessPieces.OfType<Bishop>().First();
            var whiteBishop2 = game.WhiteChessPieces.OfType<Bishop>().Last();
            var blackBishop1 = game.BlackChessPieces.OfType<Bishop>().First();
            var blackBishop2 = game.BlackChessPieces.OfType<Bishop>().Last();
            var whiteQueen = game.WhiteChessPieces.OfType<Queen>().First();
            var blackQueen = game.BlackChessPieces.OfType<Queen>().First();
            var whiteKing = game.WhiteChessPieces.OfType<King>().First();
            var blackKing = game.BlackChessPieces.OfType<King>().First();

            Assert.Single(game.GetHistory(whiteRook1));
            Assert.Single(game.GetHistory(whiteRook2));
            Assert.Single(game.GetHistory(whiteKnight1));
            Assert.Single(game.GetHistory(whiteKnight2));
            Assert.Single(game.GetHistory(whiteBishop1));
            Assert.Single(game.GetHistory(whiteBishop2));
            Assert.Single(game.GetHistory(whiteQueen));
            Assert.Single(game.GetHistory(whiteKing));

            Assert.Single(game.GetHistory(blackRook1));
            Assert.Single(game.GetHistory(blackRook2));
            Assert.Single(game.GetHistory(blackKnight1));
            Assert.Single(game.GetHistory(blackKnight2));
            Assert.Single(game.GetHistory(blackBishop1));
            Assert.Single(game.GetHistory(blackBishop2));
            Assert.Single(game.GetHistory(blackQueen));
            Assert.Single(game.GetHistory(blackKing));
        }

        [Fact]
        public void GetHistoryTest2()
        {
            var game = Game.Create();

            var whiteRook1 = game.WhiteChessPieces.OfType<Rook>().First();
            var whiteRook2 = game.WhiteChessPieces.OfType<Rook>().Last();
            var blackRook1 = game.BlackChessPieces.OfType<Rook>().First();
            var blackRook2 = game.BlackChessPieces.OfType<Rook>().Last();
            var whiteKnight1 = game.WhiteChessPieces.OfType<Knight>().First();
            var whiteKnight2 = game.WhiteChessPieces.OfType<Knight>().Last();
            var blackKnight1 = game.BlackChessPieces.OfType<Knight>().First();
            var blackKnight2 = game.BlackChessPieces.OfType<Knight>().Last();
            var whiteBishop1 = game.WhiteChessPieces.OfType<Bishop>().First();
            var whiteBishop2 = game.WhiteChessPieces.OfType<Bishop>().Last();
            var blackBishop1 = game.BlackChessPieces.OfType<Bishop>().First();
            var blackBishop2 = game.BlackChessPieces.OfType<Bishop>().Last();
            var whiteQueen = game.WhiteChessPieces.OfType<Queen>().First();
            var blackQueen = game.BlackChessPieces.OfType<Queen>().First();
            var whiteKing = game.WhiteChessPieces.OfType<King>().First();
            var blackKing = game.BlackChessPieces.OfType<King>().First();

            Assert.Equal((1, 1), (game.GetHistory(whiteRook1).First().X, game.GetHistory(whiteRook1).First().Y));
            Assert.Equal((8, 1), (game.GetHistory(whiteRook2).First().X, game.GetHistory(whiteRook2).First().Y));
            Assert.Equal((2, 1), (game.GetHistory(whiteKnight1).First().X, game.GetHistory(whiteKnight1).First().Y));
            Assert.Equal((7, 1), (game.GetHistory(whiteKnight2).First().X, game.GetHistory(whiteKnight2).First().Y));
            Assert.Equal((3, 1), (game.GetHistory(whiteBishop1).First().X, game.GetHistory(whiteBishop1).First().Y));
            Assert.Equal((6, 1), (game.GetHistory(whiteBishop2).First().X, game.GetHistory(whiteBishop2).First().Y));
            Assert.Equal((4, 1), (game.GetHistory(whiteQueen).First().X, game.GetHistory(whiteQueen).First().Y));
            Assert.Equal((5, 1), (game.GetHistory(whiteKing).First().X, game.GetHistory(whiteKing).First().Y));

            Assert.Equal((1, 8), (game.GetHistory(blackRook1).First().X, game.GetHistory(blackRook1).First().Y));
            Assert.Equal((8, 8), (game.GetHistory(blackRook2).First().X, game.GetHistory(blackRook2).First().Y));
            Assert.Equal((2, 8), (game.GetHistory(blackKnight1).First().X, game.GetHistory(blackKnight1).First().Y));
            Assert.Equal((7, 8), (game.GetHistory(blackKnight2).First().X, game.GetHistory(blackKnight2).First().Y));
            Assert.Equal((3, 8), (game.GetHistory(blackBishop1).First().X, game.GetHistory(blackBishop1).First().Y));
            Assert.Equal((6, 8), (game.GetHistory(blackBishop2).First().X, game.GetHistory(blackBishop2).First().Y));
            Assert.Equal((4, 8), (game.GetHistory(blackQueen).First().X, game.GetHistory(blackQueen).First().Y));
            Assert.Equal((5, 8), (game.GetHistory(blackKing).First().X, game.GetHistory(blackKing).First().Y));
        }

        [Fact]
        public void GetHistoryTest3()
        {
            var game = Game.Create();

            var rook = game.WhiteChessPieces.OfType<Rook>().First();
            game = game.Move(rook, 5, 3);

            Assert.Equal(2, game.GetHistory(rook).Count);
            Assert.Equal((1, 1), (game.GetHistory(rook).First().X, game.GetHistory(rook).First().Y));
            Assert.Equal((5, 3), (game.GetHistory(rook).Last().X, game.GetHistory(rook).Last().Y));
        }

        [Fact]
        public void GetFieldTest()
        {
            var game = Game.Create();

            var chessPiece = game.GetField(4, 7);
            Assert.True(chessPiece is Pawn);
            Assert.True(chessPiece.IsBlack);
            Assert.Equal((4, 7), (chessPiece.X, chessPiece.Y));
        }

        [Fact]
        public void GetFieldTestWhitePawns()
        {
            var game = Game.Create();

            for (var x = 1; x <= 8; x++)
            {
                var chessPiece = game.GetField(x, 2);
                Assert.True(chessPiece is Pawn);
                Assert.True(chessPiece.IsWhite);
                Assert.Equal((x, 2), (chessPiece.X, chessPiece.Y));
            }
        }

        [Fact]
        public void GetFieldTestBlackPawns()
        {
            var game = Game.Create();

            for (var x = 1; x <= 8; x++)
            {
                var chessPiece = game.GetField(x, 7);
                Assert.True(chessPiece is Pawn);
                Assert.True(chessPiece.IsBlack);
                Assert.Equal((x, 7), (chessPiece.X, chessPiece.Y));
            }
        }

        [Fact]
        public void MoveTest()
        {
            var game = Game.Create();
            var whiteKnight = game.WhiteChessPieces.OfType<Knight>().First();

            game = game.Move(whiteKnight, 4, 8);

            var movedKnight = game.GetField(4, 8);
            Assert.Equal(whiteKnight.Id, movedKnight.Id);
            Assert.Equal(4, movedKnight.X);
            Assert.Equal(8, movedKnight.Y);
            Assert.False(game.BlackChessPieces.OfType<Queen>().Any());
        }

        [Fact]
        public void MoveAndReplaceByQueenTest()
        {
            var pawn = new Pawn(ChessId.pawn_white_of_bishop_of_queen, 5, 5);
            var game = Game.Create(pawn);

            game = game.MoveAndReplaceByQueen(pawn, 5, 6);

            Assert.DoesNotContain(game.ChessPieces, cp => cp is Pawn);
            Assert.Contains(game.ChessPieces, cp => cp is Queen);
        }

        [Fact]
        public void MoveAndReplaceByKnightTest()
        {
            var pawn = new Pawn(ChessId.pawn_white_of_bishop_of_queen, 5, 5);
            var game = Game.Create(new List<ChessPiece> { pawn });

            game = game.MoveAndReplaceByKnight(pawn, 5, 6);

            Assert.DoesNotContain(game.ChessPieces, cp => cp is Pawn);
            Assert.Contains(game.ChessPieces, cp => cp is Knight);
        }
    }
}