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
            labelTitle = new Label();
            labelCustomer = new Label();
            labelAdmin = new Label();
            btn_ViewMovies = new Button();
            btn_ViewMyTickets = new Button();
            btn_ViewSeats = new Button();
            btn_CustomerManageBookings = new Button();
            btn_ManageCustomers = new Button();
            btn_ManageMovies = new Button();
            btn_ManageCinemas = new Button();
            btn_ManageShowtimes = new Button();
            btn_ManageBookings = new Button();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            labelTitle.Location = new Point(220, 30);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(393, 54);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Cinema DB Manager";
            // 
            // labelCustomer
            // 
            labelCustomer.AutoSize = true;
            labelCustomer.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            labelCustomer.ForeColor = Color.DarkSlateGray;
            labelCustomer.Location = new Point(100, 120);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(188, 31);
            labelCustomer.TabIndex = 1;
            labelCustomer.Text = "Customer Views";
            // 
            // btn_ViewMovies
            // 
            btn_ViewMovies.BackColor = Color.LightSkyBlue;
            btn_ViewMovies.FlatStyle = FlatStyle.Flat;
            btn_ViewMovies.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_ViewMovies.Location = new Point(100, 170);
            btn_ViewMovies.Name = "btn_ViewMovies";
            btn_ViewMovies.Size = new Size(250, 55);
            btn_ViewMovies.TabIndex = 2;
            btn_ViewMovies.Text = "View Available Movies";
            btn_ViewMovies.UseVisualStyleBackColor = false;
            btn_ViewMovies.Click += btn_ViewMovies_Click;
            // 
            // btn_ViewMyTickets
            // 
            btn_ViewMyTickets.BackColor = Color.LightSkyBlue;
            btn_ViewMyTickets.FlatStyle = FlatStyle.Flat;
            btn_ViewMyTickets.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_ViewMyTickets.Location = new Point(100, 240);
            btn_ViewMyTickets.Name = "btn_ViewMyTickets";
            btn_ViewMyTickets.Size = new Size(250, 55);
            btn_ViewMyTickets.TabIndex = 3;
            btn_ViewMyTickets.Text = "View My Tickets";
            btn_ViewMyTickets.UseVisualStyleBackColor = false;
            btn_ViewMyTickets.Click += btn_ViewMyTickets_Click;
            // 
            // btn_ViewSeats
            // 
            btn_ViewSeats.BackColor = Color.LightSkyBlue;
            btn_ViewSeats.FlatStyle = FlatStyle.Flat;
            btn_ViewSeats.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_ViewSeats.Location = new Point(100, 310);
            btn_ViewSeats.Name = "btn_ViewSeats";
            btn_ViewSeats.Size = new Size(250, 55);
            btn_ViewSeats.TabIndex = 4;
            btn_ViewSeats.Text = "View Available Seats";
            btn_ViewSeats.UseVisualStyleBackColor = false;
            btn_ViewSeats.Click += btn_ViewSeats_Click;
            // 
            // btn_CustomerManageBookings
            // 
            btn_CustomerManageBookings.BackColor = Color.LightSkyBlue;
            btn_CustomerManageBookings.FlatStyle = FlatStyle.Flat;
            btn_CustomerManageBookings.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_CustomerManageBookings.Location = new Point(100, 380);
            btn_CustomerManageBookings.Name = "btn_CustomerManageBookings";
            btn_CustomerManageBookings.Size = new Size(250, 55);
            btn_CustomerManageBookings.TabIndex = 11;
            btn_CustomerManageBookings.Text = "Manage My Bookings";
            btn_CustomerManageBookings.UseVisualStyleBackColor = false;
            btn_CustomerManageBookings.Click += btn_CustomerManageBookings_Click;
            // 
            // labelAdmin
            // 
            labelAdmin.AutoSize = true;
            labelAdmin.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            labelAdmin.ForeColor = Color.DarkSlateGray;
            labelAdmin.Location = new Point(480, 120);
            labelAdmin.Name = "labelAdmin";
            labelAdmin.Size = new Size(260, 31);
            labelAdmin.TabIndex = 5;
            labelAdmin.Text = "Admin CRUD Controls";
            // 
            // btn_ManageCustomers
            // 
            btn_ManageCustomers.BackColor = Color.MediumAquamarine;
            btn_ManageCustomers.FlatStyle = FlatStyle.Flat;
            btn_ManageCustomers.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_ManageCustomers.Location = new Point(480, 170);
            btn_ManageCustomers.Name = "btn_ManageCustomers";
            btn_ManageCustomers.Size = new Size(250, 55);
            btn_ManageCustomers.TabIndex = 6;
            btn_ManageCustomers.Text = "Manage Customers";
            btn_ManageCustomers.UseVisualStyleBackColor = false;
            btn_ManageCustomers.Click += btn_ManageCustomers_Click;
            // 
            // btn_ManageMovies
            // 
            btn_ManageMovies.BackColor = Color.MediumAquamarine;
            btn_ManageMovies.FlatStyle = FlatStyle.Flat;
            btn_ManageMovies.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_ManageMovies.Location = new Point(480, 240);
            btn_ManageMovies.Name = "btn_ManageMovies";
            btn_ManageMovies.Size = new Size(250, 55);
            btn_ManageMovies.TabIndex = 7;
            btn_ManageMovies.Text = "Manage Movies";
            btn_ManageMovies.UseVisualStyleBackColor = false;
            btn_ManageMovies.Click += btn_ManageMovies_Click;
            // 
            // btn_ManageCinemas
            // 
            btn_ManageCinemas.BackColor = Color.MediumAquamarine;
            btn_ManageCinemas.FlatStyle = FlatStyle.Flat;
            btn_ManageCinemas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_ManageCinemas.Location = new Point(480, 310);
            btn_ManageCinemas.Name = "btn_ManageCinemas";
            btn_ManageCinemas.Size = new Size(250, 55);
            btn_ManageCinemas.TabIndex = 8;
            btn_ManageCinemas.Text = "Manage Cinemas";
            btn_ManageCinemas.UseVisualStyleBackColor = false;
            btn_ManageCinemas.Click += btn_ManageCinemas_Click;
            // 
            // btn_ManageShowtimes
            // 
            btn_ManageShowtimes.BackColor = Color.MediumAquamarine;
            btn_ManageShowtimes.FlatStyle = FlatStyle.Flat;
            btn_ManageShowtimes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_ManageShowtimes.Location = new Point(480, 380);
            btn_ManageShowtimes.Name = "btn_ManageShowtimes";
            btn_ManageShowtimes.Size = new Size(250, 55);
            btn_ManageShowtimes.TabIndex = 9;
            btn_ManageShowtimes.Text = "Manage Showtimes";
            btn_ManageShowtimes.UseVisualStyleBackColor = false;
            btn_ManageShowtimes.Click += btn_ManageShowtimes_Click;
            // 
            // btn_ManageBookings
            // 
            btn_ManageBookings.BackColor = Color.MediumAquamarine;
            btn_ManageBookings.FlatStyle = FlatStyle.Flat;
            btn_ManageBookings.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_ManageBookings.Location = new Point(480, 450);
            btn_ManageBookings.Name = "btn_ManageBookings";
            btn_ManageBookings.Size = new Size(250, 55);
            btn_ManageBookings.TabIndex = 10;
            btn_ManageBookings.Text = "Manage Bookings";
            btn_ManageBookings.UseVisualStyleBackColor = false;
            btn_ManageBookings.Click += btn_ManageBookings_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(840, 550);
            Controls.Add(btn_ManageBookings);
            Controls.Add(btn_ManageShowtimes);
            Controls.Add(btn_ManageCinemas);
            Controls.Add(btn_ManageMovies);
            Controls.Add(btn_ManageCustomers);
            Controls.Add(labelAdmin);
            Controls.Add(btn_CustomerManageBookings);
            Controls.Add(btn_ViewSeats);
            Controls.Add(btn_ViewMyTickets);
            Controls.Add(btn_ViewMovies);
            Controls.Add(labelCustomer);
            Controls.Add(labelTitle);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cinema DB Dashboard";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelCustomer;
        private Label labelAdmin;
        private Button btn_ViewMovies;
        private Button btn_ViewMyTickets;
        private Button btn_ViewSeats;
        private Button btn_CustomerManageBookings;
        private Button btn_ManageCustomers;
        private Button btn_ManageMovies;
        private Button btn_ManageCinemas;
        private Button btn_ManageShowtimes;
        private Button btn_ManageBookings;
    }
}
