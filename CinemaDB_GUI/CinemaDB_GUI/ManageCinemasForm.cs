using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class ManageCinemasForm : Form
    {
        private string connString = "Server=YOUR_SERVER_NAME;Database=CinemaDB;Integrated Security=True;TrustServerCertificate=True;";
        private DataGridView dgv;
        private TextBox txtName, txtCity;

        public ManageCinemasForm()
        {
            InitializeUI();
            RefreshGrid();
        }

        private void InitializeUI()
        {
            this.Text = "Manage Cinemas";
            this.Size = new Size(600, 500);
            this.BackColor = Color.WhiteSmoke;

            this.Controls.Add(new Label { Text = "Cinema Database", Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true });

            this.Controls.Add(new Label { Text = "Name:", Location = new Point(20, 70), AutoSize = true });
            txtName = new TextBox { Location = new Point(80, 70), Width = 150 };

            this.Controls.Add(new Label { Text = "City:", Location = new Point(250, 70), AutoSize = true });
            txtCity = new TextBox { Location = new Point(290, 70), Width = 150 };

            Button btnAdd = new Button { Text = "Add", Location = new Point(460, 68), BackColor = Color.MediumAquamarine, FlatStyle = FlatStyle.Flat };
            btnAdd.Click += (s, e) => ExecuteQuery("INSERT INTO CINEMA (name, city) VALUES (@name, @city)");

            Button btnDelete = new Button { Text = "Delete", Location = new Point(460, 105), BackColor = Color.LightCoral, FlatStyle = FlatStyle.Flat };
            btnDelete.Click += (s, e) => {
                if (dgv.SelectedRows.Count > 0) ExecuteQuery("DELETE FROM CINEMA WHERE cinema_id=@id", Convert.ToInt32(dgv.SelectedRows[0].Cells["cinema_id"].Value));
            };

            dgv = new DataGridView { Location = new Point(20, 150), Size = new Size(540, 290), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, SelectionMode = DataGridViewSelectionMode.FullRowSelect, ReadOnly = true };
            dgv.SelectionChanged += (s, e) => {
                if (dgv.SelectedRows.Count > 0) {
                    txtName.Text = dgv.SelectedRows[0].Cells["name"].Value.ToString();
                    txtCity.Text = dgv.SelectedRows[0].Cells["city"].Value.ToString();
                }
            };

            this.Controls.AddRange(new Control[] { txtName, txtCity, btnAdd, btnDelete, dgv });
        }

        private void RefreshGrid()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CINEMA", conn);
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
                cmd.Parameters.AddWithValue("@city", txtCity.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            RefreshGrid();
        }
    }
}