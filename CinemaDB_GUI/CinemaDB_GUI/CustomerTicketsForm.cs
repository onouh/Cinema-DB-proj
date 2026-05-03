using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class CustomerTicketsForm : Form
    {
        private string connString = "Server=YOUR_SERVER_NAME;Database=CinemaDB;Integrated Security=True;TrustServerCertificate=True;";
        
        private TextBox txtCustomerId;
        private DataGridView dgvTickets;
        private Button btnLoadTickets;

        public CustomerTicketsForm()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "My Tickets";
            this.Size = new Size(800, 500);
            this.BackColor = Color.WhiteSmoke;

            Label lblTitle = new Label { Text = "View My Tickets", Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true };
            
            this.Controls.Add(new Label { Text = "Enter Customer ID:", Location = new Point(20, 70), AutoSize = true });
            txtCustomerId = new TextBox { Location = new Point(150, 68), Width = 100 };

            btnLoadTickets = new Button { Text = "Load Tickets", Location = new Point(260, 65), BackColor = Color.LightSkyBlue, FlatStyle = FlatStyle.Flat };
            btnLoadTickets.Click += BtnLoadTickets_Click;

            dgvTickets = new DataGridView 
            { 
                Location = new Point(20, 110), 
                Size = new Size(740, 320),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            this.Controls.Add(lblTitle);
            this.Controls.Add(txtCustomerId);
            this.Controls.Add(btnLoadTickets);
            this.Controls.Add(dgvTickets);
        }

        private void BtnLoadTickets_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int customerId))
            {
                MessageBox.Show("Please enter a valid numeric Customer ID.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("sp_GetMyTickets", conn);
                    cmd.CommandType = CommandType.StoredProcedure; //
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvTickets.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tickets: " + ex.Message);
            }
        }
    }
}