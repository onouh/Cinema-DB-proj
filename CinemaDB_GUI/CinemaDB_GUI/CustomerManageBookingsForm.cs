using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class CustomerManageBookingsForm : Form
    {
        private string connString = DatabaseConfig.ConnectionString;

        public CustomerManageBookingsForm()
        {
            InitializeComponent();

            btnLoad.Click += BtnLoad_Click;
            btnConfirm.Click += (s, e) => ExecuteBookingAction("sp_ConfirmPayment");
            btnCancel.Click += (s, e) => ExecuteBookingAction("sp_CancelBooking");
            cbViewMode.SelectedIndexChanged += CbViewMode_Changed;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int customerId))
            {
                MessageBox.Show("Enter a valid Customer ID.");
                return;
            }

            try
            {
                // Load bookings
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("sp_GetMyBookings", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBookings.DataSource = dt;
                }

                // Load stats
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    var cmd1 = new SqlCommand(
                        "SELECT dbo.fn_GetCustomerTotalSpent(@C)", conn);
                    cmd1.Parameters.AddWithValue("@C", customerId);
                    object r1 = cmd1.ExecuteScalar();
                    decimal spent = r1 != null && r1 != DBNull.Value ? Convert.ToDecimal(r1) : 0;
                    lblSpentValue.Text = spent.ToString("C");

                    var cmd2 = new SqlCommand(
                        "SELECT dbo.fn_CountCustomerBookings(@C)", conn);
                    cmd2.Parameters.AddWithValue("@C", customerId);
                    object r2 = cmd2.ExecuteScalar();
                    int count = r2 != null && r2 != DBNull.Value ? Convert.ToInt32(r2) : 0;
                    lblCountValue.Text = count.ToString();
                }

                cbViewMode.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CbViewMode_Changed(object sender, EventArgs e)
        {
            if (cbViewMode.SelectedItem == null ||
                !int.TryParse(txtCustomerId.Text, out int customerId)) return;

            string mode = cbViewMode.SelectedItem.ToString();

            try
            {
                if (mode == "Full Details")
                {
                    using var conn = new SqlConnection(connString);
                    conn.Open();
                    var cmd = new SqlCommand(
                        "SELECT * FROM dbo.fn_GetCustomerBookingDetails(@C)", conn);
                    cmd.Parameters.AddWithValue("@C", customerId);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBookings.DataSource = dt;
                }
                else
                {
                    // Confirmed, Cancelled, or All
                    using var conn = new SqlConnection(connString);
                    conn.Open();
                    var cmd = new SqlCommand(
                        "SELECT * FROM dbo.fn_GetCustomerBookingSummary(@C, @T)", conn);
                    cmd.Parameters.AddWithValue("@C", customerId);
                    cmd.Parameters.AddWithValue("@T", mode);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBookings.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ExecuteBookingAction(string procedureName)
        {
            if (dgvBookings.SelectedRows.Count == 0 || !int.TryParse(txtCustomerId.Text, out int customerId))
            {
                MessageBox.Show("Please select a booking and ensure Customer ID is entered.");
                return;
            }

            int bookingId = Convert.ToInt32(dgvBookings.SelectedRows[0].Cells["booking_id"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand(procedureName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookingID", bookingId);
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);

                    SqlParameter outSuccess = new SqlParameter("@Success", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    SqlParameter outError = new SqlParameter("@ErrorMessage", SqlDbType.VarChar, 255) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(outSuccess);
                    cmd.Parameters.Add(outError);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    bool success = Convert.ToBoolean(outSuccess.Value);
                    string errorMsg = outError.Value?.ToString() ?? "";

                    if (success)
                    {
                        MessageBox.Show("Action completed successfully!");
                        BtnLoad_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Action failed: " + errorMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }
    }
}