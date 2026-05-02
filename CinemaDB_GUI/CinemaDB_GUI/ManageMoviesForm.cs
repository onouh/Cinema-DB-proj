using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class ManageMoviesForm : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=CinemaDB;Integrated Security=SSPI;TrustServerCertificate=True";

        public ManageMoviesForm()
        {
            InitializeComponent();
        }

        private void ManageMoviesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM MOVIE", con))
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
            if (int.TryParse(txtDuration.Text, out int duration))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_InsertMovie", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                        cmd.Parameters.AddWithValue("@description", string.IsNullOrEmpty(txtDescription.Text) ? (object)DBNull.Value : txtDescription.Text);
                        cmd.Parameters.AddWithValue("@duration_min", duration);
                        cmd.Parameters.AddWithValue("@language", string.IsNullOrEmpty(txtLanguage.Text) ? (object)DBNull.Value : txtLanguage.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Movie Added Successfully!");
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric duration.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int movieId) && int.TryParse(txtDuration.Text, out int duration))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateMovie", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@movie_id", movieId);
                        cmd.Parameters.AddWithValue("@title", string.IsNullOrEmpty(txtTitle.Text) ? (object)DBNull.Value : txtTitle.Text);
                        cmd.Parameters.AddWithValue("@description", string.IsNullOrEmpty(txtDescription.Text) ? (object)DBNull.Value : txtDescription.Text);
                        cmd.Parameters.AddWithValue("@duration_min", duration);
                        cmd.Parameters.AddWithValue("@language", string.IsNullOrEmpty(txtLanguage.Text) ? (object)DBNull.Value : txtLanguage.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Movie Updated Successfully!");
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please check the ID and Duration values.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int movieId))
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this movie? This will delete all associated showtimes and tickets.", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("sp_DeleteMovie", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@movie_id", movieId);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Movie Deleted Successfully!");
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
                txtId.Text = row.Cells["movie_id"].Value.ToString();
                txtTitle.Text = row.Cells["title"].Value.ToString();
                txtDescription.Text = row.Cells["description"].Value.ToString();
                txtDuration.Text = row.Cells["duration_min"].Value.ToString();
                txtLanguage.Text = row.Cells["language"].Value.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
