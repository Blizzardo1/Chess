using System.Drawing;
using ChessLib;

namespace Chess;

internal static class Program {
    private static readonly Board Board = new();
    private const int CellWidth = 4;
    private const int CellPadding = -1;

    private const ConsoleColor FrameColor = ConsoleColor.DarkGray;
    private const ConsoleColor CoordColor = ConsoleColor.Cyan;


    /// <summary>
    /// Generates a Character row for the entire board
    /// </summary>
    /// <param name="length">The length of which to generate</param>
    /// <param name="even">Character for even cells</param>
    /// <param name="odd">Character for odd cells</param>
    /// <returns>An alternating row of characters</returns>
    private static string GenerateRow(int length, char even, char odd)
    {
        string str = "";

        for (int i = 0; i < length; i++)
        {
            str += i % CellWidth < CellWidth - 1 ? even : odd;
        }

        return str;
    }

    /// <summary>
    /// Prints with a specified foregroundColor
    /// </summary>
    /// <param name="obj">The <see cref="object"/> to print out</param>
    /// <param name="foregroundColor">The foreground <see cref="ConsoleColor"/>.</param>
    private static void Print(object obj, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        Console.ForegroundColor = foregroundColor;
        Console.BackgroundColor = backgroundColor;
        Console.Write(obj);
        Console.ResetColor();
    }

    /// <summary>
    /// Prints the Board
    /// </summary>
    /// <remarks>
    /// Pulled from MineSweeper Milestone
    /// </remarks>
    private static void PrintBoard()
    {

        Print(" "); // This is for the start of the Column Coordinate
        for (int columnPosition = 0; columnPosition < Board.Size + 1; columnPosition++)
        {
            // A simple dirty hack, Create a space where there is no column present
            // for the game. Quick, dirty, and needs fixing so each column and row
            // number are tabular. That meaning the blank spot has no border.
            Print($"{(columnPosition == 0 ? $"  " : columnPosition - 1 > 9 ? $"{columnPosition - 1,1}" : $" {columnPosition - 1,-1}")} ", CoordColor);
            Print(" ", FrameColor);
        }

        Console.WriteLine();

        // Top Row Generation

        // Dirty hack; 
        for (int row = 0; row < Board.Size; row++)
        {
            // Begin each row with a border line generated to conform to the physical board
            Print(row == 0
                ? $"    ╔{GenerateRow(Board.Size * CellWidth + CellPadding, '═', '╦')}╗\n"
                : $"    ╠{GenerateRow(Board.Size * CellWidth + CellPadding, '═', '╬')}╣\n", FrameColor);

            // The row hack; essentially, this will shift the numbers around
            // if greater than 9. 
            Print(" ", FrameColor);
            Print($"{(row > 9 ? $"{row} " : $" {row} ")}", CoordColor);

            for (int column = 0; column < Board.Size; column++)
            {
                // Each Column has this for a starting character, then the cell data, then an ending char.
                Print("║ ", FrameColor);

                Cell cell = Board.Cells[row, column];
                Print(!cell.IsOccupied ? cell.LegalNextMove ? "+" : " " : "X",
                    !cell.IsOccupied ? cell.LegalNextMove ? ConsoleColor.Black : ConsoleColor.White : ConsoleColor.Green,
                    !cell.IsOccupied ? cell.LegalNextMove ? ConsoleColor.Yellow : ConsoleColor.Black : ConsoleColor.Black);


                Print(" ");
            }

            Print("║\n", FrameColor);
        }

        // The bottom of the board frame
        Print($"    ╚{GenerateRow(Board.Size * CellWidth + CellPadding, '═', '╩')}╝\n", FrameColor);
    }

    private static void Main() {
        // 1. Show the empty chessboard
        // 2. Get the location of the chess piece
        // 3. Calculate and mark the cells where legal moves are possible
        // 4. Show the chess board. Use . for an empty square, X for the piece location and + for a possible legal move
        // 5. Wait for another return key to end the program

        Console.WriteLine("Welcome to Console Chess!\n");

        Console.WriteLine("To exit, enter a row or column less than zero, or qq when selecting a chess piece.\n\n");

        PrintBoard();

        while (true) {
            try {

                Console.Write("Enter the current row number> ");
                if (!int.TryParse(Console.ReadLine(), out int row))
                {
                    "Invalid row number".Error();
                    continue;
                }

                if (row < 0) return;

                Console.Write("Enter the current column number> ");
                if (!int.TryParse(Console.ReadLine(), out int column))
                {
                    "Invalid column number".Error();
                    continue;
                }

                if (column < 0) return;

                Cell c = Board.SetCurrentCell(row, column);


                foreach (Piece p in Enum.GetValues< Piece >()) {
                    Console.WriteLine($"{p} > [{p.ToChessLetter()}]");
                }

                Console.Write($"Choose a piece> ");

                Piece piece = Console.ReadLine()!.ToUpper() switch {
                    "P" => Piece.Pawn,
                    "R" => Piece.Rook,
                    "N" => Piece.Knight,
                    "B" => Piece.Bishop,
                    "Q" => Piece.Queen,
                    "K" => Piece.King,
                    "QQ" => Piece.King | Piece.Queen,
                    _ => throw new ArgumentOutOfRangeException(null, @"Invalid Selection")
                };

                if (piece == ( Piece.King | Piece.Queen )) {
                    return;
                }


                Board.MarkNextLegalMoves(c, piece);

                PrintBoard();
                Board.ClearBoard();
            } catch(Exception ex) {
                ex.Message.Error();
            }
        }
    }
}