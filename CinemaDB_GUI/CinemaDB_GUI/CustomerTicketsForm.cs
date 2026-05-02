using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class CustomerTicketsForm : Form
    {
        public CustomerTicketsForm()
        {
            InitializeComponent();
        }

        private void btnLoadTickets_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxCustomerId.Text, out int customerId))
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=CinemaDB;Integrated Security=SSPI;TrustServerCertificate=True"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ViewCustomerTickets", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@customer_id", customerId);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvTickets.DataSource = dt;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric Customer ID.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomerTicketsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
