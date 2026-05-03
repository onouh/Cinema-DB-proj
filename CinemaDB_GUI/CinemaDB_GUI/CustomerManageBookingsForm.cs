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

            // Wire up event handlers
            btnLoad.Click += BtnLoad_Click;
            btnConfirm.Click += (s, e) => ExecuteBookingAction("sp_ConfirmPayment");
            btnCancel.Click += (s, e) => ExecuteBookingAction("sp_CancelBooking");
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int customerId)) return;

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
                    string errorMsg = outError.Value.ToString();

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