using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    public partial class MakeBookingForm : Form
    {
        private string connString = DatabaseConfig.ConnectionString;

        public MakeBookingForm()
        {
            InitializeComponent();
            btnPreview.Click += BtnPreview_Click;
            btnBook.Click += BtnBook_Click;
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtShowtimeId.Text, out int sid) ||
                !int.TryParse(txtSeatNo.Text, out int sno))
            {
                MessageBox.Show("Enter valid Showtime ID and Seat No.");
                return;
            }
            try
            {
                using var conn = new SqlConnection(connString);
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT dbo.fn_CalcTicketPrice(@S,@N) AS Price", conn);
                cmd.Parameters.AddWithValue("@S", sid);
                cmd.Parameters.AddWithValue("@N", sno);
                object r = cmd.ExecuteScalar();
                decimal p = r != null && r != DBNull.Value ? Convert.ToDecimal(r) : 0;
                lblPriceValue.Text = p.ToString("C");
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void BtnBook_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int cid) ||
                !int.TryParse(txtShowtimeId.Text, out int sid) ||
                !int.TryParse(txtSeatNo.Text, out int sno))
            {
                MessageBox.Show("Fill in all ID fields with valid numbers.");
                return;
            }
            if (cbPaymentMethod.SelectedItem == null)
            {
                MessageBox.Show("Select a payment method.");
                return;
            }
            try
            {
                using var conn = new SqlConnection(connString);
                var cmd = new SqlCommand("sp_MakeBooking", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", cid);
                cmd.Parameters.AddWithValue("@ShowtimeID", sid);
                cmd.Parameters.AddWithValue("@SeatNo", sno);
                cmd.Parameters.AddWithValue("@PaymentMethod",
                    cbPaymentMethod.SelectedItem.ToString());
                var pId = new SqlParameter("@NewBookingID", SqlDbType.Int)
                    { Direction = ParameterDirection.Output };
                var pErr = new SqlParameter("@ErrorMessage", SqlDbType.VarChar, 255)
                    { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(pId);
                cmd.Parameters.Add(pErr);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                int bid = pId.Value != DBNull.Value ? Convert.ToInt32(pId.Value) : -1;
                string err = pErr.Value?.ToString() ?? "";
                if (bid > 0 && string.IsNullOrEmpty(err))
                {
                    MessageBox.Show($"Booking created! ID: {bid}");
                    dgvResult.DataSource = dt;
                }
                else
                    MessageBox.Show("Failed: " + err);
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
    }
}
