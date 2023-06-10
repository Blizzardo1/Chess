namespace ChessLib {
    public class Board {



        private Cell[,] _cells;

        public Cell[,] Cells => _cells;

        public int Size { get; set; }

        public Board(int s = 8) {
            Size = s;

            _cells = new Cell[Size, Size];
            BuildBoard();
        }

        private void BuildBoard() {
            for (int y = 0; y < Size; y++) {
                for (int x = 0; x < Size; x++) {
                    _cells[ y, x ] = new Cell(y, x);
                }
            }
        }

        /// <summary>
        /// Determines the diagonal moves of the Bishop
        /// </summary>
        /// <param name="cell">The cell of which the Bishop exists</param>
        private void DetermineBishopMoves(Cell cell) {
            // Move diagonally up and left
            int row = cell.Row - 1;
            int column = cell.Column - 1;
            while (row >= 0 && column >= 0) {
                SetLegalNextMove(row, column);
                row--;
                column--;
            }

            // Move diagonally up and right
            row = cell.Row - 1;
            column = cell.Column + 1;
            while (row >= 0 && column < _cells.GetLength(1)) {
                SetLegalNextMove(row, column);
                row--;
                column++;
            }

            // Move diagonally down and left
            row = cell.Row + 1;
            column = cell.Column - 1;
            while (row < _cells.GetLength(0) && column >= 0) {
                SetLegalNextMove(row, column);
                row++;
                column--;
            }

            // Move diagonally down and right
            row = cell.Row + 1;
            column = cell.Column + 1;
            while (row < _cells.GetLength(0) && column < _cells.GetLength(1)) {
                SetLegalNextMove(row, column);
                row++;
                column++;
            }
        }

        /// <summary>
        /// Determines the horizontal and vertical moves of the Rook
        /// </summary>
        /// <param name="cell">The cell of which the Rook exists</param>
        private void DetermineRookMoves(Cell cell) {
            // Vertical Upward
            for (int row = cell.Row - 1; row >= 0; row--) {
                SetLegalNextMove(row, cell.Column);
            }

            // Vertical Downward
            for (int row = cell.Row + 1; row < _cells.GetLength(0); row++) {
                SetLegalNextMove(row, cell.Column);
            }

            // Horizontal Left
            for (int col = cell.Column - 1; col >= 0; col--) {
                SetLegalNextMove(cell.Row, col);
            }

            // Horizontal Right
            for (int col = cell.Column + 1; col < _cells.GetLength(1); col++) {
                SetLegalNextMove(cell.Row, col);
            }
        }

        private void SetLegalNextMove(int row, int col) {
            const int minRow = 0;
            int maxRow = _cells.GetUpperBound(0);
            const int minColumn = 0;
            int maxColumn = _cells.GetUpperBound(1);

            if (row < minRow || row > maxRow || col < minColumn || col > maxColumn) {
                // Silently Return
                return;
            }

            _cells[ row, col ].LegalNextMove = true;
        }

        /// <summary>
        /// Takes a <see cref="chessPiece"/> which exists in the <see cref="currentCell"/>, and determines its next move
        /// </summary>
        /// <param name="currentCell">The <see cref="Cell"/> of which the <see cref="Piece"/> exists.</param>
        /// <param name="chessPiece">The piece occupying the <see cref="Cell"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException">If the <see cref="chessPiece"/> is of the incorrect type</exception>
        public void MarkNextLegalMoves(Cell currentCell, Piece chessPiece) {
            for (int y = 0; y < Size; y++) {
                for (int x = 0; x < Size; x++) {
                    _cells[ y, x ].LegalNextMove = false;
                }
            }
            
            switch (chessPiece) {
                case Piece.Pawn:
                    SetLegalNextMove(currentCell.Row - 1, currentCell.Column);
                    SetLegalNextMove(currentCell.Row - 2, currentCell.Column);
                    SetLegalNextMove(currentCell.Row - 1, currentCell.Column - 1);
                    SetLegalNextMove(currentCell.Row - 1, currentCell.Column + 1);
                    break;
                case Piece.Rook:
                    DetermineRookMoves(currentCell);
                    break;
                case Piece.Knight:
                    SetLegalNextMove(currentCell.Row - 2, currentCell.Column - 1);
                    SetLegalNextMove(currentCell.Row - 2, currentCell.Column + 1);
                    SetLegalNextMove(currentCell.Row - 1, currentCell.Column + 2);
                    SetLegalNextMove(currentCell.Row + 1, currentCell.Column + 2);
                    SetLegalNextMove(currentCell.Row + 2, currentCell.Column + 1);
                    SetLegalNextMove(currentCell.Row + 2, currentCell.Column - 1);
                    SetLegalNextMove(currentCell.Row + 1, currentCell.Column - 2);
                    SetLegalNextMove(currentCell.Row - 1, currentCell.Column - 2);
                    break;
                case Piece.Bishop:
                    DetermineBishopMoves(currentCell);
                    break;
                case Piece.Queen:
                    DetermineRookMoves(currentCell);
                    DetermineBishopMoves(currentCell);
                    break;
                case Piece.King:
                    SetLegalNextMove(currentCell.Row - 1, currentCell.Column);
                    SetLegalNextMove(currentCell.Row - 1, currentCell.Column - 1);
                    SetLegalNextMove(currentCell.Row - 1, currentCell.Column + 1);
                    SetLegalNextMove(currentCell.Row, currentCell.Column - 1);
                    SetLegalNextMove(currentCell.Row, currentCell.Column + 1);
                    SetLegalNextMove(currentCell.Row + 1, currentCell.Column - 1);
                    SetLegalNextMove(currentCell.Row + 1, currentCell.Column);
                    SetLegalNextMove(currentCell.Row + 1, currentCell.Column + 1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(chessPiece), chessPiece, null);
            }
        }

        public Cell SetCurrentCell(int row, int column) {
            _cells[ row, column ].IsOccupied = true;
            return _cells[ row, column ];
        }



        public void ClearBoard() {
            for(int y = 0; y < _cells.GetLength(0); y++)
            {
                for(int x = 0; x < _cells.GetLength(1); x++) {
                    _cells[ y, x ].IsOccupied = false;
                }
            }
        }
    }
}