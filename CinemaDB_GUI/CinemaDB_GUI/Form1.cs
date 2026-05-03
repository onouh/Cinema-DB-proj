using System;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ── Customer Section ──
        private void btn_ViewMovies_Click(object sender, EventArgs e) => new MoviesForm().Show();
        private void btn_ViewMyTickets_Click(object sender, EventArgs e) => new CustomerTicketsForm().Show();
        private void btn_ViewSeats_Click(object sender, EventArgs e) => new AvailableSeatsForm().Show();
        private void btn_CustomerManageBookings_Click(object sender, EventArgs e) => new CustomerManageBookingsForm().Show();
        private void btn_BookTicket_Click(object sender, EventArgs e) => new MakeBookingForm().Show();

        // ── Admin Section ──
        private void btn_ManageCustomers_Click(object sender, EventArgs e) => new ManageCustomersForm().Show();
        private void btn_ManageMovies_Click(object sender, EventArgs e) => new ManageMoviesForm().Show();
        private void btn_ManageCinemas_Click(object sender, EventArgs e) => new ManageCinemasForm().Show();
        private void btn_ManageShowtimes_Click(object sender, EventArgs e) => new ManageShowtimesForm().Show();
        private void btn_ManageBookings_Click(object sender, EventArgs e) => new ManageBookingsForm().Show();
    }
}