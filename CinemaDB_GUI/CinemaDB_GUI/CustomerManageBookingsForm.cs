using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class CustomerManageBookingsForm : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=CinemaDB;Integrated Security=SSPI;TrustServerCertificate=True";

        public CustomerManageBookingsForm()
        {
            InitializeComponent();
        }

        private void btnLoadBookings_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (int.TryParse(textBoxCustomerId.Text, out int customerId))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM BOOKING WHERE customer_id = @customer_id", con))
                    {
                        cmd.Parameters.AddWithValue("@customer_id", customerId);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvBookings.DataSource = dt;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric Customer ID.");
            }
        }

        private void btnDeleteBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                if (int.TryParse(dgvBookings.SelectedRows[0].Cells["booking_id"].Value?.ToString(), out int bookingId))
                {
                    var confirm = MessageBox.Show("Are you sure you want to delete this booking? This will cancel all tickets.", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            con.Open();
                            using (SqlCommand cmd = new SqlCommand("sp_DeleteBooking", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@booking_id", bookingId);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Booking Deleted Successfully!");
                                LoadData();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a full row to delete.");
            }
        }

        private void btnViewAvailableSeats_Click(object sender, EventArgs e)
        {
            AvailableSeatsForm seatsForm = new AvailableSeatsForm();
            seatsForm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
