namespace CinemaDB_GUI
{
    partial class ManageShowtimesForm
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
            
            lblMovieId = new Label();
            txtMovieId = new TextBox();
            
            lblHallNo = new Label();
            txtHallNo = new TextBox();
            
            lblCinemaId = new Label();
            txtCinemaId = new TextBox();
            
            lblSlot = new Label();
            txtSlot = new TextBox();
            
            lblDate = new Label();
            txtDate = new TextBox();
            
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
            labelTitle.Size = new Size(318, 46);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Manage Showtimes";
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
            
            lblMovieId.AutoSize = true;
            lblMovieId.Location = new Point(230, startY);
            lblMovieId.Text = "Movie ID:";
            txtMovieId.Location = new Point(310, startY);
            txtMovieId.Size = new Size(100, 27);
            
            lblHallNo.AutoSize = true;
            lblHallNo.Location = new Point(430, startY);
            lblHallNo.Text = "Hall No:";
            txtHallNo.Location = new Point(500, startY);
            txtHallNo.Size = new Size(100, 27);
            
            lblCinemaId.AutoSize = true;
            lblCinemaId.Location = new Point(620, startY);
            lblCinemaId.Text = "Cinema ID:";
            txtCinemaId.Location = new Point(700, startY);
            txtCinemaId.Size = new Size(100, 27);
            
            lblSlot.AutoSize = true;
            lblSlot.Location = new Point(40, startY + 50);
            lblSlot.Text = "Slot:";
            txtSlot.Location = new Point(130, startY + 50);
            txtSlot.Size = new Size(150, 27);
            
            lblDate.AutoSize = true;
            lblDate.Location = new Point(310, startY + 50);
            lblDate.Text = "Date (YYYY-MM-DD):";
            txtDate.Location = new Point(460, startY + 50);
            txtDate.Size = new Size(150, 27);
            
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
            Controls.Add(lblMovieId); Controls.Add(txtMovieId);
            Controls.Add(lblHallNo); Controls.Add(txtHallNo);
            Controls.Add(lblCinemaId); Controls.Add(txtCinemaId);
            Controls.Add(lblSlot); Controls.Add(txtSlot);
            Controls.Add(lblDate); Controls.Add(txtDate);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnBack);
            Name = "ManageShowtimesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Showtimes";
            Load += ManageShowtimesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private DataGridView dgvData;
        private Label lblId;
        private TextBox txtId;
        private Label lblMovieId;
        private TextBox txtMovieId;
        private Label lblHallNo;
        private TextBox txtHallNo;
        private Label lblCinemaId;
        private TextBox txtCinemaId;
        private Label lblSlot;
        private TextBox txtSlot;
        private Label lblDate;
        private TextBox txtDate;
        
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnBack;
    }
}
