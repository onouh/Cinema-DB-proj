using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class ManageCustomersForm : Form
    {
        private string connString = DatabaseConfig.ConnectionString;

        public ManageCustomersForm()
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CUSTOMER", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedRows[0];
                txtFirstName.Text = row.Cells["first_name"].Value?.ToString() ?? "";
                txtLastName.Text = row.Cells["last_name"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["email"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["phone"].Value?.ToString() ?? "";
                txtPassword.Text = row.Cells["password"].Value?.ToString() ?? "";
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
                        @"INSERT INTO CUSTOMER (first_name, last_name, email, phone, password)
                          VALUES (@first_name, @last_name, @email, @phone, @password)", conn);
                    cmd.Parameters.AddWithValue("@first_name", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@last_name", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Customer added successfully!");
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            int customerId = Convert.ToInt32(dgv.SelectedRows[0].Cells["customer_id"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        @"UPDATE CUSTOMER
                          SET first_name = @first_name, last_name = @last_name,
                              email = @email, phone = @phone, password = @password
                          WHERE customer_id = @customer_id", conn);
                    cmd.Parameters.AddWithValue("@customer_id", customerId);
                    cmd.Parameters.AddWithValue("@first_name", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@last_name", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Customer updated successfully!");
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            int customerId = Convert.ToInt32(dgv.SelectedRows[0].Cells["customer_id"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM CUSTOMER WHERE customer_id = @customer_id", conn);
                    cmd.Parameters.AddWithValue("@customer_id", customerId);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Customer deleted successfully!");
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting customer: " + ex.Message);
            }
        }
    }
}