using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class ManageCinemasForm : Form
    {
        private string connString = DatabaseConfig.ConnectionString;

        public ManageCinemasForm()
        {
            InitializeComponent();

            btnAdd.Click += BtnAdd_Click;
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CINEMA", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cinemas: " + ex.Message);
            }
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedRows[0];
                txtName.Text = row.Cells["name"].Value?.ToString() ?? "";
                txtAddress.Text = row.Cells["address"].Value?.ToString() ?? "";
                txtCity.Text = row.Cells["city"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["phone"].Value?.ToString() ?? "";
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
                        @"INSERT INTO CINEMA (name, address, city, phone)
                          VALUES (@name, @address, @city, @phone)", conn);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@city", txtCity.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Cinema added successfully!");
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding cinema: " + ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            int cinemaId = Convert.ToInt32(dgv.SelectedRows[0].Cells["cinema_id"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        @"UPDATE CINEMA
                          SET name = @name, address = @address, city = @city, phone = @phone
                          WHERE cinema_id = @cinema_id", conn);
                    cmd.Parameters.AddWithValue("@cinema_id", cinemaId);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@city", txtCity.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Cinema updated successfully!");
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating cinema: " + ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            int cinemaId = Convert.ToInt32(dgv.SelectedRows[0].Cells["cinema_id"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM CINEMA WHERE cinema_id = @cinema_id", conn);
                    cmd.Parameters.AddWithValue("@cinema_id", cinemaId);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Cinema deleted successfully!");
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting cinema: " + ex.Message);
            }
        }
    }
}