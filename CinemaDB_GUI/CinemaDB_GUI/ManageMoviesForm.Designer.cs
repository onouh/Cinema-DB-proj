namespace CinemaDB_GUI
{
    partial class ManageMoviesForm
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
            
            lblTitle = new Label();
            txtTitle = new TextBox();
            
            lblDuration = new Label();
            txtDuration = new TextBox();
            
            lblLanguage = new Label();
            txtLanguage = new TextBox();
            
            lblDescription = new Label();
            txtDescription = new TextBox();
            
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
            labelTitle.Size = new Size(263, 46);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Manage Movies";
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
            
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(230, startY);
            lblTitle.Text = "Title:";
            txtTitle.Location = new Point(280, startY);
            txtTitle.Size = new Size(250, 27);
            
            lblDuration.AutoSize = true;
            lblDuration.Location = new Point(550, startY);
            lblDuration.Text = "Duration (m):";
            txtDuration.Location = new Point(650, startY);
            txtDuration.Size = new Size(100, 27);
            
            lblLanguage.AutoSize = true;
            lblLanguage.Location = new Point(40, startY + 50);
            lblLanguage.Text = "Language:";
            txtLanguage.Location = new Point(130, startY + 50);
            txtLanguage.Size = new Size(150, 27);
            
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(300, startY + 50);
            lblDescription.Text = "Desc:";
            txtDescription.Location = new Point(360, startY + 50);
            txtDescription.Size = new Size(450, 27);
            
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
            Controls.Add(lblTitle); Controls.Add(txtTitle);
            Controls.Add(lblDuration); Controls.Add(txtDuration);
            Controls.Add(lblLanguage); Controls.Add(txtLanguage);
            Controls.Add(lblDescription); Controls.Add(txtDescription);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnBack);
            Name = "ManageMoviesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Movies";
            Load += ManageMoviesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private DataGridView dgvData;
        private Label lblId;
        private TextBox txtId;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblDuration;
        private TextBox txtDuration;
        private Label lblLanguage;
        private TextBox txtLanguage;
        private Label lblDescription;
        private TextBox txtDescription;
        
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnBack;
    }
}
