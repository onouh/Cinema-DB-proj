using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class ManageMoviesForm : Form
    {
        private string connString = DatabaseConfig.ConnectionString;

        public ManageMoviesForm()
        {
            InitializeComponent();

            // Wire up event handlers
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            dgvAdminMovies.SelectionChanged += DgvAdminMovies_SelectionChanged;

            RefreshAdminGrid();
        }

        private void RefreshAdminGrid()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MOVIE", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAdminMovies.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading movies: " + ex.Message);
            }
        }

        private void DgvAdminMovies_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAdminMovies.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvAdminMovies.SelectedRows[0];
                txtTitle.Text = row.Cells["title"].Value.ToString();
                txtDesc.Text = row.Cells["description"].Value?.ToString() ?? "";
                txtDuration.Text = row.Cells["duration_min"].Value.ToString();
                txtLang.Text = row.Cells["language"].Value?.ToString() ?? "";
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertMovie", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@description", txtDesc.Text);
                    cmd.Parameters.AddWithValue("@duration_min", Convert.ToInt32(txtDuration.Text));
                    cmd.Parameters.AddWithValue("@language", txtLang.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Movie added successfully!");
                RefreshAdminGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding movie: " + ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAdminMovies.SelectedRows.Count == 0) return;
            int movieId = Convert.ToInt32(dgvAdminMovies.SelectedRows[0].Cells["movie_id"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateMovie", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@movie_id", movieId);
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@description", txtDesc.Text);
                    cmd.Parameters.AddWithValue("@duration_min", Convert.ToInt32(txtDuration.Text));
                    cmd.Parameters.AddWithValue("@language", txtLang.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Movie updated successfully!");
                RefreshAdminGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating movie: " + ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAdminMovies.SelectedRows.Count == 0) return;
            int movieId = Convert.ToInt32(dgvAdminMovies.SelectedRows[0].Cells["movie_id"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("sp_DeleteMovie", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@movie_id", movieId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Movie deleted successfully!");
                RefreshAdminGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting movie: " + ex.Message);
            }
        }
    }
}