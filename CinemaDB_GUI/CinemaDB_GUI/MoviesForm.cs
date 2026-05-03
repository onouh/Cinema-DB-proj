using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class MoviesForm : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=CinemaDB;Integrated Security=SSPI;TrustServerCertificate=True";

        public MoviesForm()
        {
            InitializeComponent();
        }

        private void MoviesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("sp_ViewAvailableMovies", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv_Movies.DataSource = dt;
                }
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_Movies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
