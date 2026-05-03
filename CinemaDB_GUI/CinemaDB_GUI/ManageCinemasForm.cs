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

            // Wire up event handlers
            btnAdd.Click += (s, e) => ExecuteQuery("INSERT INTO CINEMA (name, city) VALUES (@name, @city)");

            btnDelete.Click += (s, e) =>
            {
                if (dgv.SelectedRows.Count > 0) ExecuteQuery("DELETE FROM CINEMA WHERE cinema_id=@id", Convert.ToInt32(dgv.SelectedRows[0].Cells["cinema_id"].Value));
            };

            dgv.SelectionChanged += (s, e) =>
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    txtName.Text = dgv.SelectedRows[0].Cells["name"].Value.ToString();
                    txtCity.Text = dgv.SelectedRows[0].Cells["city"].Value.ToString();
                }
            };

            RefreshGrid();
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