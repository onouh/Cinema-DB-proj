using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class ManageBookingsForm : Form
    {
        private string connString = DatabaseConfig.ConnectionString;

        public ManageBookingsForm()
        {
            InitializeComponent();

            // Wire up event handlers
            btnUpdate.Click += (s, e) =>
            {
                if (dgv.SelectedRows.Count > 0) ExecuteQuery("UPDATE BOOKING SET booking_status=@stat WHERE booking_id=@id", Convert.ToInt32(dgv.SelectedRows[0].Cells["booking_id"].Value));
            };

            btnDelete.Click += (s, e) =>
            {
                if (dgv.SelectedRows.Count > 0) ExecuteQuery("DELETE FROM BOOKING WHERE booking_id=@id", Convert.ToInt32(dgv.SelectedRows[0].Cells["booking_id"].Value));
            };

            dgv.SelectionChanged += (s, e) =>
            {
                if (dgv.SelectedRows.Count > 0) txtStatus.Text = dgv.SelectedRows[0].Cells["booking_status"].Value.ToString();
            };

            RefreshGrid();
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