using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class ManageBookingsForm : Form
    {
        private string connString = "Server=YOUR_SERVER_NAME;Database=CinemaDB;Integrated Security=True;TrustServerCertificate=True;";
        private DataGridView dgv;
        private TextBox txtStatus;

        public ManageBookingsForm()
        {
            InitializeUI();
            RefreshGrid();
        }

        private void InitializeUI()
        {
            this.Text = "Master Booking Control";
            this.Size = new Size(700, 500);
            this.BackColor = Color.WhiteSmoke;

            this.Controls.Add(new Label { Text = "All System Bookings", Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true });

            this.Controls.Add(new Label { Text = "Override Status:", Location = new Point(20, 70), AutoSize = true });
            txtStatus = new TextBox { Location = new Point(130, 70), Width = 150 };

            Button btnUpdate = new Button { Text = "Update Status", Location = new Point(300, 68), BackColor = Color.LightGoldenrodYellow, FlatStyle = FlatStyle.Flat, Width = 120 };
            btnUpdate.Click += (s, e) => {
                if (dgv.SelectedRows.Count > 0) ExecuteQuery("UPDATE BOOKING SET booking_status=@stat WHERE booking_id=@id", Convert.ToInt32(dgv.SelectedRows[0].Cells["booking_id"].Value));
            };

            Button btnDelete = new Button { Text = "Delete Record", Location = new Point(440, 68), BackColor = Color.LightCoral, FlatStyle = FlatStyle.Flat, Width = 120 };
            btnDelete.Click += (s, e) => {
                if (dgv.SelectedRows.Count > 0) ExecuteQuery("DELETE FROM BOOKING WHERE booking_id=@id", Convert.ToInt32(dgv.SelectedRows[0].Cells["booking_id"].Value));
            };

            dgv = new DataGridView { Location = new Point(20, 120), Size = new Size(640, 320), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, SelectionMode = DataGridViewSelectionMode.FullRowSelect, ReadOnly = true };
            dgv.SelectionChanged += (s, e) => {
                if (dgv.SelectedRows.Count > 0) txtStatus.Text = dgv.SelectedRows[0].Cells["booking_status"].Value.ToString();
            };

            this.Controls.AddRange(new Control[] { txtStatus, btnUpdate, btnDelete, dgv });
        }

        private void RefreshGrid()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM BOOKING ORDER BY booking_date DESC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }

        private void ExecuteQuery(string query, int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@stat", txtStatus.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            RefreshGrid();
        }
    }
}