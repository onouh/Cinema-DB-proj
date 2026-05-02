using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class ManageCustomersForm : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=CinemaDB;Integrated Security=SSPI;TrustServerCertificate=True";

        public ManageCustomersForm()
        {
            InitializeComponent();
        }

        private void ManageCustomersForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                // Load all customers for management
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CUSTOMER", con))
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
                using (SqlCommand cmd = new SqlCommand("sp_InsertCustomer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@first_name", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@last_name", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Added Successfully!");
                    LoadData();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int customerId))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateCustomer", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@customer_id", customerId);
                        
                        // Use DBNull for empty fields to skip updating them based on the SP logic
                        cmd.Parameters.AddWithValue("@first_name", string.IsNullOrEmpty(txtFirstName.Text) ? (object)DBNull.Value : txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@last_name", string.IsNullOrEmpty(txtLastName.Text) ? (object)DBNull.Value : txtLastName.Text);
                        cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text);
                        cmd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text);
                        cmd.Parameters.AddWithValue("@password", string.IsNullOrEmpty(txtPassword.Text) ? (object)DBNull.Value : txtPassword.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Customer Updated Successfully!");
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a valid Customer ID to update.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int customerId))
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this customer? This will delete all their bookings.", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("sp_DeleteCustomer", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@customer_id", customerId);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Customer Deleted Successfully!");
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
                txtId.Text = row.Cells["customer_id"].Value.ToString();
                txtFirstName.Text = row.Cells["first_name"].Value.ToString();
                txtLastName.Text = row.Cells["last_name"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtPhone.Text = row.Cells["phone"].Value.ToString();
                txtPassword.Text = row.Cells["password"].Value.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
