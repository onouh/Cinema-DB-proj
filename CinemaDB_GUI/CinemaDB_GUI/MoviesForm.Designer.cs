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
            label1.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            label1.Location = new Point(40, 20);
            label1.Name = "label1";
            label1.Size = new Size(263, 46);
            label1.TabIndex = 0;
            label1.Text = "Movies";
            label1.Click += label1_Click;
            // 
            // dgv_Movies
            // 
            dgv_Movies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Movies.Location = new Point(40, 90);
            dgv_Movies.Name = "dgv_Movies";
            dgv_Movies.RowHeadersWidth = 82;
            dgv_Movies.Size = new Size(800, 350);
            dgv_Movies.TabIndex = 3;
            dgv_Movies.ReadOnly = true;
            dgv_Movies.AllowUserToAddRows = false;
            dgv_Movies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Movies.CellContentClick += dgv_Movies_CellContentClick;
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.LightGray;
            btn_back.FlatStyle = FlatStyle.Flat;
            btn_back.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_back.Location = new Point(40, 460);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(100, 45);
            btn_back.TabIndex = 2;
            btn_back.Text = "Back";
            btn_back.UseVisualStyleBackColor = false;
            btn_back.Click += btn_back_Click;
            // 
            // btn_refresh
            // 
            btn_refresh.BackColor = Color.MediumSeaGreen;
            btn_refresh.ForeColor = Color.White;
            btn_refresh.FlatStyle = FlatStyle.Flat;
            btn_refresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_refresh.Location = new Point(160, 460);
            btn_refresh.Name = "btn_refresh";
            btn_refresh.Size = new Size(120, 45);
            btn_refresh.TabIndex = 4;
            btn_refresh.Text = "Refresh";
            btn_refresh.UseVisualStyleBackColor = false;
            btn_refresh.Click += btn_refresh_Click;
            // 
            // MoviesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(880, 550);
            Controls.Add(btn_refresh);
            Controls.Add(dgv_Movies);
            Controls.Add(btn_back);
            Controls.Add(label1);
            Name = "MoviesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Movies";
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