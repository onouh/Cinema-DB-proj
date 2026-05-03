using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class CustomerManageBookingsForm : Form
{
    string connectionString = "Server=YOUR_SERVER;Database=Cinema Ticket Booking;Trusted_Connection=True;";
    int currentCustomerId = 1;

    public CustomerManageBookingsForm()
    {
        InitializeComponent();
    }

    private void CustomerManageBookingsForm_Load(object sender, EventArgs e)
    {
        LoadBookings();
    }

    private void LoadBookings()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT BookingID, BookingDate, TotalPrice, Status FROM Bookings WHERE CustomerID = @CustID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CustID", currentCustomerId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvBookings.DataSource = dt;
            }
        }
    }

    private void btnCancelBooking_Click(object sender, EventArgs e)
    {
        if (dgvBookings.SelectedRows.Count > 0)
        {
            int bookingId = Convert.ToInt32(dgvBookings.SelectedRows[0].Cells["BookingID"].Value);

            var confirmResult = MessageBox.Show("Are you sure to cancel this booking?", "Confirm Cancel", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Assumes a Stored Procedure from your backend
                    string query = "UPDATE Bookings SET Status = 'Cancelled' WHERE BookingID = @BookID; DELETE FROM Tickets WHERE BookingID = @BookID;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookID", bookingId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Booking Cancelled.");
                LoadBookings(); // Refresh grid
            }
        }
    }
}