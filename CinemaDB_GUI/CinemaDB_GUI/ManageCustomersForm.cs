using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class ManageCustomersForm : Form
    {
        private string connString = "Server=YOUR_SERVER_NAME;Database=CinemaDB;Integrated Security=True;TrustServerCertificate=True;";
        private DataGridView dgv;
        private TextBox txtName, txtEmail, txtPhone;

        public ManageCustomersForm()
        {
            InitializeUI();
            RefreshGrid();
        }

        private void InitializeUI()
        {
            this.Text = "Manage Customers";
            this.Size = new Size(800, 550);
            this.BackColor = Color.WhiteSmoke;

            this.Controls.Add(new Label { Text = "Customer Database", Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true });

            this.Controls.Add(new Label { Text = "Name:", Location = new Point(20, 70), AutoSize = true });
            txtName = new TextBox { Location = new Point(80, 70), Width = 150 };

            this.Controls.Add(new Label { Text = "Email:", Location = new Point(240, 70), AutoSize = true });
            txtEmail = new TextBox { Location = new Point(290, 70), Width = 150 };

            this.Controls.Add(new Label { Text = "Phone:", Location = new Point(450, 70), AutoSize = true });
            txtPhone = new TextBox { Location = new Point(500, 70), Width = 120 };

            Button btnAdd = new Button { Text = "Add", Location = new Point(640, 68), BackColor = Color.MediumAquamarine, FlatStyle = FlatStyle.Flat };
            btnAdd.Click += (s, e) => ExecuteQuery("INSERT INTO CUSTOMER (name, email, phone) VALUES (@name, @email, @phone)");

            Button btnDelete = new Button { Text = "Delete", Location = new Point(640, 105), BackColor = Color.LightCoral, FlatStyle = FlatStyle.Flat };
            btnDelete.Click += (s, e) => {
                if (dgv.SelectedRows.Count > 0) ExecuteQuery("DELETE FROM CUSTOMER WHERE customer_id=@id", Convert.ToInt32(dgv.SelectedRows[0].Cells["customer_id"].Value));
            };

            dgv = new DataGridView { Location = new Point(20, 150), Size = new Size(740, 340), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, SelectionMode = DataGridViewSelectionMode.FullRowSelect, ReadOnly = true };
            dgv.SelectionChanged += (s, e) => {
                if (dgv.SelectedRows.Count > 0) {
                    txtName.Text = dgv.SelectedRows[0].Cells["name"].Value.ToString();
                    txtEmail.Text = dgv.SelectedRows[0].Cells["email"].Value.ToString();
                    txtPhone.Text = dgv.SelectedRows[0].Cells["phone"].Value.ToString();
                }
            };

            this.Controls.AddRange(new Control[] { txtName, txtEmail, txtPhone, btnAdd, btnDelete, dgv });
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