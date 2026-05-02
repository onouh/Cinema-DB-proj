namespace CinemaDB_GUI
{
    partial class ManageBookingsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            labelTitle = new Label();
            dgvData = new DataGridView();
            
            lblId = new Label();
            txtId = new TextBox();
            
            lblCustomerId = new Label();
            txtCustomerId = new TextBox();
            
            lblBookingDate = new Label();
            txtBookingDate = new TextBox();
            
            lblStatus = new Label();
            txtStatus = new TextBox();
            
            btnAdd = new Button();
            btnUpdateStatus = new Button();
            btnDelete = new Button();
            btnBack = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            labelTitle.Location = new Point(40, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(295, 46);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Manage Bookings";
            // 
            // dgvData
            // 
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(40, 90);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 51;
            dgvData.Size = new Size(800, 250);
            dgvData.TabIndex = 1;
            dgvData.ReadOnly = true;
            dgvData.AllowUserToAddRows = false;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.CellClick += dgvData_CellClick;
            // 
            // Inputs
            //
            int startY = 360;
            
            lblId.AutoSize = true;
            lblId.Location = new Point(40, startY);
            lblId.Text = "ID (Auto):";
            txtId.Location = new Point(130, startY);
            txtId.ReadOnly = true;
            txtId.Size = new Size(80, 27);
            
            lblCustomerId.AutoSize = true;
            lblCustomerId.Location = new Point(230, startY);
            lblCustomerId.Text = "Customer ID:";
            txtCustomerId.Location = new Point(330, startY);
            txtCustomerId.Size = new Size(100, 27);
            
            lblBookingDate.AutoSize = true;
            lblBookingDate.Location = new Point(450, startY);
            lblBookingDate.Text = "Date (YYYY-MM-DD):";
            txtBookingDate.Location = new Point(600, startY);
            txtBookingDate.Size = new Size(150, 27);
            
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(40, startY + 50);
            lblStatus.Text = "Status (pending/confirmed/cancelled):";
            txtStatus.Location = new Point(310, startY + 50);
            txtStatus.Size = new Size(150, 27);
            
            // 
            // Buttons
            // 
            btnAdd.BackColor = Color.MediumSeaGreen;
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.Location = new Point(200, startY + 110);
            btnAdd.Size = new Size(120, 45);
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;
            
            btnUpdateStatus.BackColor = Color.Orange;
            btnUpdateStatus.ForeColor = Color.White;
            btnUpdateStatus.FlatStyle = FlatStyle.Flat;
            btnUpdateStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdateStatus.Location = new Point(340, startY + 110);
            btnUpdateStatus.Size = new Size(140, 45);
            btnUpdateStatus.Text = "Update Status";
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.Location = new Point(500, startY + 110);
            btnDelete.Size = new Size(120, 45);
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            
            btnBack.BackColor = Color.LightGray;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.Location = new Point(40, startY + 110);
            btnBack.Size = new Size(100, 45);
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(880, 550);
            Controls.Add(labelTitle);
            Controls.Add(dgvData);
            Controls.Add(lblId); Controls.Add(txtId);
            Controls.Add(lblCustomerId); Controls.Add(txtCustomerId);
            Controls.Add(lblBookingDate); Controls.Add(txtBookingDate);
            Controls.Add(lblStatus); Controls.Add(txtStatus);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdateStatus);
            Controls.Add(btnDelete);
            Controls.Add(btnBack);
            Name = "ManageBookingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Bookings";
            Load += ManageBookingsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private DataGridView dgvData;
        private Label lblId;
        private TextBox txtId;
        private Label lblCustomerId;
        private TextBox txtCustomerId;
        private Label lblBookingDate;
        private TextBox txtBookingDate;
        private Label lblStatus;
        private TextBox txtStatus;
        
        private Button btnAdd;
        private Button btnUpdateStatus;
        private Button btnDelete;
        private Button btnBack;
    }
}
