using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class ManageCinemasForm : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=CinemaDB;Integrated Security=SSPI;TrustServerCertificate=True";

        public ManageCinemasForm()
        {
            InitializeComponent();
        }

        private void ManageCinemasForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CINEMA", con))
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
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_InsertCinema", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@city", txtCity.Text);
                    cmd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cinema Added Successfully!");
                    LoadData();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int cinemaId))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateCinema", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cinema_id", cinemaId);
                        cmd.Parameters.AddWithValue("@name", string.IsNullOrEmpty(txtName.Text) ? (object)DBNull.Value : txtName.Text);
                        cmd.Parameters.AddWithValue("@address", string.IsNullOrEmpty(txtAddress.Text) ? (object)DBNull.Value : txtAddress.Text);
                        cmd.Parameters.AddWithValue("@city", string.IsNullOrEmpty(txtCity.Text) ? (object)DBNull.Value : txtCity.Text);
                        cmd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cinema Updated Successfully!");
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a valid Cinema ID.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int cinemaId))
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this cinema? This will delete all its halls, seats, and showtimes.", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("sp_DeleteCinema", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@cinema_id", cinemaId);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cinema Deleted Successfully!");
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
                txtId.Text = row.Cells["cinema_id"].Value.ToString();
                txtName.Text = row.Cells["name"].Value.ToString();
                txtAddress.Text = row.Cells["address"].Value.ToString();
                txtCity.Text = row.Cells["city"].Value.ToString();
                txtPhone.Text = row.Cells["phone"].Value.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
