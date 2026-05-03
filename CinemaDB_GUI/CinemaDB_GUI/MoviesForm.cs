using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class MoviesForm : Form
    {
        private string connString = DatabaseConfig.ConnectionString;

        public MoviesForm()
        {
            InitializeComponent();

            // Wire up event handlers
            btnFilter.Click += BtnFilter_Click;
            btnClear.Click += (s, e) => { cbGenres.SelectedIndex = -1; LoadMovies(); };
            btnShowtimes.Click += BtnShowtimes_Click;
            cbSlotType.SelectedIndexChanged += CbSlotType_Changed;

            LoadMovies();
        }

        private void LoadMovies()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllMovies", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMovies.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading movies: " + ex.Message);
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            if (cbGenres.SelectedItem == null) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("sp_GetMoviesByGenre", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Genre", cbGenres.SelectedItem.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMovies.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering movies: " + ex.Message);
            }
        }

        private void BtnShowtimes_Click(object sender, EventArgs e)
        {
            if (dgvMovies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a movie first.");
                return;
            }

            int movieId = Convert.ToInt32(dgvMovies.SelectedRows[0].Cells["movie_id"].Value);
            string title = dgvMovies.SelectedRows[0].Cells["title"].Value.ToString();
            lblShowtimes.Text = $"Showtimes for: {title}";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("sp_GetShowtimesByMovie", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MovieID", movieId);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvShowtimes.DataSource = dt;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("No showtimes found for this movie.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading showtimes: " + ex.Message);
            }
        }

        private void CbSlotType_Changed(object sender, EventArgs e)
        {
            if (cbSlotType.SelectedItem == null) return;
            string slotType = cbSlotType.SelectedItem.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT * FROM dbo.fn_GetMoviesBySlotType(@SlotType)", conn);
                    cmd.Parameters.AddWithValue("@SlotType", slotType);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvShowtimes.DataSource = dt;
                    lblShowtimes.Text = $"Showtimes: {slotType}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering by slot type: " + ex.Message);
            }
        }
    }
}