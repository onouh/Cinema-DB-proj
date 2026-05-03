using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

public partial class AvailableSeatsForm : Form
{
    string connectionString = "Server=YOUR_SERVER;Database=Cinema Ticket Booking;Trusted_Connection=True;";
    int currentShowtimeId;
    int customerId = 1; // Assuming a logged-in user
    decimal ticketPrice = 15.00m; // Example price
    List<int> selectedSeats = new List<int>();

    public AvailableSeatsForm(int showtimeId)
    {
        InitializeComponent();
        currentShowtimeId = showtimeId;
    }

    private void AvailableSeatsForm_Load(object sender, EventArgs e)
    {
        LoadSeats();
    }

    private void LoadSeats()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            // Assuming a Stored Procedure from your SQL file
            string query = "EXEC GetAvailableSeats @ShowtimeID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ShowtimeID", currentShowtimeId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Button seatBtn = new Button();
                    seatBtn.Text = reader["SeatNumber"].ToString();
                    seatBtn.Tag = reader["SeatID"]; // Store ID invisibly
                    bool isAvailable = Convert.ToBoolean(reader["IsAvailable"]);
                    
                    seatBtn.BackColor = isAvailable ? Color.LightGreen : Color.LightGray;
                    seatBtn.Enabled = isAvailable;
                    
                    if (isAvailable)
                    {
                        seatBtn.Click += Seat_Click;
                    }
                    
                    seatFlowPanel.Controls.Add(seatBtn); // Add to UI
                }
            }
        }
    }

    private void Seat_Click(object sender, EventArgs e)
    {
        Button clickedSeat = sender as Button;
        int seatId = Convert.ToInt32(clickedSeat.Tag);

        if (clickedSeat.BackColor == Color.LightGreen)
        {
            clickedSeat.BackColor = Color.LightBlue; // Mark selected
            selectedSeats.Add(seatId);
        }
        else
        {
            clickedSeat.BackColor = Color.LightGreen; // Deselect
            selectedSeats.Remove(seatId);
        }
        
        lblTotalPrice.Text = $"Total: ${(selectedSeats.Count * ticketPrice)}";
    }

    private void btnConfirmBooking_Click(object sender, EventArgs e)
    {
        if (selectedSeats.Count == 0) return;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            // Start Transaction to lock data
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    // 1. Create Booking
                    string bookingQuery = "INSERT INTO Bookings (CustomerID, ShowtimeID, TotalPrice, BookingDate) OUTPUT INSERTED.BookingID VALUES (@CustID, @ShowID, @Price, GETDATE())";
                    SqlCommand cmdBooking = new SqlCommand(bookingQuery, conn, transaction);
                    cmdBooking.Parameters.AddWithValue("@CustID", customerId);
                    cmdBooking.Parameters.AddWithValue("@ShowID", currentShowtimeId);
                    cmdBooking.Parameters.AddWithValue("@Price", selectedSeats.Count * ticketPrice);
                    
                    int newBookingId = (int)cmdBooking.ExecuteScalar();

                    // 2. Create Tickets
                    foreach (int seatId in selectedSeats)
                    {
                        string ticketQuery = "INSERT INTO Tickets (BookingID, SeatID) VALUES (@BookID, @SeatID)";
                        SqlCommand cmdTicket = new SqlCommand(ticketQuery, conn, transaction);
                        cmdTicket.Parameters.AddWithValue("@BookID", newBookingId);
                        cmdTicket.Parameters.AddWithValue("@SeatID", seatId);
                        cmdTicket.ExecuteNonQuery();
                    }

                    // 3. Commit
                    transaction.Commit();
                    MessageBox.Show("Booking Successful!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Booking Failed: " + ex.Message);
                }
            }
        }
    }
}