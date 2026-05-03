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

            // Wire up event handlers
            btnAdd.Click += (s, e) => ExecuteQuery("INSERT INTO CUSTOMER (name, email, phone) VALUES (@name, @email, @phone)");

            btnDelete.Click += (s, e) =>
            {
                if (dgv.SelectedRows.Count > 0) ExecuteQuery("DELETE FROM CUSTOMER WHERE customer_id=@id", Convert.ToInt32(dgv.SelectedRows[0].Cells["customer_id"].Value));
            };

            dgv.SelectionChanged += (s, e) =>
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    txtName.Text = dgv.SelectedRows[0].Cells["name"].Value.ToString();
                    txtEmail.Text = dgv.SelectedRows[0].Cells["email"].Value.ToString();
                    txtPhone.Text = dgv.SelectedRows[0].Cells["phone"].Value.ToString();
                }
            };

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CUSTOMER", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }

        private void ExecuteQuery(string query, int? id = null)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (id.HasValue) cmd.Parameters.AddWithValue("@id", id.Value);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            RefreshGrid();
        }
    }
}