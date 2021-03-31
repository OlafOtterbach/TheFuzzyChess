using FuzzyChess.Chess;

namespace FuzzyChess.RunTime.Evaluation
{
    public class ChessContext
    {
        public ChessPiece ChessPiece => Move.ChessPiece;
        public Move Move { get; set; }
        public Game GameBeforeMove { get; set; }
        public Game GameAfterMove { get; set; }

        public Move[] NextOpponentMoves { get; set; }

        public Move[] NextFriendMoves { get; set; }
    }
}
