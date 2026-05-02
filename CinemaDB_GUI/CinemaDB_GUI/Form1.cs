using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // ── Customer Section ──

        private void btn_ViewMovies_Click(object sender, EventArgs e)
        {
            MoviesForm moviesForm = new MoviesForm();
            moviesForm.Show();
        }

        private void btn_ViewMyTickets_Click(object sender, EventArgs e)
        {
            CustomerTicketsForm ticketsForm = new CustomerTicketsForm();
            ticketsForm.Show();
        }

        private void btn_ViewSeats_Click(object sender, EventArgs e)
        {
            AvailableSeatsForm seatsForm = new AvailableSeatsForm();
            seatsForm.Show();
        }

        // ── Admin Section ──

        private void btn_ManageCustomers_Click(object sender, EventArgs e)
        {
            ManageCustomersForm form = new ManageCustomersForm();
            form.Show();
        }

        private void btn_ManageMovies_Click(object sender, EventArgs e)
        {
            ManageMoviesForm form = new ManageMoviesForm();
            form.Show();
        }

        private void btn_ManageCinemas_Click(object sender, EventArgs e)
        {
            ManageCinemasForm form = new ManageCinemasForm();
            form.Show();
        }

        private void btn_ManageShowtimes_Click(object sender, EventArgs e)
        {
            ManageShowtimesForm form = new ManageShowtimesForm();
            form.Show();
        }

        private void btn_ManageBookings_Click(object sender, EventArgs e)
        {
            ManageBookingsForm form = new ManageBookingsForm();
            form.Show();
        }
    }
}
