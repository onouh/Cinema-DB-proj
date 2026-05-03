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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMovieTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.lblLang = new System.Windows.Forms.Label();
            this.txtLang = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvAdminMovies = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminMovies)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(294, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Movie Database CRUD";
            // 
            // lblMovieTitle
            // 
            this.lblMovieTitle.AutoSize = true;
            this.lblMovieTitle.Location = new System.Drawing.Point(20, 70);
            this.lblMovieTitle.Name = "lblMovieTitle";
            this.lblMovieTitle.Size = new System.Drawing.Size(41, 20);
            this.lblMovieTitle.TabIndex = 1;
            this.lblMovieTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(100, 70);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 27);
            this.txtTitle.TabIndex = 2;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(320, 70);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(43, 20);
            this.lblDesc.TabIndex = 3;
            this.lblDesc.Text = "Desc:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(370, 70);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(200, 27);
            this.txtDesc.TabIndex = 4;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(20, 110);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(70, 20);
            this.lblDuration.TabIndex = 5;
            this.lblDuration.Text = "Duration:";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(100, 110);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(100, 27);
            this.txtDuration.TabIndex = 6;
            // 
            // lblLang
            // 
            this.lblLang.AutoSize = true;
            this.lblLang.Location = new System.Drawing.Point(300, 110);
            this.lblLang.Name = "lblLang";
            this.lblLang.Size = new System.Drawing.Size(77, 20);
            this.lblLang.TabIndex = 7;
            this.lblLang.Text = "Language:";
            // 
            // txtLang
            // 
            this.txtLang.Location = new System.Drawing.Point(370, 110);
            this.txtLang.Name = "txtLang";
            this.txtLang.Size = new System.Drawing.Size(100, 27);
            this.txtLang.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(600, 65);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 29);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add Movie";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(600, 105);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(130, 29);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update Selected";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(710, 65);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 29);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // dgvAdminMovies
            // 
            this.dgvAdminMovies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAdminMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdminMovies.Location = new System.Drawing.Point(20, 160);
            this.dgvAdminMovies.MultiSelect = false;
            this.dgvAdminMovies.Name = "dgvAdminMovies";
            this.dgvAdminMovies.ReadOnly = true;
            this.dgvAdminMovies.RowHeadersWidth = 51;
            this.dgvAdminMovies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdminMovies.Size = new System.Drawing.Size(790, 380);
            this.dgvAdminMovies.TabIndex = 12;
            // 
            // ManageMoviesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(850, 600);
            this.Controls.Add(this.dgvAdminMovies);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtLang);
            this.Controls.Add(this.lblLang);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblMovieTitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "ManageMoviesForm";
            this.Text = "Manage Movies (Admin)";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminMovies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMovieTitle;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblLang;
        
        // Moved from main code-behind
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox txtLang;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvAdminMovies;
    }
}