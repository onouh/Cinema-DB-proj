namespace CinemaDB_GUI
{
    partial class ManageCinemasForm
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
            
            lblName = new Label();
            txtName = new TextBox();
            
            lblAddress = new Label();
            txtAddress = new TextBox();
            
            lblCity = new Label();
            txtCity = new TextBox();
            
            lblPhone = new Label();
            txtPhone = new TextBox();
            
            btnAdd = new Button();
            btnUpdate = new Button();
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
            labelTitle.Size = new Size(281, 46);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Manage Cinemas";
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
            
            lblName.AutoSize = true;
            lblName.Location = new Point(230, startY);
            lblName.Text = "Name:";
            txtName.Location = new Point(290, startY);
            txtName.Size = new Size(200, 27);
            
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(510, startY);
            lblPhone.Text = "Phone:";
            txtPhone.Location = new Point(580, startY);
            txtPhone.Size = new Size(150, 27);
            
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(40, startY + 50);
            lblAddress.Text = "Address:";
            txtAddress.Location = new Point(130, startY + 50);
            txtAddress.Size = new Size(360, 27);
            
            lblCity.AutoSize = true;
            lblCity.Location = new Point(510, startY + 50);
            lblCity.Text = "City:";
            txtCity.Location = new Point(580, startY + 50);
            txtCity.Size = new Size(150, 27);
            
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
            
            btnUpdate.BackColor = Color.Orange;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdate.Location = new Point(340, startY + 110);
            btnUpdate.Size = new Size(120, 45);
            btnUpdate.Text = "Update";
            btnUpdate.Click += btnUpdate_Click;
            
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.Location = new Point(480, startY + 110);
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
            Controls.Add(lblName); Controls.Add(txtName);
            Controls.Add(lblAddress); Controls.Add(txtAddress);
            Controls.Add(lblCity); Controls.Add(txtCity);
            Controls.Add(lblPhone); Controls.Add(txtPhone);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnBack);
            Name = "ManageCinemasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Cinemas";
            Load += ManageCinemasForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private DataGridView dgvData;
        private Label lblId;
        private TextBox txtId;
        private Label lblName;
        private TextBox txtName;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblCity;
        private TextBox txtCity;
        private Label lblPhone;
        private TextBox txtPhone;
        
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnBack;
    }
}
