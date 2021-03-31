namespace FuzzyChess.Chess
{
    public enum ChessId
    {
        invalid = 0,
        rook_white_of_queen = 1,
        knight_white_of_queen = 2,
        bishop_white_of_queen = 3,
        queen_white = 4,
        king_white = 5,
        bishop_white_of_king = 6,
        knight_white_of_king = 7,
        rook_white_of_king = 8,
        pawn_white_of_rook_of_queen = 9,
        pawn_white_of_knight_of_queen = 10,
        pawn_white_of_bishop_of_queen = 11,
        pawn_white_of_queen = 12,
        pawn_white_of_king = 13,
        pawn_white_of_bishop_of_king = 14,
        pawn_white_of_knight_of_king = 15,
        pawn_white_of_rook_of_king = 16,

        rook_black_of_queen = 17,
        knight_black_of_queen = 18,
        bishop_black_of_queen = 19,
        queen_black = 20,
        king_black = 21,
        bishop_black_of_king = 22,
        knight_black_of_king = 23,
        rook_black_of_king = 24,
        pawn_black_of_rook_of_queen = 25,
        pawn_black_of_knight_of_queen = 26,
        pawn_black_of_bishop_of_queen = 27,
        pawn_black_of_queen = 28,
        pawn_black_of_king = 29,
        pawn_black_of_bishop_of_king = 30,
        pawn_black_of_knight_of_king = 31,
        pawn_black_of_rook_of_king = 32,

        queen_white_of_pawn_of_rook_of_queen = 33,
        queen_white_of_pawn_of_knight_of_queen = 34,
        queen_white_of_pawn_of_bishop_of_queen = 35,
        queen_white_of_pawn_of_queen = 36,
        queen_white_of_pawn_of_king = 37,
        queen_white_of_pawn_of_bishop_of_king = 38,
        queen_white_of_pawn_of_knight_of_king = 39,
        queen_white_of_pawn_of_rook_of_king = 40,

        queen_black_of_pawn_of_rook_of_queen = 41,
        queen_black_of_pawn_of_knight_of_queen = 42,
        queen_black_of_pawn_of_bishop_of_queen = 43,
        queen_black_of_pawn_of_queen = 44,
        queen_black_of_pawn_of_king = 45,
        queen_black_of_pawn_of_bishop_of_king = 46,
        queen_black_of_pawn_of_knight_of_king = 47,
        queen_black_of_pawn_of_rook_of_king = 48,

        knight_white_of_pawn_of_rook_of_queen = 49,
        knight_white_of_pawn_of_knight_of_queen = 50,
        knight_white_of_pawn_of_bishop_of_queen = 51,
        knight_white_of_pawn_of_queen = 52,
        knight_white_of_pawn_of_king = 53,
        knight_white_of_pawn_of_bishop_of_king = 54,
        knight_white_of_pawn_of_knight_of_king = 55,
        knight_white_of_pawn_of_rook_of_king = 56,
        knight_black_of_pawn_of_rook_of_queen = 57,
        knight_black_of_pawn_of_knight_of_queen = 58,
        knight_black_of_pawn_of_bishop_of_queen = 59,
        knight_black_of_pawn_of_queen = 60,
        knight_black_of_pawn_of_king = 61,
        knight_black_of_pawn_of_bishop_of_king = 62,
        knight_black_of_pawn_of_knight_of_king = 63,
        knight_black_of_pawn_of_rook_of_king = 64,
    }

    public static class ChessIdExtensions
    {
        public static bool IsWhite(this ChessId id)
             => id == ChessId.king_white ||
                id == ChessId.queen_white ||
                id == ChessId.rook_white_of_king ||
                id == ChessId.rook_white_of_queen ||
                id == ChessId.knight_white_of_king ||
                id == ChessId.knight_white_of_queen ||
                id == ChessId.bishop_white_of_king ||
                id == ChessId.bishop_white_of_queen ||
                id == ChessId.pawn_white_of_king ||
                id == ChessId.pawn_white_of_queen ||
                id == ChessId.pawn_white_of_rook_of_king ||
                id == ChessId.pawn_white_of_rook_of_queen ||
                id == ChessId.pawn_white_of_knight_of_king ||
                id == ChessId.pawn_white_of_knight_of_queen ||
                id == ChessId.pawn_white_of_bishop_of_king ||
                id == ChessId.pawn_white_of_bishop_of_queen;

        public static bool IsBlack(this ChessId id)
             => id == ChessId.king_black ||
                id == ChessId.queen_black ||
                id == ChessId.rook_black_of_king ||
                id == ChessId.rook_black_of_queen ||
                id == ChessId.knight_black_of_king ||
                id == ChessId.knight_black_of_queen ||
                id == ChessId.bishop_black_of_king ||
                id == ChessId.bishop_black_of_queen ||
                id == ChessId.pawn_black_of_king ||
                id == ChessId.pawn_black_of_queen ||
                id == ChessId.pawn_black_of_rook_of_king ||
                id == ChessId.pawn_black_of_rook_of_queen ||
                id == ChessId.pawn_black_of_knight_of_king ||
                id == ChessId.pawn_black_of_knight_of_queen ||
                id == ChessId.pawn_black_of_bishop_of_king ||
                id == ChessId.pawn_black_of_bishop_of_queen;

        public static bool IsPawn(this ChessId id)
            => id == ChessId.pawn_white_of_king ||
               id == ChessId.pawn_white_of_queen ||
               id == ChessId.pawn_white_of_bishop_of_king ||
               id == ChessId.pawn_white_of_bishop_of_queen ||
               id == ChessId.pawn_white_of_rook_of_king ||
               id == ChessId.pawn_white_of_rook_of_queen ||
               id == ChessId.pawn_white_of_knight_of_king ||
               id == ChessId.pawn_white_of_knight_of_queen ||
               id == ChessId.pawn_black_of_king ||
               id == ChessId.pawn_black_of_queen ||
               id == ChessId.pawn_black_of_bishop_of_king ||
               id == ChessId.pawn_black_of_bishop_of_queen ||
               id == ChessId.pawn_black_of_rook_of_king ||
               id == ChessId.pawn_black_of_rook_of_queen ||
               id == ChessId.pawn_black_of_knight_of_king ||
               id == ChessId.pawn_black_of_knight_of_queen;

        public static bool IsKing(this ChessId id)
            => id == ChessId.king_white ||
               id == ChessId.king_black;

        public static bool IsQueen(this ChessId id)
            => id == ChessId.queen_white ||
               id == ChessId.queen_black ||
               id == ChessId.queen_white_of_pawn_of_rook_of_queen ||
               id == ChessId.queen_white_of_pawn_of_knight_of_queen ||
               id == ChessId.queen_white_of_pawn_of_bishop_of_queen ||
               id == ChessId.queen_white_of_pawn_of_queen ||
               id == ChessId.queen_white_of_pawn_of_king ||
               id == ChessId.queen_white_of_pawn_of_bishop_of_king ||
               id == ChessId.queen_white_of_pawn_of_knight_of_king ||
               id == ChessId.queen_white_of_pawn_of_rook_of_king ||
               id == ChessId.queen_black_of_pawn_of_rook_of_queen ||
               id == ChessId.queen_black_of_pawn_of_knight_of_queen ||
               id == ChessId.queen_black_of_pawn_of_bishop_of_queen ||
               id == ChessId.queen_black_of_pawn_of_queen ||
               id == ChessId.queen_black_of_pawn_of_king ||
               id == ChessId.queen_black_of_pawn_of_bishop_of_king ||
               id == ChessId.queen_black_of_pawn_of_knight_of_king ||
               id == ChessId.queen_black_of_pawn_of_rook_of_king;

        public static bool IsBishop(this ChessId id)
            => id == ChessId.bishop_white_of_king ||
               id == ChessId.bishop_white_of_queen ||
               id == ChessId.bishop_black_of_king ||
               id == ChessId.bishop_black_of_queen;

        public static bool IsKnight(this ChessId id)
            => id == ChessId.knight_white_of_king ||
               id == ChessId.knight_white_of_queen ||
               id == ChessId.knight_black_of_king ||
               id == ChessId.knight_black_of_queen ||
               id == ChessId.knight_white_of_pawn_of_rook_of_queen ||
               id == ChessId.knight_white_of_pawn_of_knight_of_queen ||
               id == ChessId.knight_white_of_pawn_of_bishop_of_queen ||
               id == ChessId.knight_white_of_pawn_of_queen ||
               id == ChessId.knight_white_of_pawn_of_king ||
               id == ChessId.knight_white_of_pawn_of_bishop_of_king ||
               id == ChessId.knight_white_of_pawn_of_knight_of_king ||
               id == ChessId.knight_white_of_pawn_of_rook_of_king ||
               id == ChessId.knight_black_of_pawn_of_rook_of_queen ||
               id == ChessId.knight_black_of_pawn_of_knight_of_queen ||
               id == ChessId.knight_black_of_pawn_of_bishop_of_queen ||
               id == ChessId.knight_black_of_pawn_of_queen ||
               id == ChessId.knight_black_of_pawn_of_king ||
               id == ChessId.knight_black_of_pawn_of_bishop_of_king ||
               id == ChessId.knight_black_of_pawn_of_knight_of_king ||
               id == ChessId.knight_black_of_pawn_of_rook_of_king;

        public static bool IsRook(this ChessId id)
            => id == ChessId.rook_white_of_king ||
               id == ChessId.rook_white_of_queen ||
               id == ChessId.rook_black_of_king ||
               id == ChessId.rook_black_of_queen;

        public static int Value(this ChessId id)
        {
            if (id.IsPawn()) return 1;
            if (id.IsRook()) return 6;
            if (id.IsKnight()) return 3;
            if (id.IsBishop()) return 3;
            if (id.IsQueen()) return 9;
            if (id.IsKing()) return 10;
            return 0;
        }

        public static ChessId ReplaceByQueen(this ChessId id)
        {
            switch (id)
            {
                case ChessId.pawn_white_of_rook_of_queen: return ChessId.queen_white_of_pawn_of_rook_of_queen;
                case ChessId.pawn_white_of_knight_of_queen: return ChessId.queen_white_of_pawn_of_knight_of_queen;
                case ChessId.pawn_white_of_bishop_of_queen: return ChessId.queen_white_of_pawn_of_bishop_of_queen;
                case ChessId.pawn_white_of_queen: return ChessId.queen_white_of_pawn_of_queen;
                case ChessId.pawn_white_of_king: return ChessId.queen_white_of_pawn_of_king;
                case ChessId.pawn_white_of_bishop_of_king: return ChessId.queen_white_of_pawn_of_bishop_of_king;
                case ChessId.pawn_white_of_knight_of_king: return ChessId.queen_white_of_pawn_of_knight_of_king;
                case ChessId.pawn_white_of_rook_of_king: return ChessId.queen_white_of_pawn_of_rook_of_king;
                case ChessId.pawn_black_of_rook_of_queen: return ChessId.queen_black_of_pawn_of_rook_of_queen;
                case ChessId.pawn_black_of_knight_of_queen: return ChessId.queen_black_of_pawn_of_knight_of_queen;
                case ChessId.pawn_black_of_bishop_of_queen: return ChessId.queen_black_of_pawn_of_bishop_of_queen;
                case ChessId.pawn_black_of_queen: return ChessId.queen_black_of_pawn_of_queen;
                case ChessId.pawn_black_of_king: return ChessId.queen_black_of_pawn_of_king;
                case ChessId.pawn_black_of_bishop_of_king: return ChessId.queen_black_of_pawn_of_bishop_of_king;
                case ChessId.pawn_black_of_knight_of_king: return ChessId.queen_black_of_pawn_of_knight_of_king;
                case ChessId.pawn_black_of_rook_of_king: return ChessId.queen_black_of_pawn_of_rook_of_king;
                default: return ChessId.invalid;
            }
        }

        public static ChessId ReplaceByKnight(this ChessId id)
        {
            switch (id)
            {
                case ChessId.pawn_white_of_rook_of_queen: return ChessId.knight_white_of_pawn_of_rook_of_queen;
                case ChessId.pawn_white_of_knight_of_queen: return ChessId.knight_white_of_pawn_of_knight_of_queen;
                case ChessId.pawn_white_of_bishop_of_queen: return ChessId.knight_white_of_pawn_of_bishop_of_queen;
                case ChessId.pawn_white_of_queen: return ChessId.knight_white_of_pawn_of_queen;
                case ChessId.pawn_white_of_king: return ChessId.knight_white_of_pawn_of_king;
                case ChessId.pawn_white_of_bishop_of_king: return ChessId.knight_white_of_pawn_of_bishop_of_king;
                case ChessId.pawn_white_of_knight_of_king: return ChessId.knight_white_of_pawn_of_knight_of_king;
                case ChessId.pawn_white_of_rook_of_king: return ChessId.knight_white_of_pawn_of_rook_of_king;
                case ChessId.pawn_black_of_rook_of_queen: return ChessId.knight_black_of_pawn_of_rook_of_queen;
                case ChessId.pawn_black_of_knight_of_queen: return ChessId.knight_black_of_pawn_of_knight_of_queen;
                case ChessId.pawn_black_of_bishop_of_queen: return ChessId.knight_black_of_pawn_of_bishop_of_queen;
                case ChessId.pawn_black_of_queen: return ChessId.knight_black_of_pawn_of_queen;
                case ChessId.pawn_black_of_king: return ChessId.knight_black_of_pawn_of_king;
                case ChessId.pawn_black_of_bishop_of_king: return ChessId.knight_black_of_pawn_of_bishop_of_king;
                case ChessId.pawn_black_of_knight_of_king: return ChessId.knight_black_of_pawn_of_knight_of_king;
                case ChessId.pawn_black_of_rook_of_king: return ChessId.knight_black_of_pawn_of_rook_of_king;
                default: return ChessId.invalid;
            }
        }
    }
}



