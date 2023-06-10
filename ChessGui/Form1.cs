using ChessLib;

namespace ChessGui
{
    public partial class Form1 : Form
    {
        Board _board;

        public Form1()
        {
            InitializeComponent();
            _board = new Board();
            PopulateChessPieces();
            CreateBoard();
        }

        private void PopulateChessPieces()
        {
            chessCbx.DataSource = Enum.GetValues(typeof(Piece));
            chessCbx.SelectedIndex = 0;
        }

        private void CreateBoard()
        {
            for (int y = 0; y < _board.Size; y++)
            {
                for (int x = 0; x < _board.Size; x++)
                {
                    Button button = new ();
                    button.Size = new Size(50, 50);
                    button.Click += Button_Click;
                    button.Tag = _board.Cells[y, x];
                    // button.Text = @$"{y}{x}";
                    chessPanel.Controls.Add(button);
                }
            }
        }

        private void ResetBoard()
        {
            foreach (Control control in chessPanel.Controls) {
                if (control is not Button button) continue;
                button.Text = "";
                button.BackColor = Color.FromKnownColor(KnownColor.Control);
                button.Enabled = true;
            }
            _board.ClearBoard();
        }

        private void SetLegalNextMove(Cell cell)
        {
            _board.SetCurrentCell(cell.Row, cell.Column);
            _board.MarkNextLegalMoves(cell, cell.Piece);

            foreach (Control control in chessPanel.Controls) {
                if (control is not Button button) continue;
                var currentCell = (Cell)button.Tag;
                if (currentCell.LegalNextMove) {
                    button.BackColor = Color.LightGreen;
                }
            }
        }


        private void Button_Click(object? sender, EventArgs e) {
            ResetBoard();
            if (sender is not Button button) return;
            var cell = (Cell)button.Tag;
            cell.IsOccupied = true;
            if (chessCbx.SelectedItem is Piece piece) {
                cell.Piece = piece;
            }

            SetLegalNextMove(cell);

            button.Text = cell.Piece.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}