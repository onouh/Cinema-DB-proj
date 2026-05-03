using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class ManageShowtimesForm : Form
    {
        private string connString = DatabaseConfig.ConnectionString;

        public ManageShowtimesForm()
        {
            InitializeComponent();

            // Wire up event handlers
            btnAdd.Click += (s, e) => ExecuteQuery("INSERT INTO SHOWTIME (movie_id, cinema_id, hall_no, date, slot) VALUES (@mov, @cin, @hall, @date, @slot)");

            btnDelete.Click += (s, e) =>
            {
                if (dgv.SelectedRows.Count > 0) ExecuteQuery("DELETE FROM SHOWTIME WHERE showtime_id=@id", Convert.ToInt32(dgv.SelectedRows[0].Cells["showtime_id"].Value));
            };

            RefreshGrid();
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