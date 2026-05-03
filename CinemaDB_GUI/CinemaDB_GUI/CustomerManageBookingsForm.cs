using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class CustomerManageBookingsForm : Form
    {
        private string connString = "Server=YOUR_SERVER_NAME;Database=CinemaDB;Integrated Security=True;TrustServerCertificate=True;";
        
        private TextBox txtCustomerId;
        private DataGridView dgvBookings;
        private Button btnLoad, btnConfirm, btnCancel;

        public CustomerManageBookingsForm()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Manage My Bookings";
            this.Size = new Size(850, 550);
            this.BackColor = Color.WhiteSmoke;

            Label lblTitle = new Label { Text = "Manage Bookings", Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true };
            
            this.Controls.Add(new Label { Text = "Customer ID:", Location = new Point(20, 70), AutoSize = true });
            txtCustomerId = new TextBox { Location = new Point(120, 68), Width = 100 };

            btnLoad = new Button { Text = "Load Bookings", Location = new Point(230, 65), BackColor = Color.LightSkyBlue, FlatStyle = FlatStyle.Flat };
            btnLoad.Click += BtnLoad_Click;

            btnConfirm = new Button { Text = "Confirm Payment", Location = new Point(500, 65), BackColor = Color.MediumAquamarine, FlatStyle = FlatStyle.Flat, Width = 150 };
            btnConfirm.Click += (s, e) => ExecuteBookingAction("sp_ConfirmPayment");

            btnCancel = new Button { Text = "Cancel Booking", Location = new Point(660, 65), BackColor = Color.LightCoral, FlatStyle = FlatStyle.Flat, Width = 150 };
            btnCancel.Click += (s, e) => ExecuteBookingAction("sp_CancelBooking");

            dgvBookings = new DataGridView 
            { 
                Location = new Point(20, 120), 
                Size = new Size(790, 360),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            this.Controls.Add(lblTitle); this.Controls.Add(txtCustomerId);
            this.Controls.Add(btnLoad); this.Controls.Add(btnConfirm); this.Controls.Add(btnCancel);
            this.Controls.Add(dgvBookings);
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int customerId)) return;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetMyBookings", conn);
                cmd.CommandType = CommandType.StoredProcedure; //[cite: 8]
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

                    // Input Parameters[cite: 8]
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);

                    // Output Parameters[cite: 8]
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
                        BtnLoad_Click(null, null); // Refresh grid
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