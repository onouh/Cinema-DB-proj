using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class AvailableSeatsForm : Form
    {
        private string connString = DatabaseConfig.ConnectionString;

        public AvailableSeatsForm()
        {
            // 1. Call the Designer file's layout setup
            InitializeComponent();

            // 2. Wire up the button click event here
            btnCheckSeats.Click += BtnCheckSeats_Click;
        }

        private void BtnCheckSeats_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtShowtimeId.Text, out int showtimeId))
            {
                MessageBox.Show("Please enter a valid numeric Showtime ID.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAvailableSeats", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ShowtimeID", showtimeId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSeats.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No available seats found for this showtime, or the showtime does not exist.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading seats: " + ex.Message);
            }
        }
    }
}