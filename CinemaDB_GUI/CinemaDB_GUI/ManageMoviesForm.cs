using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class ManageMoviesForm : Form
    {
        private string connString = "Server=YOUR_SERVER_NAME;Database=CinemaDB;Integrated Security=True;TrustServerCertificate=True;";
        
        private DataGridView dgvAdminMovies;
        private TextBox txtTitle, txtDesc, txtDuration, txtLang;
        private Button btnAdd, btnUpdate, btnDelete;

        public ManageMoviesForm()
        {
            InitializeAdminUI();
            RefreshAdminGrid();
        }

        private void InitializeAdminUI()
        {
            this.Text = "Manage Movies (Admin)";
            this.Size = new Size(850, 600);
            this.BackColor = Color.WhiteSmoke;

            Label lblTitle = new Label { Text = "Movie Database CRUD", Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true };

            // Input Fields
            int startY = 70;
            this.Controls.Add(new Label { Text = "Title:", Location = new Point(20, startY), AutoSize = true });
            txtTitle = new TextBox { Location = new Point(100, startY), Width = 200 };
            
            this.Controls.Add(new Label { Text = "Desc:", Location = new Point(320, startY), AutoSize = true });
            txtDesc = new TextBox { Location = new Point(370, startY), Width = 200 };

            this.Controls.Add(new Label { Text = "Duration:", Location = new Point(20, startY + 40), AutoSize = true });
            txtDuration = new TextBox { Location = new Point(100, startY + 40), Width = 100 };

            this.Controls.Add(new Label { Text = "Language:", Location = new Point(300, startY + 40), AutoSize = true });
            txtLang = new TextBox { Location = new Point(370, startY + 40), Width = 100 };

            this.Controls.Add(txtTitle); this.Controls.Add(txtDesc); 
            this.Controls.Add(txtDuration); this.Controls.Add(txtLang);

            // Action Buttons
            btnAdd = new Button { Text = "Add Movie", Location = new Point(600, 65), BackColor = Color.MediumAquamarine, FlatStyle = FlatStyle.Flat };
            btnAdd.Click += BtnAdd_Click;

            btnUpdate = new Button { Text = "Update Selected", Location = new Point(600, 105), BackColor = Color.LightGoldenrodYellow, FlatStyle = FlatStyle.Flat };
            btnUpdate.Click += BtnUpdate_Click;

            btnDelete = new Button { Text = "Delete Selected", Location = new Point(710, 65), BackColor = Color.LightCoral, FlatStyle = FlatStyle.Flat };
            btnDelete.Click += BtnDelete_Click;

            this.Controls.Add(btnAdd); this.Controls.Add(btnUpdate); this.Controls.Add(btnDelete);

            // Data Grid
            dgvAdminMovies = new DataGridView 
            { 
                Location = new Point(20, 160), 
                Size = new Size(790, 380),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true
            };
            dgvAdminMovies.SelectionChanged += DgvAdminMovies_SelectionChanged;

            this.Controls.Add(lblTitle);
            this.Controls.Add(dgvAdminMovies);
        }

        private void RefreshAdminGrid()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MOVIE", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAdminMovies.DataSource = dt;
            }
        }

        private void DgvAdminMovies_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAdminMovies.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvAdminMovies.SelectedRows[0];
                txtTitle.Text = row.Cells["title"].Value.ToString();
                txtDesc.Text = row.Cells["description"].Value.ToString();
                txtDuration.Text = row.Cells["duration_min"].Value.ToString();
                txtLang.Text = row.Cells["language"].Value.ToString();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO MOVIE (title, description, duration_min, language) VALUES (@title, @desc, @dur, @lang)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@desc", txtDesc.Text);
                cmd.Parameters.AddWithValue("@dur", Convert.ToInt32(txtDuration.Text));
                cmd.Parameters.AddWithValue("@lang", txtLang.Text);
                
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            RefreshAdminGrid();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAdminMovies.SelectedRows.Count == 0) return;
            int movieId = Convert.ToInt32(dgvAdminMovies.SelectedRows[0].Cells["movie_id"].Value);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "UPDATE MOVIE SET title=@title, description=@desc, duration_min=@dur, language=@lang WHERE movie_id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", movieId);
                cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@desc", txtDesc.Text);
                cmd.Parameters.AddWithValue("@dur", Convert.ToInt32(txtDuration.Text));
                cmd.Parameters.AddWithValue("@lang", txtLang.Text);
                
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            RefreshAdminGrid();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAdminMovies.SelectedRows.Count == 0) return;
            int movieId = Convert.ToInt32(dgvAdminMovies.SelectedRows[0].Cells["movie_id"].Value);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "DELETE FROM MOVIE WHERE movie_id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", movieId);
                
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            RefreshAdminGrid();
        }
    }
}