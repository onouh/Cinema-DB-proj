using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class CustomerTicketsForm : Form
{
    string connectionString = "Server=YOUR_SERVER;Database=Cinema Ticket Booking;Trusted_Connection=True;";
    int currentCustomerId = 1; 

    public CustomerTicketsForm()
    {
        InitializeComponent();
    }

    private void CustomerTicketsForm_Load(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            // Use the comprehensive view from your SQL file here
            string query = @"
                SELECT m.Title, c.RoomName, s.StartTime, t.SeatNumber 
                FROM Tickets t
                JOIN Bookings b ON t.BookingID = b.BookingID
                JOIN Showtimes s ON b.ShowtimeID = s.ShowtimeID
                JOIN Movies m ON s.MovieID = m.MovieID
                JOIN Cinemas c ON s.CinemaID = c.CinemaID
                WHERE b.CustomerID = @CustID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CustID", currentCustomerId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                dgvTickets.DataSource = dt;
            }
        }
    }
}