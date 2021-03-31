using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using static FuzzyChess.Chess.ChessId;

namespace FuzzyChess.Chess
{
    public class Game
    {
        private Game(IEnumerable<ChessPiece> chessPieces, ImmutableDictionary<ChessId, ImmutableList<(int X, int Y, int Move)>> history, int currentMove)
        {
            CurrentMove = currentMove;

            ChessPieces = chessPieces.ToImmutableList();
            WhiteChessPieces = ChessPieces.Where(x => x.IsWhite).ToArray();
            BlackChessPieces = ChessPieces.Where(x => x.IsBlack).ToArray();

            PositionToId = ChessPieces.Select(cp => new KeyValuePair<(int, int), ChessPiece>((cp.X, cp.Y), cp)).ToImmutableDictionary();
            History = history;
        }

        public int CurrentMove { get; }

        private ImmutableDictionary<(int, int), ChessPiece> PositionToId { get; }

        private ImmutableDictionary<ChessId, ImmutableList<(int X, int Y, int Move)>> History { get; }

        public ImmutableList<ChessPiece> ChessPieces { get; }

        public ChessPiece[] WhiteChessPieces { get; }

        public ChessPiece[] BlackChessPieces { get; }

        public static Game Create(IEnumerable<ChessPiece> chessPieces)
        {
            var players = chessPieces.ToList();
            var historyBuilder = ImmutableDictionary.CreateBuilder<ChessId, ImmutableList<(int X, int Y, int Move)>>();
            players.ForEach(cp => historyBuilder.Add(cp.Id, new List<(int X, int Y, int Move)> { (cp.X, cp.Y, 1) }.ToImmutableList()));
            var history = historyBuilder.ToImmutable();

            return new Game(players, history, 1);
        }

        public static Game Create(params ChessPiece[] chessPieces)
        {
            var historyBuilder = ImmutableDictionary.CreateBuilder<ChessId, ImmutableList<(int X, int Y, int Move)>>();
            foreach (var chessPiece in chessPieces)
            {
                historyBuilder.Add(chessPiece.Id, new List<(int X, int Y, int Move)> { (chessPiece.X, chessPiece.Y, 1) }.ToImmutableList());
            }
            var history = historyBuilder.ToImmutable();

            return new Game(chessPieces, history, 1);
        }

        public static Game Create()
        {
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
            chessPieces.Add(new Pawn(pawn_white_of_knight_of_queen, 2, 2));
            chessPieces.Add(new Pawn(pawn_white_of_bishop_of_queen, 3, 2));
            chessPieces.Add(new Pawn(pawn_white_of_queen, 4, 2));
            chessPieces.Add(new Pawn(pawn_white_of_king, 5, 2));
            chessPieces.Add(new Pawn(pawn_white_of_bishop_of_king, 6, 2));
            chessPieces.Add(new Pawn(pawn_white_of_knight_of_king, 7, 2));
            chessPieces.Add(new Pawn(pawn_white_of_rook_of_king, 8, 2));

            chessPieces.Add(new Rook(rook_black_of_queen, 1, 8));
            chessPieces.Add(new Knight(knight_black_of_queen, 2, 8));
            chessPieces.Add(new Bishop(bishop_black_of_queen, 3, 8));
            chessPieces.Add(new Queen(queen_black, 4, 8));
            chessPieces.Add(new King(king_black, 5, 8));
            chessPieces.Add(new Bishop(bishop_black_of_king, 6, 8));
            chessPieces.Add(new Knight(knight_black_of_king, 7, 8));
            chessPieces.Add(new Rook(rook_black_of_king, 8, 8));
            chessPieces.Add(new Pawn(pawn_black_of_rook_of_queen, 1, 7));
            chessPieces.Add(new Pawn(pawn_black_of_knight_of_queen, 2, 7));
            chessPieces.Add(new Pawn(pawn_black_of_bishop_of_queen, 3, 7));
            chessPieces.Add(new Pawn(pawn_black_of_queen, 4, 7));
            chessPieces.Add(new Pawn(pawn_black_of_king, 5, 7));
            chessPieces.Add(new Pawn(pawn_black_of_bishop_of_king, 6, 7));
            chessPieces.Add(new Pawn(pawn_black_of_knight_of_king, 7, 7));
            chessPieces.Add(new Pawn(pawn_black_of_rook_of_king, 8, 7));

            var historyBuilder = ImmutableDictionary.CreateBuilder<ChessId, ImmutableList<(int X, int Y, int Move)>>();
            chessPieces.ForEach(cp => historyBuilder.Add(cp.Id, new List<(int X, int Y, int Move)> { (cp.X, cp.Y, 1) }.ToImmutableList()));
            var history = historyBuilder.ToImmutable();

            return new Game(chessPieces, history, 1);
        }

        public bool WhiteWins => BlackChessPieces.All(x => !x.IsKing);

        public bool BlackWins => WhiteChessPieces.All(x => !x.IsKing);

        public ChessPiece GetField(int x, int y)
        {
            var fieldContent = PositionToId.TryGetValue((x, y), out ChessPiece chessPiece) ? chessPiece : null;
            return fieldContent;
        }

        public bool IsEmptyField(int x, int y)
        {
            var fieldContent = PositionToId.TryGetValue((x, y), out ChessPiece chessPiece) ? chessPiece : null;
            return fieldContent == null;
        }

        public ImmutableList<(int X, int Y, int Move)> GetHistory(ChessPiece chessPiece)
        {
            return History.TryGetValue(chessPiece.Id, out ImmutableList<(int X, int Y, int Move)> history) ? history : ImmutableList<(int X, int Y, int Move)>.Empty;
        }

        public Game Move(ChessPiece chessPiece, int x, int y)
        {
            chessPiece = ChessPieces.First(x => x.Id == chessPiece.Id);

            // Remove figure
            var chessPieces = ChessPieces;
            if (PositionToId.ContainsKey((x, y)))
            {
                chessPieces = chessPieces.Remove(PositionToId[(x, y)]);
            }

            // Set new position
            var newFigure = chessPiece.Copy(x, y);
            chessPieces = chessPieces.Replace(chessPiece, newFigure);

            // Add Position to History
            var history = History.SetItem(newFigure.Id, History[newFigure.Id].Add((x, y, CurrentMove + 1)));

            return new Game(chessPieces, history, CurrentMove + 1);
        }

        public Game MoveAndReplaceByQueen(Pawn pawn, int x, int y)
        {
            var chessPiece = ChessPieces.First(x => x.Id == pawn.Id);

            // Set new position, field is empty
            var queen = new Queen(pawn.Id.ReplaceByQueen(), x, y);
            var chessPieces = ChessPieces.Replace(chessPiece, queen);

            // Add Position to History
            var history = History.Add(queen.Id, new List<(int X, int Y, int Move)> { (x, y, CurrentMove + 1) }.ToImmutableList());
            return new Game(chessPieces, history, CurrentMove + 1);
        }

        public Game MoveAndReplaceByKnight(Pawn pawn, int x, int y)
        {
            var chessPiece = ChessPieces.First(x => x.Id == pawn.Id);

            // Set new position, field is empty
            var knight = new Knight(pawn.Id.ReplaceByKnight(), x, y);
            var chessPieces = ChessPieces.Replace(chessPiece, knight);

            // Add Position to History
            var history = History.Add(knight.Id, new List<(int X, int Y, int Move)> { (x, y, CurrentMove + 1) }.ToImmutableList());

            return new Game(chessPieces, history, CurrentMove + 1);
        }
    }
}