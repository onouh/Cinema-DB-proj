namespace CinemaDB_GUI
{
    partial class Form1
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.labelAdmin = new System.Windows.Forms.Label();
            this.btn_ViewMovies = new System.Windows.Forms.Button();
            this.btn_ViewMyTickets = new System.Windows.Forms.Button();
            this.btn_ViewSeats = new System.Windows.Forms.Button();
            this.btn_CustomerManageBookings = new System.Windows.Forms.Button();
            this.btn_ManageCustomers = new System.Windows.Forms.Button();
            this.btn_ManageMovies = new System.Windows.Forms.Button();
            this.btn_ManageCinemas = new System.Windows.Forms.Button();
            this.btn_ManageShowtimes = new System.Windows.Forms.Button();
            this.btn_ManageBookings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(220, 30);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(393, 54);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Cinema DB Manager";
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.labelCustomer.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelCustomer.Location = new System.Drawing.Point(100, 120);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(188, 31);
            this.labelCustomer.TabIndex = 1;
            this.labelCustomer.Text = "Customer Views";
            // 
            // btn_ViewMovies
            // 
            this.btn_ViewMovies.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_ViewMovies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ViewMovies.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_ViewMovies.Location = new System.Drawing.Point(100, 170);
            this.btn_ViewMovies.Name = "btn_ViewMovies";
            this.btn_ViewMovies.Size = new System.Drawing.Size(250, 55);
            this.btn_ViewMovies.TabIndex = 2;
            this.btn_ViewMovies.Text = "View Available Movies";
            this.btn_ViewMovies.UseVisualStyleBackColor = false;
            // 
            // btn_ViewMyTickets
            // 
            this.btn_ViewMyTickets.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_ViewMyTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ViewMyTickets.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_ViewMyTickets.Location = new System.Drawing.Point(100, 240);
            this.btn_ViewMyTickets.Name = "btn_ViewMyTickets";
            this.btn_ViewMyTickets.Size = new System.Drawing.Size(250, 55);
            this.btn_ViewMyTickets.TabIndex = 3;
            this.btn_ViewMyTickets.Text = "View My Tickets";
            this.btn_ViewMyTickets.UseVisualStyleBackColor = false;
            // 
            // btn_ViewSeats
            // 
            this.btn_ViewSeats.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_ViewSeats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ViewSeats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_ViewSeats.Location = new System.Drawing.Point(100, 310);
            this.btn_ViewSeats.Name = "btn_ViewSeats";
            this.btn_ViewSeats.Size = new System.Drawing.Size(250, 55);
            this.btn_ViewSeats.TabIndex = 4;
            this.btn_ViewSeats.Text = "View Available Seats";
            this.btn_ViewSeats.UseVisualStyleBackColor = false;
            // 
            // btn_CustomerManageBookings
            // 
            this.btn_CustomerManageBookings.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_CustomerManageBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CustomerManageBookings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_CustomerManageBookings.Location = new System.Drawing.Point(100, 380);
            this.btn_CustomerManageBookings.Name = "btn_CustomerManageBookings";
            this.btn_CustomerManageBookings.Size = new System.Drawing.Size(250, 55);
            this.btn_CustomerManageBookings.TabIndex = 11;
            this.btn_CustomerManageBookings.Text = "Manage My Bookings";
            this.btn_CustomerManageBookings.UseVisualStyleBackColor = false;
            // 
            // labelAdmin
            // 
            this.labelAdmin.AutoSize = true;
            this.labelAdmin.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.labelAdmin.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelAdmin.Location = new System.Drawing.Point(480, 120);
            this.labelAdmin.Name = "labelAdmin";
            this.labelAdmin.Size = new System.Drawing.Size(260, 31);
            this.labelAdmin.TabIndex = 5;
            this.labelAdmin.Text = "Admin CRUD Controls";
            // 
            // btn_ManageCustomers
            // 
            this.btn_ManageCustomers.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btn_ManageCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ManageCustomers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_ManageCustomers.Location = new System.Drawing.Point(480, 170);
            this.btn_ManageCustomers.Name = "btn_ManageCustomers";
            this.btn_ManageCustomers.Size = new System.Drawing.Size(250, 55);
            this.btn_ManageCustomers.TabIndex = 6;
            this.btn_ManageCustomers.Text = "Manage Customers";
            this.btn_ManageCustomers.UseVisualStyleBackColor = false;
            // 
            // btn_ManageMovies
            // 
            this.btn_ManageMovies.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btn_ManageMovies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ManageMovies.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_ManageMovies.Location = new System.Drawing.Point(480, 240);
            this.btn_ManageMovies.Name = "btn_ManageMovies";
            this.btn_ManageMovies.Size = new System.Drawing.Size(250, 55);
            this.btn_ManageMovies.TabIndex = 7;
            this.btn_ManageMovies.Text = "Manage Movies";
            this.btn_ManageMovies.UseVisualStyleBackColor = false;
            // 
            // btn_ManageCinemas
            // 
            this.btn_ManageCinemas.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btn_ManageCinemas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ManageCinemas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_ManageCinemas.Location = new System.Drawing.Point(480, 310);
            this.btn_ManageCinemas.Name = "btn_ManageCinemas";
            this.btn_ManageCinemas.Size = new System.Drawing.Size(250, 55);
            this.btn_ManageCinemas.TabIndex = 8;
            this.btn_ManageCinemas.Text = "Manage Cinemas";
            this.btn_ManageCinemas.UseVisualStyleBackColor = false;
            // 
            // btn_ManageShowtimes
            // 
            this.btn_ManageShowtimes.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btn_ManageShowtimes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ManageShowtimes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_ManageShowtimes.Location = new System.Drawing.Point(480, 380);
            this.btn_ManageShowtimes.Name = "btn_ManageShowtimes";
            this.btn_ManageShowtimes.Size = new System.Drawing.Size(250, 55);
            this.btn_ManageShowtimes.TabIndex = 9;
            this.btn_ManageShowtimes.Text = "Manage Showtimes";
            this.btn_ManageShowtimes.UseVisualStyleBackColor = false;
            // 
            // btn_ManageBookings
            // 
            this.btn_ManageBookings.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btn_ManageBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ManageBookings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_ManageBookings.Location = new System.Drawing.Point(480, 450);
            this.btn_ManageBookings.Name = "btn_ManageBookings";
            this.btn_ManageBookings.Size = new System.Drawing.Size(250, 55);
            this.btn_ManageBookings.TabIndex = 10;
            this.btn_ManageBookings.Text = "Manage Bookings";
            this.btn_ManageBookings.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(840, 550);
            this.Controls.Add(this.btn_ManageBookings);
            this.Controls.Add(this.btn_ManageShowtimes);
            this.Controls.Add(this.btn_ManageCinemas);
            this.Controls.Add(this.btn_ManageMovies);
            this.Controls.Add(this.btn_ManageCustomers);
            this.Controls.Add(this.labelAdmin);
            this.Controls.Add(this.btn_CustomerManageBookings);
            this.Controls.Add(this.btn_ViewSeats);
            this.Controls.Add(this.btn_ViewMyTickets);
            this.Controls.Add(this.btn_ViewMovies);
            this.Controls.Add(this.labelCustomer);
            this.Controls.Add(this.labelTitle);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cinema DB Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.Label labelAdmin;
        private System.Windows.Forms.Button btn_ViewMovies;
        private System.Windows.Forms.Button btn_ViewMyTickets;
        private System.Windows.Forms.Button btn_ViewSeats;
        private System.Windows.Forms.Button btn_CustomerManageBookings;
        private System.Windows.Forms.Button btn_ManageCustomers;
        private System.Windows.Forms.Button btn_ManageMovies;
        private System.Windows.Forms.Button btn_ManageCinemas;
        private System.Windows.Forms.Button btn_ManageShowtimes;
        private System.Windows.Forms.Button btn_ManageBookings;
    }
}