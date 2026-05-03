using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class MoviesForm : Form
{
    // Replace with your actual connection string
    string connectionString = "Server=YOUR_SERVER;Database=Cinema Ticket Booking;Trusted_Connection=True;";

    public MoviesForm()
    {
        InitializeComponent();
    }

    private void MoviesForm_Load(object sender, EventArgs e)
    {
        LoadMovies("All"); // Load everything initially
    }

    private void LoadMovies(string genre)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            // Adjust this query based on your Customer_All_GUI_Ready.sql views
            string query = genre == "All" 
                ? "SELECT MovieID, Title, Genre, Duration, Rating FROM Movies WHERE IsCurrentlyShowing = 1"
                : "SELECT MovieID, Title, Genre, Duration, Rating FROM Movies WHERE IsCurrentlyShowing = 1 AND Genre = @Genre";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (genre != "All") cmd.Parameters.AddWithValue("@Genre", genre);
                
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvMovies.DataSource = dt; // Bind to DataGridView
            }
        }
    }

    private void cmbGenreFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadMovies(cmbGenreFilter.SelectedItem.ToString());
    }

    private void btnViewShowtimes_Click(object sender, EventArgs e)
    {
        if (dgvMovies.SelectedRows.Count > 0)
        {
            int selectedMovieId = Convert.ToInt32(dgvMovies.SelectedRows[0].Cells["MovieID"].Value);
            // Navigate to showtimes/seats form, passing the MovieID
            AvailableSeatsForm seatsForm = new AvailableSeatsForm(selectedMovieId);
            seatsForm.Show();
        }
    }
}