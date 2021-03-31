using FuzzyChess.Chess;
using System;

namespace FuzzyChess.Tests.Helpers
{
    public static class EnumExtensions
    {
        public static int ToInt(this ChessId chessId) => (int) chessId;

        public static ChessId ToChessId(this int value) 
        {
            if(Enum.IsDefined(typeof(ChessId), value))
            {
                return (ChessId)value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
