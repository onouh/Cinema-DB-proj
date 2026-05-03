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
    }
}