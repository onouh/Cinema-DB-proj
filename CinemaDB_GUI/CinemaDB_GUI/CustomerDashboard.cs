using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace CinemaDB_GUI
{
    public partial class CustomerDashboard : Form
    {
        // TODO: Update connection string with your actual SQL Server details
        private readonly string connectionString = "Server=localhost;Database=CinemaDB;Trusted_Connection=True;Encrypt=False;";
        
        // Track the current active mode
        private string currentMode = "";
        
        // Assuming a logged-in customer ID for testing purposes
        private readonly int currentCustomerId = 1;

        public CustomerDashboard()
        {
            InitializeComponent();
        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            // Initial UI Setup
            panelInput.Visible = false;
            ActivateButton(btnBrowseMovies);
            currentMode = "BrowseMovies";
            lblTitle.Text = "Browse All Movies";
            LoadAllMovies();
        }

        // -------------------------------------------------------------
        // UI Helpers
        // -------------------------------------------------------------
        private void ActivateButton(Button btn)
        {
            // Reset all buttons
            foreach (Control ctrl in panelSidebar.Controls)
            {
                if (ctrl is Button b)
                {
                    b.BackColor = Color.FromArgb(41, 53, 65);
                }
            }
            // Highlight selected button
            btn.BackColor = Color.FromArgb(229, 126, 49);
            
            // Clear inputs
            txtInput1.Text = "";
            txtInput2.Text = "";
        }

        private void SetupInputArea(string label1, string label2 = "")
        {
            panelInput.Visible = true;
            lblInput1.Text = label1;
            lblInput1.Visible = !string.IsNullOrEmpty(label1);
            txtInput1.Visible = !string.IsNullOrEmpty(label1);

            lblInput2.Text = label2;
            lblInput2.Visible = !string.IsNullOrEmpty(label2);
            txtInput2.Visible = !string.IsNullOrEmpty(label2);
        }

        // -------------------------------------------------------------
        // Navigation Buttons Events
        // -------------------------------------------------------------
        private void BtnBrowseMovies_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
            lblTitle.Text = "Browse All Movies";
            panelInput.Visible = false;
            currentMode = "BrowseMovies";
            LoadAllMovies();
        }

        private void BtnSearchGenre_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
            lblTitle.Text = "Search Movies by Genre";
            SetupInputArea("Enter Genre:");
            currentMode = "SearchGenre";
            dgvResults.DataSource = null;
        }

        private void BtnShowtimes_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
            lblTitle.Text = "View Showtimes by Movie";
            SetupInputArea("Enter Movie ID:");
            currentMode = "Showtimes";
            dgvResults.DataSource = null;
        }

        private void BtnAvailableSeats_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
            lblTitle.Text = "View Available Seats";
            SetupInputArea("Enter Showtime ID:");
            currentMode = "AvailableSeats";
            dgvResults.DataSource = null;
        }

        private void BtnMakeBooking_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
            lblTitle.Text = "Make a Booking";
            SetupInputArea("Showtime ID:", "Seat No:");
            // We can assume customer ID is currentCustomerId and Payment is cash for simplicity in this demo form
            currentMode = "MakeBooking";
            dgvResults.DataSource = null;
        }

        private void BtnMyBookings_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
            lblTitle.Text = "My Bookings & Tickets";
            panelInput.Visible = false;
            currentMode = "MyBookings";
            LoadMyBookings();
        }

        private void BtnPaymentCancel_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
            lblTitle.Text = "Payment & Cancellation";
            SetupInputArea("Booking ID:", "Action (Confirm/Cancel):");
            currentMode = "PaymentCancel";
            dgvResults.DataSource = null;
        }

        // -------------------------------------------------------------
        // Execute Action based on Current Mode
        // -------------------------------------------------------------
        private void BtnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                switch (currentMode)
                {
                    case "SearchGenre":
                        ExecuteStoredProcedure("sp_GetMoviesByGenre", new SqlParameter("@Genre", txtInput1.Text));
                        break;
                    case "Showtimes":
                        if (int.TryParse(txtInput1.Text, out int movieId))
                            ExecuteStoredProcedure("sp_GetShowtimesByMovie", new SqlParameter("@MovieID", movieId));
                        else
                            MessageBox.Show("Please enter a valid numeric Movie ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case "AvailableSeats":
                        if (int.TryParse(txtInput1.Text, out int showtimeId))
                            ExecuteStoredProcedure("sp_GetAvailableSeats", new SqlParameter("@ShowtimeID", showtimeId));
                        else
                            MessageBox.Show("Please enter a valid numeric Showtime ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case "MakeBooking":
                        MakeBooking();
                        break;
                    case "PaymentCancel":
                        PaymentOrCancel();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------------------------------------------------------------
        // Data Access Methods
        // -------------------------------------------------------------
        private void ExecuteStoredProcedure(string procName, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvResults.DataSource = dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL Error executing {procName}: \n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllMovies()
        {
            ExecuteStoredProcedure("sp_GetAllMovies");
        }

        private void LoadMyBookings()
        {
            // Load bookings for current customer
            ExecuteStoredProcedure("sp_GetMyBookings", new SqlParameter("@CustomerID", currentCustomerId));
        }

        private void MakeBooking()
        {
            if (!int.TryParse(txtInput1.Text, out int showtimeId) || !int.TryParse(txtInput2.Text, out int seatNo))
            {
                MessageBox.Show("Please enter valid numeric values for Showtime ID and Seat No.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_MakeBooking", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerID", currentCustomerId);
                        cmd.Parameters.AddWithValue("@ShowtimeID", showtimeId);
                        cmd.Parameters.AddWithValue("@SeatNo", seatNo);
                        cmd.Parameters.AddWithValue("@PaymentMethod", "Credit Card"); // Default for GUI

                        SqlParameter outBookingId = new SqlParameter("@NewBookingID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                        SqlParameter outError = new SqlParameter("@ErrorMessage", SqlDbType.VarChar, 255) { Direction = ParameterDirection.Output };
                        
                        cmd.Parameters.Add(outBookingId);
                        cmd.Parameters.Add(outError);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            string errorMsg = outError.Value?.ToString();
                            int bookingId = outBookingId.Value != DBNull.Value ? (int)outBookingId.Value : -1;

                            if (!string.IsNullOrEmpty(errorMsg))
                            {
                                MessageBox.Show(errorMsg, "Booking Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show($"Booking created successfully! Booking ID: {bookingId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvResults.DataSource = dt;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PaymentOrCancel()
        {
            if (!int.TryParse(txtInput1.Text, out int bookingId))
            {
                MessageBox.Show("Please enter a valid Booking ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string action = txtInput2.Text.Trim().ToLower();
            string procName = "";
            
            if (action == "confirm") procName = "sp_ConfirmPayment";
            else if (action == "cancel") procName = "sp_CancelBooking";
            else
            {
                MessageBox.Show("Please type 'Confirm' or 'Cancel' in Action field.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BookingID", bookingId);
                        cmd.Parameters.AddWithValue("@CustomerID", currentCustomerId);

                        SqlParameter outSuccess = new SqlParameter("@Success", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                        SqlParameter outError = new SqlParameter("@ErrorMessage", SqlDbType.VarChar, 255) { Direction = ParameterDirection.Output };
                        
                        cmd.Parameters.Add(outSuccess);
                        cmd.Parameters.Add(outError);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            bool success = outSuccess.Value != DBNull.Value && (bool)outSuccess.Value;
                            string errorMsg = outError.Value?.ToString();

                            if (!success)
                            {
                                MessageBox.Show(errorMsg ?? "Operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Operation completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvResults.DataSource = dt;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
