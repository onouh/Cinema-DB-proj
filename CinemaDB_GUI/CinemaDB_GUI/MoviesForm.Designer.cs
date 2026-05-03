namespace CinemaDB_GUI
{
    partial class MoviesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btn_back = new Button();
            dgv_Movies = new DataGridView();
            btn_refresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_Movies).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(113, 44);
            label1.Name = "label1";
            label1.Size = new Size(207, 60);
            label1.TabIndex = 0;
            label1.Text = "Movies";
            label1.Click += label1_Click;
            // 
            // btn_back
            // 
            btn_back.Location = new Point(113, 619);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(150, 46);
            btn_back.TabIndex = 2;
            btn_back.Text = "Back";
            btn_back.UseVisualStyleBackColor = true;
            btn_back.Click += btn_back_Click;
            // 
            // dgv_Movies
            // 
            dgv_Movies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Movies.Location = new Point(113, 134);
            dgv_Movies.Name = "dgv_Movies";
            dgv_Movies.RowHeadersWidth = 82;
            dgv_Movies.Size = new Size(1232, 442);
            dgv_Movies.TabIndex = 3;
            dgv_Movies.CellContentClick += dgv_Movies_CellContentClick;
            // 
            // btn_refresh
            // 
            btn_refresh.Location = new Point(630, 499);
            btn_refresh.Name = "btn_refresh";
            btn_refresh.Size = new Size(150, 46);
            btn_refresh.TabIndex = 4;
            btn_refresh.Text = "Refresh";
            btn_refresh.UseVisualStyleBackColor = true;
            btn_refresh.Click += btn_refresh_Click;
            // 
            // MoviesForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 631);
            Controls.Add(btn_refresh);
            Controls.Add(dgv_Movies);
            Controls.Add(btn_back);
            Controls.Add(label1);
            Name = "MoviesForm";
            Text = "MoviesForm";
            Load += MoviesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Movies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btn_back;
        private DataGridView dgv_Movies;
        private Button btn_refresh;
    }
}