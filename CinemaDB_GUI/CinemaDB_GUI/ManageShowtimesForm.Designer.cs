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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMovieId = new System.Windows.Forms.Label();
            this.txtMovieId = new System.Windows.Forms.TextBox();
            this.lblCinemaId = new System.Windows.Forms.Label();
            this.txtCinemaId = new System.Windows.Forms.TextBox();
            this.lblHall = new System.Windows.Forms.Label();
            this.txtHall = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblSlot = new System.Windows.Forms.Label();
            this.txtSlot = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Showtimes Control";
            // 
            // lblMovieId
            // 
            this.lblMovieId.AutoSize = true;
            this.lblMovieId.Location = new System.Drawing.Point(20, 70);
            this.lblMovieId.Name = "lblMovieId";
            this.lblMovieId.Size = new System.Drawing.Size(72, 20);
            this.lblMovieId.TabIndex = 1;
            this.lblMovieId.Text = "Movie ID:";
            // 
            // txtMovieId
            // 
            this.txtMovieId.Location = new System.Drawing.Point(90, 70);
            this.txtMovieId.Name = "txtMovieId";
            this.txtMovieId.Size = new System.Drawing.Size(60, 27);
            this.txtMovieId.TabIndex = 2;
            // 
            // lblCinemaId
            // 
            this.lblCinemaId.AutoSize = true;
            this.lblCinemaId.Location = new System.Drawing.Point(160, 70);
            this.lblCinemaId.Name = "lblCinemaId";
            this.lblCinemaId.Size = new System.Drawing.Size(79, 20);
            this.lblCinemaId.TabIndex = 3;
            this.lblCinemaId.Text = "Cinema ID:";
            // 
            // txtCinemaId
            // 
            this.txtCinemaId.Location = new System.Drawing.Point(240, 70);
            this.txtCinemaId.Name = "txtCinemaId";
            this.txtCinemaId.Size = new System.Drawing.Size(60, 27);
            this.txtCinemaId.TabIndex = 4;
            // 
            // lblHall
            // 
            this.lblHall.AutoSize = true;
            this.lblHall.Location = new System.Drawing.Point(310, 70);
            this.lblHall.Name = "lblHall";
            this.lblHall.Size = new System.Drawing.Size(63, 20);
            this.lblHall.TabIndex = 5;
            this.lblHall.Text = "Hall No:";
            // 
            // txtHall
            // 
            this.txtHall.Location = new System.Drawing.Point(370, 70);
            this.txtHall.Name = "txtHall";
            this.txtHall.Size = new System.Drawing.Size(60, 27);
            this.txtHall.TabIndex = 6;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 110);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(44, 20);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "Date:";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(90, 110);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(120, 27);
            this.dtpDate.TabIndex = 8;
            // 
            // lblSlot
            // 
            this.lblSlot.AutoSize = true;
            this.lblSlot.Location = new System.Drawing.Point(220, 110);
            this.lblSlot.Name = "lblSlot";
            this.lblSlot.Size = new System.Drawing.Size(38, 20);
            this.lblSlot.TabIndex = 9;
            this.lblSlot.Text = "Slot:";
            // 
            // txtSlot
            // 
            this.txtSlot.Location = new System.Drawing.Point(260, 110);
            this.txtSlot.Name = "txtSlot";
            this.txtSlot.Size = new System.Drawing.Size(100, 27);
            this.txtSlot.TabIndex = 10;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(600, 68);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 29);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(600, 105);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 29);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(20, 160);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(740, 330);
            this.dgv.TabIndex = 13;
            // 
            // ManageShowtimesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSlot);
            this.Controls.Add(this.lblSlot);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtHall);
            this.Controls.Add(this.lblHall);
            this.Controls.Add(this.txtCinemaId);
            this.Controls.Add(this.lblCinemaId);
            this.Controls.Add(this.txtMovieId);
            this.Controls.Add(this.lblMovieId);
            this.Controls.Add(this.lblTitle);
            this.Name = "ManageShowtimesForm";
            this.Text = "Manage Showtimes";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMovieId;
        private System.Windows.Forms.Label lblCinemaId;
        private System.Windows.Forms.Label lblHall;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblSlot;
        
        private System.Windows.Forms.TextBox txtMovieId;
        private System.Windows.Forms.TextBox txtCinemaId;
        private System.Windows.Forms.TextBox txtHall;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtSlot;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgv;
    }
}