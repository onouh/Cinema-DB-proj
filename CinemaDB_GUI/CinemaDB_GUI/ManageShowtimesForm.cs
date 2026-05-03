using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class ManageShowtimesForm : Form
    {
        private string connString = "Server=YOUR_SERVER_NAME;Database=CinemaDB;Integrated Security=True;TrustServerCertificate=True;";
        private DataGridView dgv;
        private TextBox txtMovieId, txtCinemaId, txtHall, txtSlot;
        private DateTimePicker dtpDate;

        public ManageShowtimesForm()
        {
            InitializeUI();
            RefreshGrid();
        }

        private void InitializeUI()
        {
            this.Text = "Manage Showtimes";
            this.Size = new Size(800, 550);
            this.BackColor = Color.WhiteSmoke;

            this.Controls.Add(new Label { Text = "Showtimes Control", Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true });

            this.Controls.Add(new Label { Text = "Movie ID:", Location = new Point(20, 70), AutoSize = true });
            txtMovieId = new TextBox { Location = new Point(90, 70), Width = 60 };

            this.Controls.Add(new Label { Text = "Cinema ID:", Location = new Point(160, 70), AutoSize = true });
            txtCinemaId = new TextBox { Location = new Point(240, 70), Width = 60 };

            this.Controls.Add(new Label { Text = "Hall No:", Location = new Point(310, 70), AutoSize = true });
            txtHall = new TextBox { Location = new Point(370, 70), Width = 60 };

            this.Controls.Add(new Label { Text = "Date:", Location = new Point(20, 110), AutoSize = true });
            dtpDate = new DateTimePicker { Location = new Point(90, 110), Format = DateTimePickerFormat.Short, Width = 120 };

            this.Controls.Add(new Label { Text = "Slot:", Location = new Point(220, 110), AutoSize = true });
            txtSlot = new TextBox { Location = new Point(260, 110), Width = 100 };

            Button btnAdd = new Button { Text = "Add", Location = new Point(600, 68), BackColor = Color.MediumAquamarine, FlatStyle = FlatStyle.Flat };
            btnAdd.Click += (s, e) => ExecuteQuery("INSERT INTO SHOWTIME (movie_id, cinema_id, hall_no, date, slot) VALUES (@mov, @cin, @hall, @date, @slot)");

            Button btnDelete = new Button { Text = "Delete", Location = new Point(600, 105), BackColor = Color.LightCoral, FlatStyle = FlatStyle.Flat };
            btnDelete.Click += (s, e) => {
                if (dgv.SelectedRows.Count > 0) ExecuteQuery("DELETE FROM SHOWTIME WHERE showtime_id=@id", Convert.ToInt32(dgv.SelectedRows[0].Cells["showtime_id"].Value));
            };

            dgv = new DataGridView { Location = new Point(20, 160), Size = new Size(740, 330), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, SelectionMode = DataGridViewSelectionMode.FullRowSelect, ReadOnly = true };

            this.Controls.AddRange(new Control[] { txtMovieId, txtCinemaId, txtHall, dtpDate, txtSlot, btnAdd, btnDelete, dgv });
        }

        private void RefreshGrid()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SHOWTIME", conn);
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
                cmd.Parameters.AddWithValue("@mov", Convert.ToInt32(txtMovieId.Text));
                cmd.Parameters.AddWithValue("@cin", Convert.ToInt32(txtCinemaId.Text));
                cmd.Parameters.AddWithValue("@hall", Convert.ToInt32(txtHall.Text));
                cmd.Parameters.AddWithValue("@date", dtpDate.Value.Date);
                cmd.Parameters.AddWithValue("@slot", txtSlot.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            RefreshGrid();
        }
    }
}