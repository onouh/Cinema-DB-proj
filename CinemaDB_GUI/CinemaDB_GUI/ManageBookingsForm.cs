using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class ManageBookingsForm : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=CinemaDB;Integrated Security=SSPI;TrustServerCertificate=True";

        public ManageBookingsForm()
        {
            InitializeComponent();
        }

        private void ManageBookingsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM BOOKING", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvData.DataSource = dt;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCustomerId.Text, out int customerId) &&
                DateTime.TryParse(txtBookingDate.Text, out DateTime date))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_InsertBooking", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@customer_id", customerId);
                        cmd.Parameters.AddWithValue("@booking_date", date);
                        cmd.Parameters.AddWithValue("@booking_status", string.IsNullOrEmpty(txtStatus.Text) ? "pending" : txtStatus.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Booking Added Successfully!");
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please check Customer ID and Date values.");
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int bookingId))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateBookingStatus", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@booking_id", bookingId);
                        cmd.Parameters.AddWithValue("@booking_status", txtStatus.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Booking Status Updated Successfully!");
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a valid Booking ID.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int bookingId))
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this booking? This will delete all its tickets.", "Confirm Delete", MessageBoxButtons.YesNo);
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

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];
                txtId.Text = row.Cells["booking_id"].Value.ToString();
                txtCustomerId.Text = row.Cells["customer_id"].Value.ToString();
                txtStatus.Text = row.Cells["booking_status"].Value.ToString();
                
                if (DateTime.TryParse(row.Cells["booking_date"].Value?.ToString(), out DateTime date))
                    txtBookingDate.Text = date.ToString("yyyy-MM-dd");
                else
                    txtBookingDate.Text = row.Cells["booking_date"].Value?.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
