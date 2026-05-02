using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class AvailableSeatsForm : Form
    {
        public AvailableSeatsForm()
        {
            InitializeComponent();
        }

        private void btnLoadSeats_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxShowtimeId.Text, out int showtimeId))
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=CinemaDB;Integrated Security=SSPI;TrustServerCertificate=True"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ViewAvailableSeats", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@showtime_id", showtimeId);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvSeats.DataSource = dt;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric Showtime ID.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
