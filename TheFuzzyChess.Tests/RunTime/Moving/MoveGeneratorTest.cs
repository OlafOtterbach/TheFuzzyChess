using FuzzyChess.Chess;
using FuzzyChess.RunTime.Moving;
using FuzzyChess.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static FuzzyChess.Chess.ChessId;

namespace FuzzyChess.Tests.RunTime.Moving
{
    public class MoveGeneratorTest
    {
        [Fact]
        public void SetFieldTest()
        {
            var game = Game.Create();
            var blackPawn = game.BlackChessPieces.OfType<Pawn>().Skip(5).First();
            var whitePawn = game.WhiteChessPieces.OfType<Pawn>().Skip(4).First();
            game.Move(whitePawn, 4, 4);
            game.Move(blackPawn, 5, 5);

            var moveGenerator = new MoveGenerator();
            var moves = moveGenerator.NextMoves(blackPawn, game).ToList();

            Assert.Equal(2, moves.Count);
        }

        [Fact]
        public void BishopTest1()
        {
            var chessPieces = new List<ChessPiece>();
            for (var i = 1; i <= 8; i++)
            {
                chessPieces.Add(new Pawn((i + ChessId.pawn_black_of_rook_of_queen.ToInt()).ToChessId(), i, i));
            }
            var bishop = new Bishop(ChessId.bishop_black_of_king, 8, 2);
            chessPieces.Add(bishop);

            var game = Game.Create(chessPieces);

            var moveGenerator = new MoveGenerator();
            var moves = moveGenerator.NextMoves(bishop, game).ToList();

            Assert.True(moves.All(m => m.ToX > m.ToY));
        }

        [Fact]
        public void BishopTest2()
        {
            var chessPieces = new List<ChessPiece>();
            for (var i = 1; i <= 8; i++)
            {
                chessPieces.Add(new Pawn((i + ChessId.pawn_white_of_rook_of_queen.ToInt()).ToChessId(), i, i));
            }
            var bishop = new Bishop(ChessId.bishop_white_of_king, 7, 1);
            chessPieces.Add(bishop);

            var game = Game.Create(chessPieces);

            var moveGenerator = new MoveGenerator();
            var moves = moveGenerator.NextMoves(bishop, game).ToList();

            Assert.True(moves.All(m => m.ToX > m.ToY));
        }

        [Fact]
        public void BishopTest3()
        {
            var chessPieces = new List<ChessPiece>();
            for (var i = 1; i <= 8; i++)
            {
                chessPieces.Add(new Pawn((i + ChessId.pawn_white_of_rook_of_queen.ToInt()).ToChessId(), i, i));
            }
            var bishop = new Bishop(ChessId.bishop_white_of_king, 7, 1);
            chessPieces.Add(bishop);

            var game = Game.Create(chessPieces);

            var moveGenerator = new MoveGenerator();
            var moves = moveGenerator.NextMoves(bishop, game).ToList();

            Assert.True(moves.All(m => m.ToX >= m.ToY));
        }

        [Fact]
        public void BishopTest4()
        {
            var chessPieces = new List<ChessPiece>();
            for (var i = 1; i <= 8; i++)
            {
                chessPieces.Add(new Pawn((i + ChessId.pawn_white_of_rook_of_queen.ToInt()).ToChessId(), i, i));
            }
            var bishop = new Bishop(ChessId.bishop_white_of_king, 8, 1);
            chessPieces.Add(bishop);

            var game = Game.Create(chessPieces);

            var moveGenerator = new MoveGenerator();
            var moves = moveGenerator.NextMoves(bishop, game).ToList();

            Assert.True(moves.Any(m => m.ToX < m.ToY));
        }

        [Fact]
        public void PawnTest1()
        {
            // Arrange
            var chessPieces = new List<ChessPiece>();

            chessPieces.Add(new Rook(rook_white_of_queen, 1, 1));
            chessPieces.Add(new Knight(knight_white_of_queen, 2, 1));
            chessPieces.Add(new Bishop(bishop_white_of_queen, 3, 1));
            chessPieces.Add(new Queen(queen_white, 4, 1));
            chessPieces.Add(new King(king_white, 5, 1));
            chessPieces.Add(new Bishop(bishop_white_of_king, 6, 1));
            chessPieces.Add(new Knight(knight_white_of_king, 7, 1));
            chessPieces.Add(new Rook(rook_white_of_king, 8, 1));
            chessPieces.Add(new Pawn(pawn_white_of_rook_of_queen, 1, 2));

            chessPieces.Add(new Pawn(pawn_white_of_knight_of_queen, 2, 4));

            chessPieces.Add(new Pawn(pawn_white_of_bishop_of_queen, 3, 2));
            chessPieces.Add(new Pawn(pawn_white_of_queen, 4, 2));
            chessPieces.Add(new Pawn(pawn_white_of_king, 5, 2));
            chessPieces.Add(new Pawn(pawn_white_of_bishop_of_king, 6, 2));
            chessPieces.Add(new Pawn(pawn_white_of_knight_of_king, 7, 2));
            chessPieces.Add(new Pawn(pawn_white_of_rook_of_king, 8, 2));

            var pawn = new Pawn(pawn_black_of_knight_of_queen, 2, 5);
            chessPieces.Add(pawn);
            var game = Game.Create(chessPieces);
            var moveGenerator = new MoveGenerator();

            // Act
            var moves = moveGenerator.NextMoves(pawn, game).ToList();

            // Assert
            Assert.Empty(moves);
        }
    }
}
