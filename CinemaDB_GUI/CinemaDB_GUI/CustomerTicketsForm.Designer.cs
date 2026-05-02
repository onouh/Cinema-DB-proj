namespace CinemaDB_GUI
{
    partial class CustomerTicketsForm
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
            labelCustomerId = new Label();
            textBoxCustomerId = new TextBox();
            btnLoadTickets = new Button();
            dgvTickets = new DataGridView();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTickets).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            labelTitle.Location = new Point(40, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(270, 46);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "My Tickets View";
            // 
            // labelCustomerId
            // 
            labelCustomerId.AutoSize = true;
            labelCustomerId.Font = new Font("Segoe UI", 11F);
            labelCustomerId.Location = new Point(40, 90);
            labelCustomerId.Name = "labelCustomerId";
            labelCustomerId.Size = new Size(117, 25);
            labelCustomerId.TabIndex = 1;
            labelCustomerId.Text = "Customer ID:";
            // 
            // textBoxCustomerId
            // 
            textBoxCustomerId.Location = new Point(170, 90);
            textBoxCustomerId.Name = "textBoxCustomerId";
            textBoxCustomerId.Size = new Size(150, 27);
            textBoxCustomerId.TabIndex = 2;
            // 
            // btnLoadTickets
            // 
            btnLoadTickets.BackColor = Color.MediumSeaGreen;
            btnLoadTickets.ForeColor = Color.White;
            btnLoadTickets.FlatStyle = FlatStyle.Flat;
            btnLoadTickets.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLoadTickets.Location = new Point(340, 80);
            btnLoadTickets.Name = "btnLoadTickets";
            btnLoadTickets.Size = new Size(120, 45);
            btnLoadTickets.TabIndex = 3;
            btnLoadTickets.Text = "Load Tickets";
            btnLoadTickets.UseVisualStyleBackColor = false;
            btnLoadTickets.Click += btnLoadTickets_Click;
            // 
            // dgvTickets
            // 
            dgvTickets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTickets.Location = new Point(40, 150);
            dgvTickets.Name = "dgvTickets";
            dgvTickets.RowHeadersWidth = 51;
            dgvTickets.Size = new Size(800, 350);
            dgvTickets.TabIndex = 4;
            dgvTickets.ReadOnly = true;
            dgvTickets.AllowUserToAddRows = false;
            dgvTickets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.LightGray;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.Location = new Point(40, 520);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 40);
            btnBack.TabIndex = 5;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // CustomerTicketsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(880, 580);
            Controls.Add(btnBack);
            Controls.Add(dgvTickets);
            Controls.Add(btnLoadTickets);
            Controls.Add(textBoxCustomerId);
            Controls.Add(labelCustomerId);
            Controls.Add(labelTitle);
            Name = "CustomerTicketsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customer Tickets";
            ((System.ComponentModel.ISupportInitialize)dgvTickets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelCustomerId;
        private TextBox textBoxCustomerId;
        private Button btnLoadTickets;
        private DataGridView dgvTickets;
        private Button btnBack;
    }
}
