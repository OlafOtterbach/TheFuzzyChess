using FuzzyChess.Chess;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace FuzzyChess
{
    public static class Output
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct FontInfoEx
        {
            internal int cbSize;
            internal int FontIndex;
            internal short FontWidth;
            public short FontSize;
            public int FontFamily;
            public int FontWeight;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string FontName;
        }

        public static void Init()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.SetWindowSize(40, 12);
            SetConsoleFont();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Clear();
        }

        public static void Clear()
        {
            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 8; x++)
                {
                    Console.BackgroundColor = GetBackground(x, y);
                    Console.SetCursorPosition(x * 2, y); Console.Write("  ");
                }
            }
        }

        public static void Print(Game game)
        {
            Clear();
            game.ChessPieces.ToList().ForEach(figure => Print(figure));
        }

        public static void PrintMessage(string text)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, 8);
            Console.Write(text);
        }

        private static void Print(ChessPiece chessPiece)
        {
            var x = chessPiece.X;
            var y = chessPiece.Y;

            var text = GetSymbolText(chessPiece);

            Print(text, x, y, chessPiece.IsWhite);
        }

        private static string GetSymbolText(ChessPiece chessPiece)
        {
            switch (chessPiece)
            {
                case King king: return "\u265A ";
                case Queen queen: return "\u265B ";
                case Rook rock: return "\u265C ";
                case Bishop bishop: return "\u265D ";
                case Knight knight: return "\u265E ";
                case Pawn pawn: return "\u265F";
                default: return "XX";
            }
        }

        private static void Print(string text, int x, int y, bool isWhite)
        {
            y = 8 - y;
            x = x - 1;
            Console.BackgroundColor = GetBackground(x, y);
            Console.ForegroundColor = isWhite ? ConsoleColor.White : ConsoleColor.Black;
            Console.SetCursorPosition(x * 2, y);
            Console.Write(text);
            Console.SetCursorPosition(16, 7);
        }

        public static ConsoleColor GetBackground(int x, int y)
        {
            if((y * 8 + x + (y % 2)) % 2 == 0)
            {
                return ConsoleColor.DarkGray;
            }
            else
            {
                return ConsoleColor.DarkGreen;
            }
        }

        private const int FIXED_WIDTH_TRUE_TYPE = 54;
        private const int STD_OUTPUT_HANDLE = -11;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool SetCurrentConsoleFontEx(IntPtr hConsoleOutput, bool MaximumWindow, ref FontInfoEx ConsoleCurrentFontEx);

        public static void SetConsoleFont()
        {
            var fontInfoEx = new FontInfoEx
            {
                cbSize = Marshal.SizeOf<FontInfoEx>(),
                FontIndex = 0,
                FontFamily = FIXED_WIDTH_TRUE_TYPE,
                FontName = "MS Gothic",
                FontWeight = 400,
                FontSize = 48
            };

            var consoleOutputHandle = GetStdHandle(STD_OUTPUT_HANDLE);
            SetCurrentConsoleFontEx(consoleOutputHandle, false, ref fontInfoEx);
        }
    }
}
