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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnPaymentCancel = new System.Windows.Forms.Button();
            this.btnMyBookings = new System.Windows.Forms.Button();
            this.btnMakeBooking = new System.Windows.Forms.Button();
            this.btnAvailableSeats = new System.Windows.Forms.Button();
            this.btnShowtimes = new System.Windows.Forms.Button();
            this.btnSearchGenre = new System.Windows.Forms.Button();
            this.btnBrowseMovies = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.panelInput = new System.Windows.Forms.Panel();
            this.btnExecute = new System.Windows.Forms.Button();
            this.txtInput2 = new System.Windows.Forms.TextBox();
            this.lblInput2 = new System.Windows.Forms.Label();
            this.txtInput1 = new System.Windows.Forms.TextBox();
            this.lblInput1 = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.panelInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.panelSidebar.Controls.Add(this.btnPaymentCancel);
            this.panelSidebar.Controls.Add(this.btnMyBookings);
            this.panelSidebar.Controls.Add(this.btnMakeBooking);
            this.panelSidebar.Controls.Add(this.btnAvailableSeats);
            this.panelSidebar.Controls.Add(this.btnShowtimes);
            this.panelSidebar.Controls.Add(this.btnSearchGenre);
            this.panelSidebar.Controls.Add(this.btnBrowseMovies);
            this.panelSidebar.Controls.Add(this.panelLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(250, 681);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnPaymentCancel
            // 
            this.btnPaymentCancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPaymentCancel.FlatAppearance.BorderSize = 0;
            this.btnPaymentCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaymentCancel.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPaymentCancel.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPaymentCancel.Location = new System.Drawing.Point(0, 440);
            this.btnPaymentCancel.Name = "btnPaymentCancel";
            this.btnPaymentCancel.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnPaymentCancel.Size = new System.Drawing.Size(250, 60);
            this.btnPaymentCancel.TabIndex = 7;
            this.btnPaymentCancel.Text = "Confirm / Cancel Booking";
            this.btnPaymentCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaymentCancel.UseVisualStyleBackColor = true;
            this.btnPaymentCancel.Click += new System.EventHandler(this.BtnPaymentCancel_Click);
            // 
            // btnMyBookings
            // 
            this.btnMyBookings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMyBookings.FlatAppearance.BorderSize = 0;
            this.btnMyBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyBookings.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMyBookings.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMyBookings.Location = new System.Drawing.Point(0, 380);
            this.btnMyBookings.Name = "btnMyBookings";
            this.btnMyBookings.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMyBookings.Size = new System.Drawing.Size(250, 60);
            this.btnMyBookings.TabIndex = 6;
            this.btnMyBookings.Text = "My Bookings & Tickets";
            this.btnMyBookings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyBookings.UseVisualStyleBackColor = true;
            this.btnMyBookings.Click += new System.EventHandler(this.BtnMyBookings_Click);
            // 
            // btnMakeBooking
            // 
            this.btnMakeBooking.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMakeBooking.FlatAppearance.BorderSize = 0;
            this.btnMakeBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeBooking.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMakeBooking.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMakeBooking.Location = new System.Drawing.Point(0, 320);
            this.btnMakeBooking.Name = "btnMakeBooking";
            this.btnMakeBooking.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMakeBooking.Size = new System.Drawing.Size(250, 60);
            this.btnMakeBooking.TabIndex = 5;
            this.btnMakeBooking.Text = "Make a Booking";
            this.btnMakeBooking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMakeBooking.UseVisualStyleBackColor = true;
            this.btnMakeBooking.Click += new System.EventHandler(this.BtnMakeBooking_Click);
            // 
            // btnAvailableSeats
            // 
            this.btnAvailableSeats.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAvailableSeats.FlatAppearance.BorderSize = 0;
            this.btnAvailableSeats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAvailableSeats.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAvailableSeats.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAvailableSeats.Location = new System.Drawing.Point(0, 260);
            this.btnAvailableSeats.Name = "btnAvailableSeats";
            this.btnAvailableSeats.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnAvailableSeats.Size = new System.Drawing.Size(250, 60);
            this.btnAvailableSeats.TabIndex = 4;
            this.btnAvailableSeats.Text = "Available Seats";
            this.btnAvailableSeats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAvailableSeats.UseVisualStyleBackColor = true;
            this.btnAvailableSeats.Click += new System.EventHandler(this.BtnAvailableSeats_Click);
            // 
            // btnShowtimes
            // 
            this.btnShowtimes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShowtimes.FlatAppearance.BorderSize = 0;
            this.btnShowtimes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowtimes.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowtimes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnShowtimes.Location = new System.Drawing.Point(0, 200);
            this.btnShowtimes.Name = "btnShowtimes";
            this.btnShowtimes.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnShowtimes.Size = new System.Drawing.Size(250, 60);
            this.btnShowtimes.TabIndex = 3;
            this.btnShowtimes.Text = "View Showtimes";
            this.btnShowtimes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowtimes.UseVisualStyleBackColor = true;
            this.btnShowtimes.Click += new System.EventHandler(this.BtnShowtimes_Click);
            // 
            // btnSearchGenre
            // 
            this.btnSearchGenre.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSearchGenre.FlatAppearance.BorderSize = 0;
            this.btnSearchGenre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchGenre.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSearchGenre.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSearchGenre.Location = new System.Drawing.Point(0, 140);
            this.btnSearchGenre.Name = "btnSearchGenre";
            this.btnSearchGenre.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSearchGenre.Size = new System.Drawing.Size(250, 60);
            this.btnSearchGenre.TabIndex = 2;
            this.btnSearchGenre.Text = "Search by Genre";
            this.btnSearchGenre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchGenre.UseVisualStyleBackColor = true;
            this.btnSearchGenre.Click += new System.EventHandler(this.BtnSearchGenre_Click);
            // 
            // btnBrowseMovies
            // 
            this.btnBrowseMovies.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBrowseMovies.FlatAppearance.BorderSize = 0;
            this.btnBrowseMovies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseMovies.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBrowseMovies.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBrowseMovies.Location = new System.Drawing.Point(0, 80);
            this.btnBrowseMovies.Name = "btnBrowseMovies";
            this.btnBrowseMovies.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnBrowseMovies.Size = new System.Drawing.Size(250, 60);
            this.btnBrowseMovies.TabIndex = 1;
            this.btnBrowseMovies.Text = "Browse All Movies";
            this.btnBrowseMovies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowseMovies.UseVisualStyleBackColor = true;
            this.btnBrowseMovies.Click += new System.EventHandler(this.BtnBrowseMovies_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(126)))), ((int)(((byte)(49)))));
            this.panelLogo.Controls.Add(this.lblLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(250, 80);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "CinemaDB";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(250, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(834, 80);
            this.panelHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.lblTitle.Location = new System.Drawing.Point(26, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(236, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Customer Dashboard";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelContent.Controls.Add(this.dgvResults);
            this.panelContent.Controls.Add(this.panelInput);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(250, 80);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(834, 601);
            this.panelContent.TabIndex = 2;
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.BackgroundColor = System.Drawing.Color.White;
            this.dgvResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResults.ColumnHeadersHeight = 35;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.EnableHeadersVisualStyles = false;
            this.dgvResults.Location = new System.Drawing.Point(20, 100);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(126)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvResults.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResults.RowTemplate.Height = 30;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(794, 481);
            this.dgvResults.TabIndex = 1;
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.White;
            this.panelInput.Controls.Add(this.btnExecute);
            this.panelInput.Controls.Add(this.txtInput2);
            this.panelInput.Controls.Add(this.lblInput2);
            this.panelInput.Controls.Add(this.txtInput1);
            this.panelInput.Controls.Add(this.lblInput1);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInput.Location = new System.Drawing.Point(20, 20);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(794, 80);
            this.panelInput.TabIndex = 0;
            // 
            // btnExecute
            // 
            this.btnExecute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(126)))), ((int)(((byte)(49)))));
            this.btnExecute.FlatAppearance.BorderSize = 0;
            this.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecute.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExecute.ForeColor = System.Drawing.Color.White;
            this.btnExecute.Location = new System.Drawing.Point(623, 23);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(120, 35);
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // txtInput2
            // 
            this.txtInput2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtInput2.Location = new System.Drawing.Point(419, 28);
            this.txtInput2.Name = "txtInput2";
            this.txtInput2.Size = new System.Drawing.Size(180, 25);
            this.txtInput2.TabIndex = 3;
            // 
            // lblInput2
            // 
            this.lblInput2.AutoSize = true;
            this.lblInput2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInput2.Location = new System.Drawing.Point(323, 31);
            this.lblInput2.Name = "lblInput2";
            this.lblInput2.Size = new System.Drawing.Size(90, 19);
            this.lblInput2.TabIndex = 2;
            this.lblInput2.Text = "Parameter 2:";
            // 
            // txtInput1
            // 
            this.txtInput1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtInput1.Location = new System.Drawing.Point(120, 28);
            this.txtInput1.Name = "txtInput1";
            this.txtInput1.Size = new System.Drawing.Size(180, 25);
            this.txtInput1.TabIndex = 1;
            // 
            // lblInput1
            // 
            this.lblInput1.AutoSize = true;
            this.lblInput1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInput1.Location = new System.Drawing.Point(24, 31);
            this.lblInput1.Name = "lblInput1";
            this.lblInput1.Size = new System.Drawing.Size(90, 19);
            this.lblInput1.TabIndex = 0;
            this.lblInput1.Text = "Parameter 1:";
            // 
            // CustomerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 681);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "CustomerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cinema Ticket Booking System";
            this.Load += new System.EventHandler(this.CustomerDashboard_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.ResumeLayout(false);

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
