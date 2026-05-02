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
            labelTitle.Location = new Point(65, 32);
            labelTitle.Margin = new Padding(5, 0, 5, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(472, 72);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Manage Bookings";
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(65, 144);
            dgvData.Margin = new Padding(5);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersWidth = 51;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(1300, 400);
            dgvData.TabIndex = 1;
            dgvData.CellClick += dgvData_CellClick;
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(65, 576);
            lblId.Margin = new Padding(5, 0, 5, 0);
            lblId.Name = "lblId";
            lblId.Size = new Size(114, 32);
            lblId.TabIndex = 2;
            lblId.Text = "ID (Auto):";
            // 
            // txtId
            // 
            txtId.Location = new Point(189, 573);
            txtId.Margin = new Padding(5);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(128, 39);
            txtId.TabIndex = 3;
            // 
            // lblCustomerId
            // 
            lblCustomerId.AutoSize = true;
            lblCustomerId.Location = new Point(339, 579);
            lblCustomerId.Margin = new Padding(5, 0, 5, 0);
            lblCustomerId.Name = "lblCustomerId";
            lblCustomerId.Size = new Size(152, 32);
            lblCustomerId.TabIndex = 4;
            lblCustomerId.Text = "Customer ID:";
            // 
            // txtCustomerId
            // 
            txtCustomerId.Location = new Point(512, 573);
            txtCustomerId.Margin = new Padding(5);
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.Size = new Size(160, 39);
            txtCustomerId.TabIndex = 5;
            // 
            // lblBookingDate
            // 
            lblBookingDate.AutoSize = true;
            lblBookingDate.Location = new Point(708, 573);
            lblBookingDate.Margin = new Padding(5, 0, 5, 0);
            lblBookingDate.Name = "lblBookingDate";
            lblBookingDate.Size = new Size(240, 32);
            lblBookingDate.TabIndex = 6;
            lblBookingDate.Text = "Date (YYYY-MM-DD):";
            // 
            // txtBookingDate
            // 
            txtBookingDate.Location = new Point(972, 573);
            txtBookingDate.Margin = new Padding(5);
            txtBookingDate.Name = "txtBookingDate";
            txtBookingDate.Size = new Size(241, 39);
            txtBookingDate.TabIndex = 7;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(65, 632);
            lblStatus.Margin = new Padding(5, 0, 5, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(420, 32);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Status (pending/confirmed/cancelled):";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(512, 632);
            txtStatus.Margin = new Padding(5);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(241, 39);
            txtStatus.TabIndex = 9;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.MediumSeaGreen;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(315, 697);
            btnAdd.Margin = new Padding(5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(195, 72);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.BackColor = Color.Orange;
            btnUpdateStatus.FlatStyle = FlatStyle.Flat;
            btnUpdateStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdateStatus.ForeColor = Color.White;
            btnUpdateStatus.Location = new Point(554, 697);
            btnUpdateStatus.Margin = new Padding(5);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new Size(228, 72);
            btnUpdateStatus.TabIndex = 11;
            btnUpdateStatus.Text = "Update Status";
            btnUpdateStatus.UseVisualStyleBackColor = false;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(814, 697);
            btnDelete.Margin = new Padding(5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(195, 72);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.LightGray;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.Location = new Point(65, 697);
            btnBack.Margin = new Padding(5);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(162, 72);
            btnBack.TabIndex = 13;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // ManageBookingsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1430, 880);
            Controls.Add(labelTitle);
            Controls.Add(dgvData);
            Controls.Add(lblId);
            Controls.Add(txtId);
            Controls.Add(lblCustomerId);
            Controls.Add(txtCustomerId);
            Controls.Add(lblBookingDate);
            Controls.Add(txtBookingDate);
            Controls.Add(lblStatus);
            Controls.Add(txtStatus);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdateStatus);
            Controls.Add(btnDelete);
            Controls.Add(btnBack);
            Margin = new Padding(5);
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
