namespace ChessGui
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chessPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.chessCbx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chessPanel
            // 
            this.chessPanel.Location = new System.Drawing.Point(12, 51);
            this.chessPanel.Name = "chessPanel";
            this.chessPanel.Size = new System.Drawing.Size(500, 500);
            this.chessPanel.TabIndex = 0;
            // 
            // chessCbx
            // 
            this.chessCbx.FormattingEnabled = true;
            this.chessCbx.Location = new System.Drawing.Point(471, 17);
            this.chessCbx.Name = "chessCbx";
            this.chessCbx.Size = new System.Drawing.Size(137, 23);
            this.chessCbx.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(453, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select a type of chess piece and then click on the grid. I wil show you all legal" +
    " moves.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 570);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chessCbx);
            this.Controls.Add(this.chessPanel);
            this.Name = "Form1";
            this.Text = "Chess GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel chessPanel;
        private ComboBox chessCbx;
        private Label label1;
    }
}