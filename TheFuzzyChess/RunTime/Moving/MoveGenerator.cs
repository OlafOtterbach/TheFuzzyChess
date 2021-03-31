using FuzzyChess.Chess;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyChess.RunTime.Moving
{
    public class MoveGenerator : IMoveGenerator
    {
        public IEnumerable<Move> NextMoves(IEnumerable<ChessPiece> chessPieces, Game game)
        {
            return chessPieces.SelectMany(chessPiece => NextMoves(chessPiece, game));
        }

        private IEnumerable<Move> NextMoves(ChessPiece chessPiece, Game game)
        {
            switch (chessPiece)
            {
                case King king: return NextMoves(king, game);
                case Queen queen: return NextMoves(queen, game);
                case Rook rock: return NextMoves(rock, game);
                case Bishop bishop: return NextMoves(bishop, game);
                case Knight knight: return NextMoves(knight, game);
                case Pawn pawn: return NextMoves(pawn, game);
                default: return new List<Move>();
            }
        }


        public IEnumerable<Move> NextMoves(Queen queen, Game game)
        {
            var moves = NextLinearMoves(queen, game, 1, 1)
                .Concat(NextLinearMoves(queen, game, 1, -1))
                .Concat(NextLinearMoves(queen, game, -1, 1))
                .Concat(NextLinearMoves(queen, game, -1, -1))
                .Concat(NextLinearMoves(queen, game, 1, 0))
                .Concat(NextLinearMoves(queen, game, 0, 1))
                .Concat(NextLinearMoves(queen, game, -1, 0))
                .Concat(NextLinearMoves(queen, game, 0, -1));

            return moves;
        }




        public IEnumerable<Move> NextMoves(Bishop bishop, Game game)
        {
            var moves = NextLinearMoves(bishop, game, 1, 1)
                .Concat(NextLinearMoves(bishop, game, 1, -1))
                .Concat(NextLinearMoves(bishop, game, -1, 1))
                .Concat(NextLinearMoves(bishop, game, -1, -1));
            return moves;
        }




        public IEnumerable<Move> NextMoves(Rook rook, Game game)
        {
            var moves = NextLinearMoves(rook, game, 0, 1)
                            .Concat(NextLinearMoves(rook, game, 1, 0))
                            .Concat(NextLinearMoves(rook, game, -1, 0))
                            .Concat(NextLinearMoves(rook, game, 0, -1)).ToList();
            return moves;
        }

        private enum FieldState { unreachable, reachable, occupied }

        private IEnumerable<Move> NextLinearMoves(ChessPiece piece, Game game, int stepX, int stepY)
        {
            var fromX = piece.X;
            var fromY = piece.Y;
            var toX = fromX + stepX;
            var toY = fromY + stepY;

            Move move;
            while (true)
            {
                FieldState state = TryCreateLinearMove(piece, fromX, fromY, toX, toY, game, out move);
                if (state == FieldState.reachable || state == FieldState.occupied)
                {
                    yield return move;
                    toX += stepX;
                    toY += stepY;
                }
                if (state == FieldState.unreachable || state == FieldState.occupied)
                {
                    break;
                }
            }
        }

        private FieldState TryCreateLinearMove(ChessPiece chessPiece, int fromX, int fromY, int toX, int toY, Game game, out Move move)
        {
            if (toX < 1 || toY < 1 || toX > 8 || toY > 8)
            {
                move = null;
                return FieldState.unreachable;
            }

            var field = game.GetField(toX, toY);
            if (field == null)
            {
                move = new Move(chessPiece, fromX, fromY, toX, toY);
                return FieldState.reachable;
            }
            else if (field.IsBlack != chessPiece.IsBlack)
            {
                move = new Move(chessPiece, fromX, fromY, toX, toY);
                return FieldState.occupied;
            }
            else
            {
                move = null;
                return FieldState.unreachable;
            }
        }



        public IEnumerable<Move> NextMoves(Knight knight, Game game)
        {
            Move move;
            if (TryCreateMove(knight, knight.X + 2, knight.Y - 1, game, out move)) yield return move;
            if (TryCreateMove(knight, knight.X + 2, knight.Y + 1, game, out move)) yield return move;

            if (TryCreateMove(knight, knight.X - 2, knight.Y - 1, game, out move)) yield return move;
            if (TryCreateMove(knight, knight.X - 2, knight.Y + 1, game, out move)) yield return move;

            if (TryCreateMove(knight, knight.X + 1, knight.Y - 2, game, out move)) yield return move;
            if (TryCreateMove(knight, knight.X + 1, knight.Y + 2, game, out move)) yield return move;

            if (TryCreateMove(knight, knight.X - 1, knight.Y - 2, game, out move)) yield return move;
            if (TryCreateMove(knight, knight.X - 1, knight.Y + 2, game, out move)) yield return move;
        }




        public IEnumerable<Move> NextMoves(King king, Game game)
        {
            Move move;
            if (TryCreateMove(king, king.X - 1, king.Y, game, out move)) yield return move;
            if (TryCreateMove(king, king.X + 1, king.Y, game, out move)) yield return move;
            if (TryCreateMove(king, king.X, king.Y - 1, game, out move)) yield return move;
            if (TryCreateMove(king, king.X, king.Y + 1, game, out move)) yield return move;

            if (TryCreateMove(king, king.X - 1, king.Y - 1, game, out move)) yield return move;
            if (TryCreateMove(king, king.X - 1, king.Y + 1, game, out move)) yield return move;
            if (TryCreateMove(king, king.X + 1, king.Y - 1, game, out move)) yield return move;
            if (TryCreateMove(king, king.X + 1, king.Y + 1, game, out move)) yield return move;
        }




        public IEnumerable<Move> NextMoves(Pawn pawn, Game game)
            => pawn.IsWhite ? NextMovesWhitePawn(pawn, game) : NextMovesBlackPawn(pawn, game);

        private IEnumerable<Move> NextMovesWhitePawn(Pawn pawn, Game game)
        {
            var moves = new List<Move>();

            if (pawn.Y == 8) return moves;

            if (CanCreatePawnMove(pawn, pawn.X, pawn.Y + 1, game, false))
                moves.AddRange(CreatePawnMoves(pawn, pawn.X, pawn.Y + 1));

            if (pawn.Y == 2 && CanCreatePawnMove(pawn, pawn.X, pawn.Y + 2, game, false))
                moves.AddRange(CreatePawnMoves(pawn, pawn.X, pawn.Y + 2));

            if (CanPawnBeatAnEnemy(pawn.IsWhite, pawn.X - 1, pawn.Y + 1, game)
                && CanCreatePawnMove(pawn, pawn.X - 1, pawn.Y + 1, game, true))
                moves.AddRange(CreatePawnMoves(pawn, pawn.X - 1, pawn.Y + 1));

            if (CanPawnBeatAnEnemy(pawn.IsWhite, pawn.X + 1, pawn.Y + 1, game)
                && CanCreatePawnMove(pawn, pawn.X + 1, pawn.Y + 1, game, true))
                moves.AddRange(CreatePawnMoves(pawn, pawn.X + 1, pawn.Y + 1));

            return moves;
        }

        private IEnumerable<Move> NextMovesBlackPawn(Pawn pawn, Game game)
        {
            var moves = new List<Move>();

            if (pawn.Y == 1) return moves;

            if (CanCreatePawnMove(pawn, pawn.X, pawn.Y - 1, game, false))
                moves.AddRange(CreatePawnMoves(pawn, pawn.X, pawn.Y - 1));

            if (pawn.Y == 7 && CanCreatePawnMove(pawn, pawn.X, pawn.Y - 2, game, false))
                moves.AddRange(CreatePawnMoves(pawn, pawn.X, pawn.Y - 2));

            if (CanPawnBeatAnEnemy(pawn.IsWhite, pawn.X - 1, pawn.Y - 1, game)
                && CanCreatePawnMove(pawn, pawn.X - 1, pawn.Y - 1, game, true))
                moves.AddRange(CreatePawnMoves(pawn, pawn.X - 1, pawn.Y - 1));

            if (CanPawnBeatAnEnemy(pawn.IsWhite, pawn.X + 1, pawn.Y - 1, game)
                && CanCreatePawnMove(pawn, pawn.X + 1, pawn.Y - 1, game, true))
                moves.AddRange(CreatePawnMoves(pawn, pawn.X + 1, pawn.Y - 1));

            return moves;
        }

        private bool CanPawnBeatAnEnemy(bool isWhite, int x, int y, Game game)
        {
            var result = (game.GetField(x, y)?.IsWhite ?? isWhite) != isWhite;
            return result;
        }

        private bool CanCreatePawnMove(Pawn pawn, int toX, int toY, Game game, bool canBeat)
        {
            if (toX < 1 || toY < 1 || toX > 8 || toY > 8)
            {
                return false;
            }

            var field = game.GetField(toX, toY);
            if (field == null || (field.IsWhite != pawn.IsWhite && canBeat))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private IEnumerable<Move> CreatePawnMoves(Pawn pawn, int toX, int toY)
        {
            if ((pawn.IsBlack && toY == 1) || (pawn.IsWhite && toY == 8))
            {
                yield return new MoveAndChangePawnToQueen(pawn, pawn.X, pawn.Y, toX, toY);
                yield return new MoveAndChangePawnToKnight(pawn, pawn.X, pawn.Y, toX, toY);
            }
            else
            {
                yield return new Move(pawn, pawn.X, pawn.Y, toX, toY);
            }
        }




        private bool TryCreateMove(ChessPiece chessPiece, int toX, int toY, Game game, out Move move)
        {
            return TryCreateMove(chessPiece, chessPiece.X, chessPiece.Y, toX, toY, game, true, out move);
        }

        private bool TryCreateMove(ChessPiece chessPiece, int fromX, int fromY, int toX, int toY, Game game, out Move move)
        {
            return TryCreateMove(chessPiece, fromX, fromY, toX, toY, game, true, out move);
        }

        private bool TryCreateMove(ChessPiece chessPiece, int fromX, int fromY, int toX, int toY, Game game, bool canBeat, out Move move)
        {
            if (toX < 1 || toY < 1 || toX > 8 || toY > 8)
            {
                move = null;
                return false;
            }

            var field = game.GetField(toX, toY);
            if (field == null || (field.IsBlack != chessPiece.IsBlack && canBeat))
            {
                move = new Move(chessPiece, fromX, fromY, toX, toY);
                return true;
            }
            else
            {
                move = null;
                return false;
            }
        }
    }
}
