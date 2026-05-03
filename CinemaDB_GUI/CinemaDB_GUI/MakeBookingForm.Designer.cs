namespace CinemaDB_GUI
{
    partial class MakeBookingForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCustId = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.lblShowId = new System.Windows.Forms.Label();
            this.txtShowtimeId = new System.Windows.Forms.TextBox();
            this.lblSeat = new System.Windows.Forms.Label();
            this.txtSeatNo = new System.Windows.Forms.TextBox();
            this.lblPay = new System.Windows.Forms.Label();
            this.cbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblPriceValue = new System.Windows.Forms.Label();
            this.btnBook = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Book a Ticket";
            // lblCustId
            this.lblCustId.AutoSize = true;
            this.lblCustId.Location = new System.Drawing.Point(20, 75);
            this.lblCustId.Name = "lblCustId";
            this.lblCustId.Text = "Customer ID:";
            // txtCustomerId
            this.txtCustomerId.Location = new System.Drawing.Point(120, 72);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(80, 27);
            this.txtCustomerId.TabIndex = 1;
            // lblShowId
            this.lblShowId.AutoSize = true;
            this.lblShowId.Location = new System.Drawing.Point(220, 75);
            this.lblShowId.Name = "lblShowId";
            this.lblShowId.Text = "Showtime ID:";
            // txtShowtimeId
            this.txtShowtimeId.Location = new System.Drawing.Point(320, 72);
            this.txtShowtimeId.Name = "txtShowtimeId";
            this.txtShowtimeId.Size = new System.Drawing.Size(80, 27);
            this.txtShowtimeId.TabIndex = 2;
            // lblSeat
            this.lblSeat.AutoSize = true;
            this.lblSeat.Location = new System.Drawing.Point(420, 75);
            this.lblSeat.Name = "lblSeat";
            this.lblSeat.Text = "Seat No:";
            // txtSeatNo
            this.txtSeatNo.Location = new System.Drawing.Point(490, 72);
            this.txtSeatNo.Name = "txtSeatNo";
            this.txtSeatNo.Size = new System.Drawing.Size(80, 27);
            this.txtSeatNo.TabIndex = 3;
            // lblPay
            this.lblPay.AutoSize = true;
            this.lblPay.Location = new System.Drawing.Point(20, 115);
            this.lblPay.Name = "lblPay";
            this.lblPay.Text = "Payment:";
            // cbPaymentMethod
            this.cbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaymentMethod.FormattingEnabled = true;
            this.cbPaymentMethod.Items.AddRange(new object[] { "Credit Card", "Debit Card", "Cash" });
            this.cbPaymentMethod.Location = new System.Drawing.Point(120, 112);
            this.cbPaymentMethod.Name = "cbPaymentMethod";
            this.cbPaymentMethod.Size = new System.Drawing.Size(140, 28);
            this.cbPaymentMethod.TabIndex = 4;
            // btnPreview
            this.btnPreview.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPreview.Location = new System.Drawing.Point(280, 110);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(120, 32);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "Preview Price";
            this.btnPreview.UseVisualStyleBackColor = false;
            // lblPrice
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrice.Location = new System.Drawing.Point(420, 115);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Text = "Price:";
            // lblPriceValue
            this.lblPriceValue.AutoSize = true;
            this.lblPriceValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPriceValue.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblPriceValue.Location = new System.Drawing.Point(470, 115);
            this.lblPriceValue.Name = "lblPriceValue";
            this.lblPriceValue.Text = "—";
            // btnBook
            this.btnBook.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBook.Location = new System.Drawing.Point(600, 70);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(140, 72);
            this.btnBook.TabIndex = 6;
            this.btnBook.Text = "Book Now";
            this.btnBook.UseVisualStyleBackColor = false;
            // dgvResult
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(20, 160);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersWidth = 51;
            this.dgvResult.Size = new System.Drawing.Size(740, 280);
            this.dgvResult.TabIndex = 7;
            // MakeBookingForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.lblPriceValue);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.cbPaymentMethod);
            this.Controls.Add(this.lblPay);
            this.Controls.Add(this.txtSeatNo);
            this.Controls.Add(this.lblSeat);
            this.Controls.Add(this.txtShowtimeId);
            this.Controls.Add(this.lblShowId);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.lblCustId);
            this.Controls.Add(this.lblTitle);
            this.Name = "MakeBookingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book a Ticket";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCustId;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label lblShowId;
        private System.Windows.Forms.TextBox txtShowtimeId;
        private System.Windows.Forms.Label lblSeat;
        private System.Windows.Forms.TextBox txtSeatNo;
        private System.Windows.Forms.Label lblPay;
        private System.Windows.Forms.ComboBox cbPaymentMethod;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblPriceValue;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.DataGridView dgvResult;
    }
}
