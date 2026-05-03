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
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MOVIE", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAdminMovies.DataSource = dt;
            }
        }

        private void DgvAdminMovies_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAdminMovies.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvAdminMovies.SelectedRows[0];
                txtTitle.Text = row.Cells["title"].Value.ToString();
                txtDesc.Text = row.Cells["description"].Value.ToString();
                txtDuration.Text = row.Cells["duration_min"].Value.ToString();
                txtLang.Text = row.Cells["language"].Value.ToString();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO MOVIE (title, description, duration_min, language) VALUES (@title, @desc, @dur, @lang)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@desc", txtDesc.Text);
                cmd.Parameters.AddWithValue("@dur", Convert.ToInt32(txtDuration.Text));
                cmd.Parameters.AddWithValue("@lang", txtLang.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            RefreshAdminGrid();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAdminMovies.SelectedRows.Count == 0) return;
            int movieId = Convert.ToInt32(dgvAdminMovies.SelectedRows[0].Cells["movie_id"].Value);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "UPDATE MOVIE SET title=@title, description=@desc, duration_min=@dur, language=@lang WHERE movie_id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", movieId);
                cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@desc", txtDesc.Text);
                cmd.Parameters.AddWithValue("@dur", Convert.ToInt32(txtDuration.Text));
                cmd.Parameters.AddWithValue("@lang", txtLang.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            RefreshAdminGrid();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAdminMovies.SelectedRows.Count == 0) return;
            int movieId = Convert.ToInt32(dgvAdminMovies.SelectedRows[0].Cells["movie_id"].Value);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "DELETE FROM MOVIE WHERE movie_id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", movieId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            RefreshAdminGrid();
        }
    }
}