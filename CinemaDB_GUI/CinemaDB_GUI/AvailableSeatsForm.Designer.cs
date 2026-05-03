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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblShowtimeId = new System.Windows.Forms.Label();
            this.txtShowtimeId = new System.Windows.Forms.TextBox();
            this.btnCheckSeats = new System.Windows.Forms.Button();
            this.dgvSeats = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeats)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(298, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Check Available Seats";
            // 
            // lblShowtimeId
            // 
            this.lblShowtimeId.AutoSize = true;
            this.lblShowtimeId.Location = new System.Drawing.Point(20, 70);
            this.lblShowtimeId.Name = "lblShowtimeId";
            this.lblShowtimeId.Size = new System.Drawing.Size(133, 20);
            this.lblShowtimeId.TabIndex = 1;
            this.lblShowtimeId.Text = "Enter Showtime ID:";
            // 
            // txtShowtimeId
            // 
            this.txtShowtimeId.Location = new System.Drawing.Point(150, 68);
            this.txtShowtimeId.Name = "txtShowtimeId";
            this.txtShowtimeId.Size = new System.Drawing.Size(100, 27);
            this.txtShowtimeId.TabIndex = 2;
            // 
            // btnCheckSeats
            // 
            this.btnCheckSeats.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCheckSeats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckSeats.Location = new System.Drawing.Point(260, 65);
            this.btnCheckSeats.Name = "btnCheckSeats";
            this.btnCheckSeats.Size = new System.Drawing.Size(94, 32);
            this.btnCheckSeats.TabIndex = 3;
            this.btnCheckSeats.Text = "Find Seats";
            this.btnCheckSeats.UseVisualStyleBackColor = false;
            // 
            // dgvSeats
            // 
            this.dgvSeats.AllowUserToAddRows = false;
            this.dgvSeats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeats.Location = new System.Drawing.Point(20, 110);
            this.dgvSeats.Name = "dgvSeats";
            this.dgvSeats.ReadOnly = true;
            this.dgvSeats.RowHeadersWidth = 51;
            this.dgvSeats.Size = new System.Drawing.Size(540, 320);
            this.dgvSeats.TabIndex = 4;
            // 
            // AvailableSeatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.dgvSeats);
            this.Controls.Add(this.btnCheckSeats);
            this.Controls.Add(this.txtShowtimeId);
            this.Controls.Add(this.lblShowtimeId);
            this.Controls.Add(this.lblTitle);
            this.Name = "AvailableSeatsForm";
            this.Text = "Available Seats Check";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblShowtimeId;
        private System.Windows.Forms.TextBox txtShowtimeId;
        private System.Windows.Forms.Button btnCheckSeats;
        private System.Windows.Forms.DataGridView dgvSeats;
    }
}