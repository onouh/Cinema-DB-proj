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
            labelTitle.Location = new Point(65, 32);
            labelTitle.Margin = new Padding(5, 0, 5, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(424, 72);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "My Tickets View";
            // 
            // labelCustomerId
            // 
            labelCustomerId.AutoSize = true;
            labelCustomerId.Font = new Font("Segoe UI", 11F);
            labelCustomerId.Location = new Point(65, 144);
            labelCustomerId.Margin = new Padding(5, 0, 5, 0);
            labelCustomerId.Name = "labelCustomerId";
            labelCustomerId.Size = new Size(191, 41);
            labelCustomerId.TabIndex = 1;
            labelCustomerId.Text = "Customer ID:";
            // 
            // textBoxCustomerId
            // 
            textBoxCustomerId.Location = new Point(276, 144);
            textBoxCustomerId.Margin = new Padding(5, 5, 5, 5);
            textBoxCustomerId.Name = "textBoxCustomerId";
            textBoxCustomerId.Size = new Size(241, 39);
            textBoxCustomerId.TabIndex = 2;
            // 
            // btnLoadTickets
            // 
            btnLoadTickets.BackColor = Color.MediumSeaGreen;
            btnLoadTickets.FlatStyle = FlatStyle.Flat;
            btnLoadTickets.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLoadTickets.ForeColor = Color.White;
            btnLoadTickets.Location = new Point(552, 128);
            btnLoadTickets.Margin = new Padding(5, 5, 5, 5);
            btnLoadTickets.Name = "btnLoadTickets";
            btnLoadTickets.Size = new Size(195, 72);
            btnLoadTickets.TabIndex = 3;
            btnLoadTickets.Text = "Load Tickets";
            btnLoadTickets.UseVisualStyleBackColor = false;
            btnLoadTickets.Click += btnLoadTickets_Click;
            // 
            // dgvTickets
            // 
            dgvTickets.AllowUserToAddRows = false;
            dgvTickets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTickets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTickets.Location = new Point(65, 240);
            dgvTickets.Margin = new Padding(5, 5, 5, 5);
            dgvTickets.Name = "dgvTickets";
            dgvTickets.ReadOnly = true;
            dgvTickets.RowHeadersWidth = 51;
            dgvTickets.Size = new Size(1300, 560);
            dgvTickets.TabIndex = 4;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.LightGray;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.Location = new Point(65, 832);
            btnBack.Margin = new Padding(5, 5, 5, 5);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(162, 64);
            btnBack.TabIndex = 5;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // CustomerTicketsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1430, 928);
            Controls.Add(btnBack);
            Controls.Add(dgvTickets);
            Controls.Add(btnLoadTickets);
            Controls.Add(textBoxCustomerId);
            Controls.Add(labelCustomerId);
            Controls.Add(labelTitle);
            Margin = new Padding(5, 5, 5, 5);
            Name = "CustomerTicketsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customer Tickets";
            Load += CustomerTicketsForm_Load;
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
