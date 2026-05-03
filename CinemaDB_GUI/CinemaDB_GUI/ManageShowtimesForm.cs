using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class ManageShowtimesForm : Form
    {
        private string connString = DatabaseConfig.ConnectionString;

        public ManageShowtimesForm()
        {
            InitializeComponent();

            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SHOWTIME", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading showtimes: " + ex.Message);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO SHOWTIME (movie_id, hall_no, cinema_id, slot, date)
                          VALUES (@movie_id, @hall_no, @cinema_id, @slot, @date)", conn);
                    cmd.Parameters.AddWithValue("@movie_id", Convert.ToInt32(txtMovieId.Text));
                    cmd.Parameters.AddWithValue("@hall_no", Convert.ToInt32(txtHall.Text));
                    cmd.Parameters.AddWithValue("@cinema_id", Convert.ToInt32(txtCinemaId.Text));
                    cmd.Parameters.AddWithValue("@slot", txtSlot.Text);
                    cmd.Parameters.AddWithValue("@date", dtpDate.Value.Date);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Showtime added successfully!");
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding showtime: " + ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            int showtimeId = Convert.ToInt32(dgv.SelectedRows[0].Cells["showtime_id"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM SHOWTIME WHERE showtime_id = @showtime_id", conn);
                    cmd.Parameters.AddWithValue("@showtime_id", showtimeId);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Showtime deleted successfully!");
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting showtime: " + ex.Message);
            }
        }
    }
}