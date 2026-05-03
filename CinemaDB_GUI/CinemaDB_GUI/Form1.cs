using System.Data;
using System.Data.SqlClient;

// Inside your specific Form class (e.g., MoviesForm)
private void LoadDataToGrid()
{
    // 1. Your connection string to the Cinema Ticket Booking database
    string connectionString = "Server=YOUR_SERVER_NAME;Database=Cinema Ticket Booking;Trusted_Connection=True;";
    
    // 2. The query or stored procedure name from Customer_All_GUI_Ready.sql
    string query = "SELECT * FROM vw_CustomerAvailableMovies"; 

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        try
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            
            // 3. Fill the table and bind it to your GUI Scene
            adapter.Fill(dataTable);
            moviesDataGridView.DataSource = dataTable; 
        }
        catch (Exception ex)
        {
            MessageBox.Show("Database Error: " + ex.Message);
        }
    }
}