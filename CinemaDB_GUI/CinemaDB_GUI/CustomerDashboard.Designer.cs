namespace CinemaDB_GUI
{
    partial class CustomerDashboard
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelSidebar = new Panel();
            btnPaymentCancel = new Button();
            btnMyBookings = new Button();
            btnMakeBooking = new Button();
            btnAvailableSeats = new Button();
            btnShowtimes = new Button();
            btnSearchGenre = new Button();
            btnBrowseMovies = new Button();
            panelLogo = new Panel();
            lblLogo = new Label();
            panelHeader = new Panel();
            lblTitle = new Label();
            panelContent = new Panel();
            dgvResults = new DataGridView();
            panelInput = new Panel();
            btnExecute = new Button();
            txtInput2 = new TextBox();
            lblInput2 = new Label();
            txtInput1 = new TextBox();
            lblInput1 = new Label();
            panelSidebar.SuspendLayout();
            panelLogo.SuspendLayout();
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            panelInput.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(41, 53, 65);
            panelSidebar.Controls.Add(btnPaymentCancel);
            panelSidebar.Controls.Add(btnMyBookings);
            panelSidebar.Controls.Add(btnMakeBooking);
            panelSidebar.Controls.Add(btnAvailableSeats);
            panelSidebar.Controls.Add(btnShowtimes);
            panelSidebar.Controls.Add(btnSearchGenre);
            panelSidebar.Controls.Add(btnBrowseMovies);
            panelSidebar.Controls.Add(panelLogo);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(6, 6, 6, 6);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(464, 1453);
            panelSidebar.TabIndex = 0;
            // 
            // btnPaymentCancel
            // 
            btnPaymentCancel.Dock = DockStyle.Top;
            btnPaymentCancel.FlatAppearance.BorderSize = 0;
            btnPaymentCancel.FlatStyle = FlatStyle.Flat;
            btnPaymentCancel.Font = new Font("Segoe UI", 10.5F);
            btnPaymentCancel.ForeColor = Color.Gainsboro;
            btnPaymentCancel.Location = new Point(0, 939);
            btnPaymentCancel.Margin = new Padding(6, 6, 6, 6);
            btnPaymentCancel.Name = "btnPaymentCancel";
            btnPaymentCancel.Padding = new Padding(28, 0, 0, 0);
            btnPaymentCancel.Size = new Size(464, 128);
            btnPaymentCancel.TabIndex = 7;
            btnPaymentCancel.Text = "Confirm / Cancel Booking";
            btnPaymentCancel.TextAlign = ContentAlignment.MiddleLeft;
            btnPaymentCancel.UseVisualStyleBackColor = true;
            btnPaymentCancel.Click += BtnPaymentCancel_Click;
            // 
            // btnMyBookings
            // 
            btnMyBookings.Dock = DockStyle.Top;
            btnMyBookings.FlatAppearance.BorderSize = 0;
            btnMyBookings.FlatStyle = FlatStyle.Flat;
            btnMyBookings.Font = new Font("Segoe UI", 10.5F);
            btnMyBookings.ForeColor = Color.Gainsboro;
            btnMyBookings.Location = new Point(0, 811);
            btnMyBookings.Margin = new Padding(6, 6, 6, 6);
            btnMyBookings.Name = "btnMyBookings";
            btnMyBookings.Padding = new Padding(28, 0, 0, 0);
            btnMyBookings.Size = new Size(464, 128);
            btnMyBookings.TabIndex = 6;
            btnMyBookings.Text = "My Bookings & Tickets";
            btnMyBookings.TextAlign = ContentAlignment.MiddleLeft;
            btnMyBookings.UseVisualStyleBackColor = true;
            btnMyBookings.Click += BtnMyBookings_Click;
            // 
            // btnMakeBooking
            // 
            btnMakeBooking.Dock = DockStyle.Top;
            btnMakeBooking.FlatAppearance.BorderSize = 0;
            btnMakeBooking.FlatStyle = FlatStyle.Flat;
            btnMakeBooking.Font = new Font("Segoe UI", 10.5F);
            btnMakeBooking.ForeColor = Color.Gainsboro;
            btnMakeBooking.Location = new Point(0, 683);
            btnMakeBooking.Margin = new Padding(6, 6, 6, 6);
            btnMakeBooking.Name = "btnMakeBooking";
            btnMakeBooking.Padding = new Padding(28, 0, 0, 0);
            btnMakeBooking.Size = new Size(464, 128);
            btnMakeBooking.TabIndex = 5;
            btnMakeBooking.Text = "Make a Booking";
            btnMakeBooking.TextAlign = ContentAlignment.MiddleLeft;
            btnMakeBooking.UseVisualStyleBackColor = true;
            btnMakeBooking.Click += BtnMakeBooking_Click;
            // 
            // btnAvailableSeats
            // 
            btnAvailableSeats.Dock = DockStyle.Top;
            btnAvailableSeats.FlatAppearance.BorderSize = 0;
            btnAvailableSeats.FlatStyle = FlatStyle.Flat;
            btnAvailableSeats.Font = new Font("Segoe UI", 10.5F);
            btnAvailableSeats.ForeColor = Color.Gainsboro;
            btnAvailableSeats.Location = new Point(0, 555);
            btnAvailableSeats.Margin = new Padding(6, 6, 6, 6);
            btnAvailableSeats.Name = "btnAvailableSeats";
            btnAvailableSeats.Padding = new Padding(28, 0, 0, 0);
            btnAvailableSeats.Size = new Size(464, 128);
            btnAvailableSeats.TabIndex = 4;
            btnAvailableSeats.Text = "Available Seats";
            btnAvailableSeats.TextAlign = ContentAlignment.MiddleLeft;
            btnAvailableSeats.UseVisualStyleBackColor = true;
            btnAvailableSeats.Click += BtnAvailableSeats_Click;
            // 
            // btnShowtimes
            // 
            btnShowtimes.Dock = DockStyle.Top;
            btnShowtimes.FlatAppearance.BorderSize = 0;
            btnShowtimes.FlatStyle = FlatStyle.Flat;
            btnShowtimes.Font = new Font("Segoe UI", 10.5F);
            btnShowtimes.ForeColor = Color.Gainsboro;
            btnShowtimes.Location = new Point(0, 427);
            btnShowtimes.Margin = new Padding(6, 6, 6, 6);
            btnShowtimes.Name = "btnShowtimes";
            btnShowtimes.Padding = new Padding(28, 0, 0, 0);
            btnShowtimes.Size = new Size(464, 128);
            btnShowtimes.TabIndex = 3;
            btnShowtimes.Text = "View Showtimes";
            btnShowtimes.TextAlign = ContentAlignment.MiddleLeft;
            btnShowtimes.UseVisualStyleBackColor = true;
            btnShowtimes.Click += BtnShowtimes_Click;
            // 
            // btnSearchGenre
            // 
            btnSearchGenre.Dock = DockStyle.Top;
            btnSearchGenre.FlatAppearance.BorderSize = 0;
            btnSearchGenre.FlatStyle = FlatStyle.Flat;
            btnSearchGenre.Font = new Font("Segoe UI", 10.5F);
            btnSearchGenre.ForeColor = Color.Gainsboro;
            btnSearchGenre.Location = new Point(0, 299);
            btnSearchGenre.Margin = new Padding(6, 6, 6, 6);
            btnSearchGenre.Name = "btnSearchGenre";
            btnSearchGenre.Padding = new Padding(28, 0, 0, 0);
            btnSearchGenre.Size = new Size(464, 128);
            btnSearchGenre.TabIndex = 2;
            btnSearchGenre.Text = "Search by Genre";
            btnSearchGenre.TextAlign = ContentAlignment.MiddleLeft;
            btnSearchGenre.UseVisualStyleBackColor = true;
            btnSearchGenre.Click += BtnSearchGenre_Click;
            // 
            // btnBrowseMovies
            // 
            btnBrowseMovies.Dock = DockStyle.Top;
            btnBrowseMovies.FlatAppearance.BorderSize = 0;
            btnBrowseMovies.FlatStyle = FlatStyle.Flat;
            btnBrowseMovies.Font = new Font("Segoe UI", 10.5F);
            btnBrowseMovies.ForeColor = Color.Gainsboro;
            btnBrowseMovies.Location = new Point(0, 171);
            btnBrowseMovies.Margin = new Padding(6, 6, 6, 6);
            btnBrowseMovies.Name = "btnBrowseMovies";
            btnBrowseMovies.Padding = new Padding(28, 0, 0, 0);
            btnBrowseMovies.Size = new Size(464, 128);
            btnBrowseMovies.TabIndex = 1;
            btnBrowseMovies.Text = "Browse All Movies";
            btnBrowseMovies.TextAlign = ContentAlignment.MiddleLeft;
            btnBrowseMovies.UseVisualStyleBackColor = true;
            btnBrowseMovies.Click += BtnBrowseMovies_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(229, 126, 49);
            panelLogo.Controls.Add(lblLogo);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Margin = new Padding(6, 6, 6, 6);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(464, 171);
            panelLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.Dock = DockStyle.Fill;
            lblLogo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(0, 0);
            lblLogo.Margin = new Padding(6, 0, 6, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(464, 171);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "CinemaDB";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(464, 0);
            panelHeader.Margin = new Padding(6, 6, 6, 6);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1717, 171);
            panelHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F);
            lblTitle.ForeColor = Color.FromArgb(41, 53, 65);
            lblTitle.Location = new Point(48, 53);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(475, 65);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Customer Dashboard";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(240, 240, 240);
            panelContent.Controls.Add(dgvResults);
            panelContent.Controls.Add(panelInput);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(464, 171);
            panelContent.Margin = new Padding(6, 6, 6, 6);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(37, 43, 37, 43);
            panelContent.Size = new Size(1717, 1282);
            panelContent.TabIndex = 2;
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.BackgroundColor = Color.White;
            dgvResults.BorderStyle = BorderStyle.None;
            dgvResults.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(41, 53, 65);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvResults.ColumnHeadersHeight = 35;
            dgvResults.Dock = DockStyle.Fill;
            dgvResults.EnableHeadersVisualStyles = false;
            dgvResults.Location = new Point(37, 214);
            dgvResults.Margin = new Padding(6, 6, 6, 6);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersVisible = false;
            dgvResults.RowHeadersWidth = 82;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(229, 126, 49);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvResults.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvResults.RowTemplate.Height = 30;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.Size = new Size(1643, 1025);
            dgvResults.TabIndex = 1;
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.White;
            panelInput.Controls.Add(btnExecute);
            panelInput.Controls.Add(txtInput2);
            panelInput.Controls.Add(lblInput2);
            panelInput.Controls.Add(txtInput1);
            panelInput.Controls.Add(lblInput1);
            panelInput.Dock = DockStyle.Top;
            panelInput.Location = new Point(37, 43);
            panelInput.Margin = new Padding(6, 6, 6, 6);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(1643, 171);
            panelInput.TabIndex = 0;
            // 
            // btnExecute
            // 
            btnExecute.BackColor = Color.FromArgb(229, 126, 49);
            btnExecute.FlatAppearance.BorderSize = 0;
            btnExecute.FlatStyle = FlatStyle.Flat;
            btnExecute.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnExecute.ForeColor = Color.White;
            btnExecute.Location = new Point(1356, 48);
            btnExecute.Margin = new Padding(6, 6, 6, 6);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(223, 75);
            btnExecute.TabIndex = 4;
            btnExecute.Text = "Execute";
            btnExecute.UseVisualStyleBackColor = false;
            btnExecute.Click += BtnExecute_Click;
            // 
            // txtInput2
            // 
            txtInput2.Font = new Font("Segoe UI", 10F);
            txtInput2.Location = new Point(969, 63);
            txtInput2.Margin = new Padding(6, 6, 6, 6);
            txtInput2.Name = "txtInput2";
            txtInput2.Size = new Size(331, 43);
            txtInput2.TabIndex = 3;
            // 
            // lblInput2
            // 
            lblInput2.AutoSize = true;
            lblInput2.Font = new Font("Segoe UI", 10F);
            lblInput2.Location = new Point(672, 66);
            lblInput2.Margin = new Padding(6, 0, 6, 0);
            lblInput2.Name = "lblInput2";
            lblInput2.Size = new Size(165, 37);
            lblInput2.TabIndex = 2;
            lblInput2.Text = "Parameter 2:";
            // 
            // txtInput1
            // 
            txtInput1.Font = new Font("Segoe UI", 10F);
            txtInput1.Location = new Point(314, 63);
            txtInput1.Margin = new Padding(6, 6, 6, 6);
            txtInput1.Name = "txtInput1";
            txtInput1.Size = new Size(331, 43);
            txtInput1.TabIndex = 1;
            // 
            // lblInput1
            // 
            lblInput1.AutoSize = true;
            lblInput1.Font = new Font("Segoe UI", 10F);
            lblInput1.Location = new Point(42, 66);
            lblInput1.Margin = new Padding(6, 0, 6, 0);
            lblInput1.Name = "lblInput1";
            lblInput1.Size = new Size(165, 37);
            lblInput1.TabIndex = 0;
            lblInput1.Text = "Parameter 1:";
            // 
            // CustomerDashboard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2181, 1453);
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            Controls.Add(panelSidebar);
            Margin = new Padding(6, 6, 6, 6);
            MinimumSize = new Size(1649, 1200);
            Name = "CustomerDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cinema Ticket Booking System";
            Load += CustomerDashboard_Load;
            panelSidebar.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnBrowseMovies;
        private System.Windows.Forms.Button btnPaymentCancel;
        private System.Windows.Forms.Button btnMyBookings;
        private System.Windows.Forms.Button btnMakeBooking;
        private System.Windows.Forms.Button btnAvailableSeats;
        private System.Windows.Forms.Button btnShowtimes;
        private System.Windows.Forms.Button btnSearchGenre;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.TextBox txtInput2;
        private System.Windows.Forms.Label lblInput2;
        private System.Windows.Forms.TextBox txtInput1;
        private System.Windows.Forms.Label lblInput1;
        private System.Windows.Forms.Button btnExecute;
    }
}
