using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace CinemaDB_GUI
{
    public partial class MoviesForm : Form
    {
        public MoviesForm()
        {
            InitializeComponent();
        }

        private void MoviesForm_Load(object sender, EventArgs e)
        {
     
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=CinemaDB;Integrated Security=SSPI");
            con.Open();

            SqlCommand cmd = new SqlCommand("sp_ViewAvailableMovies", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("title");
            dt.Columns.Add("cinema_name");
            dt.Columns.Add("city");
            dt.Columns.Add("slot");
            dt.Columns.Add("showtime_date");
            dt.Columns.Add("slot_price");

            DataRow row;
            while (reader.Read())
            {
                row = dt.NewRow();
                row["title"] = reader["title"];
                row["cinema_name"] = reader["cinema_name"];
                row["city"] = reader["city"];
                row["slot"] = reader["slot"];
                row["showtime_date"] = reader["showtime_date"];
                row["slot_price"] = reader["slot_price"];
                dt.Rows.Add(row);
            }

            reader.Close();
            con.Close();

            dgv_Movies.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {

        }

        private void dgv_Movies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
