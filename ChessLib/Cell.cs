using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Cell
    {
        public bool IsOccupied { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool LegalNextMove { get; set; }

        public Piece Piece { get; set; }

        public Cell(int row, int col) {
            Row = row;
            Column = col;
        }

        public override string ToString() => Piece.ToString();
    }
}
