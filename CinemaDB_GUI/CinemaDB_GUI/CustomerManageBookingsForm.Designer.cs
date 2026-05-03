namespace CinemaDB_GUI
{
    partial class CustomerManageBookingsForm
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
            labelTitle = new System.Windows.Forms.Label();
            labelCustomerId = new System.Windows.Forms.Label();
            textBoxCustomerId = new System.Windows.Forms.TextBox();
            btnLoadBookings = new System.Windows.Forms.Button();
            dgvBookings = new System.Windows.Forms.DataGridView();
            btnDeleteBooking = new System.Windows.Forms.Button();
            btnViewAvailableSeats = new System.Windows.Forms.Button();
            btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            labelTitle.Location = new System.Drawing.Point(40, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new System.Drawing.Size(400, 46);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Manage My Bookings";
            // 
            // labelCustomerId
            // 
            labelCustomerId.AutoSize = true;
            labelCustomerId.Font = new System.Drawing.Font("Segoe UI", 11F);
            labelCustomerId.Location = new System.Drawing.Point(40, 90);
            labelCustomerId.Name = "labelCustomerId";
            labelCustomerId.Size = new System.Drawing.Size(117, 25);
            labelCustomerId.TabIndex = 1;
            labelCustomerId.Text = "Customer ID:";
            // 
            // textBoxCustomerId
            // 
            textBoxCustomerId.Location = new System.Drawing.Point(170, 90);
            textBoxCustomerId.Name = "textBoxCustomerId";
            textBoxCustomerId.Size = new System.Drawing.Size(150, 27);
            textBoxCustomerId.TabIndex = 2;
            // 
            // btnLoadBookings
            // 
            btnLoadBookings.BackColor = System.Drawing.Color.MediumSeaGreen;
            btnLoadBookings.ForeColor = System.Drawing.Color.White;
            btnLoadBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLoadBookings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnLoadBookings.Location = new System.Drawing.Point(340, 80);
            btnLoadBookings.Name = "btnLoadBookings";
            btnLoadBookings.Size = new System.Drawing.Size(150, 45);
            btnLoadBookings.TabIndex = 3;
            btnLoadBookings.Text = "Load Bookings";
            btnLoadBookings.UseVisualStyleBackColor = false;
            btnLoadBookings.Click += btnLoadBookings_Click;
            // 
            // dgvBookings
            // 
            dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookings.Location = new System.Drawing.Point(40, 150);
            dgvBookings.Name = "dgvBookings";
            dgvBookings.RowHeadersWidth = 51;
            dgvBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.Size = new System.Drawing.Size(800, 300);
            dgvBookings.TabIndex = 4;
            dgvBookings.ReadOnly = true;
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // btnDeleteBooking
            // 
            btnDeleteBooking.BackColor = System.Drawing.Color.Crimson;
            btnDeleteBooking.ForeColor = System.Drawing.Color.White;
            btnDeleteBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDeleteBooking.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnDeleteBooking.Location = new System.Drawing.Point(40, 460);
            btnDeleteBooking.Name = "btnDeleteBooking";
            btnDeleteBooking.Size = new System.Drawing.Size(200, 45);
            btnDeleteBooking.TabIndex = 5;
            btnDeleteBooking.Text = "Delete Selected Booking";
            btnDeleteBooking.UseVisualStyleBackColor = false;
            btnDeleteBooking.Click += btnDeleteBooking_Click;
            // 
            // btnViewAvailableSeats
            // 
            btnViewAvailableSeats.BackColor = System.Drawing.Color.DodgerBlue;
            btnViewAvailableSeats.ForeColor = System.Drawing.Color.White;
            btnViewAvailableSeats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnViewAvailableSeats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnViewAvailableSeats.Location = new System.Drawing.Point(640, 460);
            btnViewAvailableSeats.Name = "btnViewAvailableSeats";
            btnViewAvailableSeats.Size = new System.Drawing.Size(200, 45);
            btnViewAvailableSeats.TabIndex = 6;
            btnViewAvailableSeats.Text = "View Available Seats";
            btnViewAvailableSeats.UseVisualStyleBackColor = false;
            btnViewAvailableSeats.Click += btnViewAvailableSeats_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = System.Drawing.Color.LightGray;
            btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnBack.Location = new System.Drawing.Point(40, 520);
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(100, 40);
            btnBack.TabIndex = 7;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // CustomerManageBookingsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.WhiteSmoke;
            ClientSize = new System.Drawing.Size(880, 580);
            Controls.Add(btnBack);
            Controls.Add(btnViewAvailableSeats);
            Controls.Add(btnDeleteBooking);
            Controls.Add(dgvBookings);
            Controls.Add(btnLoadBookings);
            Controls.Add(textBoxCustomerId);
            Controls.Add(labelCustomerId);
            Controls.Add(labelTitle);
            Name = "CustomerManageBookingsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Manage My Bookings";
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelCustomerId;
        private System.Windows.Forms.TextBox textBoxCustomerId;
        private System.Windows.Forms.Button btnLoadBookings;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.Button btnDeleteBooking;
        private System.Windows.Forms.Button btnViewAvailableSeats;
        private System.Windows.Forms.Button btnBack;
    }
}
