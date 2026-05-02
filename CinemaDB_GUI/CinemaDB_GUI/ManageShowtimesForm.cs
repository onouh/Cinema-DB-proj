using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class ManageShowtimesForm : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=CinemaDB;Integrated Security=SSPI;TrustServerCertificate=True";

        public ManageShowtimesForm()
        {
            InitializeComponent();
        }

        private void ManageShowtimesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM SHOWTIME", con))
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
            if (int.TryParse(txtMovieId.Text, out int movieId) &&
                int.TryParse(txtHallNo.Text, out int hallNo) &&
                int.TryParse(txtCinemaId.Text, out int cinemaId) &&
                DateTime.TryParse(txtDate.Text, out DateTime date))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_InsertShowtime", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@movie_id", movieId);
                        cmd.Parameters.AddWithValue("@hall_no", hallNo);
                        cmd.Parameters.AddWithValue("@cinema_id", cinemaId);
                        cmd.Parameters.AddWithValue("@slot", txtSlot.Text);
                        cmd.Parameters.AddWithValue("@date", date);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Showtime Added Successfully!");
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please check the numeric and date values.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int showtimeId) &&
                int.TryParse(txtMovieId.Text, out int movieId) &&
                int.TryParse(txtHallNo.Text, out int hallNo) &&
                int.TryParse(txtCinemaId.Text, out int cinemaId) &&
                DateTime.TryParse(txtDate.Text, out DateTime date))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateShowtime", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@showtime_id", showtimeId);
                        cmd.Parameters.AddWithValue("@movie_id", movieId);
                        cmd.Parameters.AddWithValue("@hall_no", hallNo);
                        cmd.Parameters.AddWithValue("@cinema_id", cinemaId);
                        cmd.Parameters.AddWithValue("@slot", string.IsNullOrEmpty(txtSlot.Text) ? (object)DBNull.Value : txtSlot.Text);
                        cmd.Parameters.AddWithValue("@date", date);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Showtime Updated Successfully!");
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please check the ID, numeric, and date values.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int showtimeId))
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this showtime?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("sp_DeleteShowtime", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@showtime_id", showtimeId);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Showtime Deleted Successfully!");
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
                txtId.Text = row.Cells["showtime_id"].Value.ToString();
                txtMovieId.Text = row.Cells["movie_id"].Value.ToString();
                txtHallNo.Text = row.Cells["hall_no"].Value.ToString();
                txtCinemaId.Text = row.Cells["cinema_id"].Value.ToString();
                txtSlot.Text = row.Cells["slot"].Value.ToString();
                
                if (DateTime.TryParse(row.Cells["date"].Value?.ToString(), out DateTime date))
                    txtDate.Text = date.ToString("yyyy-MM-dd");
                else
                    txtDate.Text = row.Cells["date"].Value?.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
