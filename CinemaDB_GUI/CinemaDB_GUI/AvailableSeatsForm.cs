using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class AvailableSeatsForm : Form
    {
        private string connString = "Server=YOUR_SERVER_NAME;Database=CinemaDB;Integrated Security=True;TrustServerCertificate=True;";
        
        private TextBox txtShowtimeId;
        private DataGridView dgvSeats;
        private Button btnCheckSeats;

        public AvailableSeatsForm()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Available Seats Check";
            this.Size = new Size(600, 500);
            this.BackColor = Color.WhiteSmoke;

            Label lblTitle = new Label { Text = "Check Available Seats", Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true };
            
            this.Controls.Add(new Label { Text = "Enter Showtime ID:", Location = new Point(20, 70), AutoSize = true });
            txtShowtimeId = new TextBox { Location = new Point(150, 68), Width = 100 };

            btnCheckSeats = new Button { Text = "Find Seats", Location = new Point(260, 65), BackColor = Color.LightSkyBlue, FlatStyle = FlatStyle.Flat };
            btnCheckSeats.Click += BtnCheckSeats_Click;

            dgvSeats = new DataGridView 
            { 
                Location = new Point(20, 110), 
                Size = new Size(540, 320),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            this.Controls.Add(lblTitle);
            this.Controls.Add(txtShowtimeId);
            this.Controls.Add(btnCheckSeats);
            this.Controls.Add(dgvSeats);
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
                    cmd.CommandType = CommandType.StoredProcedure; //[cite: 8]
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