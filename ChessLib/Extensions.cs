using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public static class Extensions
    {
        [Console]
        public static void Error(this string s) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        public static string ToChessLetter(this Piece piece) {
            return piece switch {
                Piece.Pawn => "P",
                Piece.Rook => "R",
                Piece.Knight => "N",
                Piece.Bishop => "B",
                Piece.Queen => "Q",
                Piece.King => "K",
                _ => throw new ArgumentOutOfRangeException(nameof(piece), piece, "Invalid piece")
            };
        }
    }
}
