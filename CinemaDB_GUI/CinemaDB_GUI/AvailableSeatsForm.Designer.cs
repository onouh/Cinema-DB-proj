namespace CinemaDB_GUI
{
    partial class AvailableSeatsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            labelTitle = new Label();
            labelShowtimeId = new Label();
            textBoxShowtimeId = new TextBox();
            btnLoadSeats = new Button();
            dgvSeats = new DataGridView();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSeats).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            labelTitle.Location = new Point(40, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(251, 46);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Available Seats";
            // 
            // labelShowtimeId
            // 
            labelShowtimeId.AutoSize = true;
            labelShowtimeId.Font = new Font("Segoe UI", 11F);
            labelShowtimeId.Location = new Point(40, 90);
            labelShowtimeId.Name = "labelShowtimeId";
            labelShowtimeId.Size = new Size(125, 25);
            labelShowtimeId.TabIndex = 1;
            labelShowtimeId.Text = "Showtime ID:";
            // 
            // textBoxShowtimeId
            // 
            textBoxShowtimeId.Location = new Point(170, 90);
            textBoxShowtimeId.Name = "textBoxShowtimeId";
            textBoxShowtimeId.Size = new Size(150, 27);
            textBoxShowtimeId.TabIndex = 2;
            // 
            // btnLoadSeats
            // 
            btnLoadSeats.BackColor = Color.MediumSeaGreen;
            btnLoadSeats.ForeColor = Color.White;
            btnLoadSeats.FlatStyle = FlatStyle.Flat;
            btnLoadSeats.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLoadSeats.Location = new Point(340, 80);
            btnLoadSeats.Name = "btnLoadSeats";
            btnLoadSeats.Size = new Size(120, 45);
            btnLoadSeats.TabIndex = 3;
            btnLoadSeats.Text = "Load Seats";
            btnLoadSeats.UseVisualStyleBackColor = false;
            btnLoadSeats.Click += btnLoadSeats_Click;
            // 
            // dgvSeats
            // 
            dgvSeats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSeats.Location = new Point(40, 150);
            dgvSeats.Name = "dgvSeats";
            dgvSeats.RowHeadersWidth = 51;
            dgvSeats.Size = new Size(700, 350);
            dgvSeats.TabIndex = 4;
            dgvSeats.ReadOnly = true;
            dgvSeats.AllowUserToAddRows = false;
            dgvSeats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.LightGray;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.Location = new Point(40, 520);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 40);
            btnBack.TabIndex = 5;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // AvailableSeatsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(780, 580);
            Controls.Add(btnBack);
            Controls.Add(dgvSeats);
            Controls.Add(btnLoadSeats);
            Controls.Add(textBoxShowtimeId);
            Controls.Add(labelShowtimeId);
            Controls.Add(labelTitle);
            Name = "AvailableSeatsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Available Seats";
            ((System.ComponentModel.ISupportInitialize)dgvSeats).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelShowtimeId;
        private TextBox textBoxShowtimeId;
        private Button btnLoadSeats;
        private DataGridView dgvSeats;
        private Button btnBack;
    }
}
