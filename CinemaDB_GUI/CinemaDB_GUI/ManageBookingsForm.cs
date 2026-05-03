using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class ManageBookingsForm : Form
    {
        private string connString = DatabaseConfig.ConnectionString;

        public ManageBookingsForm()
        {
            InitializeComponent();

            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            dgv.SelectionChanged += Dgv_SelectionChanged;

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT * FROM BOOKING ORDER BY booking_date DESC", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bookings: " + ex.Message);
            }
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                txtStatus.Text = dgv.SelectedRows[0].Cells["booking_status"].Value?.ToString() ?? "";
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            int bookingId = Convert.ToInt32(dgv.SelectedRows[0].Cells["booking_id"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        @"UPDATE BOOKING SET booking_status = @booking_status
                          WHERE booking_id = @booking_id", conn);
                    cmd.Parameters.AddWithValue("@booking_id", bookingId);
                    cmd.Parameters.AddWithValue("@booking_status", txtStatus.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Booking status updated successfully!");
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating booking: " + ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            int bookingId = Convert.ToInt32(dgv.SelectedRows[0].Cells["booking_id"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM BOOKING WHERE booking_id = @booking_id", conn);
                    cmd.Parameters.AddWithValue("@booking_id", bookingId);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Booking deleted successfully!");
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting booking: " + ex.Message);
            }
        }
    }
}