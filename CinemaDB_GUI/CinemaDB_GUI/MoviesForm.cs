using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class MoviesForm : Form
    {
        // TODO: Replace with your actual SQL Server connection string
        private string connString = "Server=YOUR_SERVER_NAME;Database=CinemaDB;Integrated Security=True;TrustServerCertificate=True;";
        
        private DataGridView dgvMovies;
        private ComboBox cbGenres;
        private Button btnFilter;
        private Button btnClear;

        public MoviesForm()
        {
            InitializeUI();
            LoadMovies();
        }

        private void InitializeUI()
        {
            this.Text = "Available Movies";
            this.Size = new Size(800, 500);
            this.BackColor = Color.WhiteSmoke;

            Label lblTitle = new Label { Text = "Browse Movies", Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true };
            
            cbGenres = new ComboBox { Location = new Point(20, 70), Width = 150 };
            cbGenres.Items.AddRange(new object[] { "Action", "Sci-Fi", "Drama", "Comedy", "Horror" }); // Can also be populated via DB

            btnFilter = new Button { Text = "Filter Genre", Location = new Point(180, 68), BackColor = Color.LightSkyBlue, FlatStyle = FlatStyle.Flat };
            btnFilter.Click += BtnFilter_Click;

            btnClear = new Button { Text = "Clear Filter", Location = new Point(270, 68), BackColor = Color.LightGray, FlatStyle = FlatStyle.Flat };
            btnClear.Click += (s, e) => { cbGenres.SelectedIndex = -1; LoadMovies(); };

            dgvMovies = new DataGridView 
            { 
                Location = new Point(20, 110), 
                Size = new Size(740, 320),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            this.Controls.Add(lblTitle);
            this.Controls.Add(cbGenres);
            this.Controls.Add(btnFilter);
            this.Controls.Add(btnClear);
            this.Controls.Add(dgvMovies);
        }

        private void LoadMovies()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllMovies", conn);
                    cmd.CommandType = CommandType.StoredProcedure; //
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMovies.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading movies: " + ex.Message);
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            if (cbGenres.SelectedItem == null) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("sp_GetMoviesByGenre", conn);
                    cmd.CommandType = CommandType.StoredProcedure; //
                    cmd.Parameters.AddWithValue("@Genre", cbGenres.SelectedItem.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMovies.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering movies: " + ex.Message);
            }
        }
    }
}