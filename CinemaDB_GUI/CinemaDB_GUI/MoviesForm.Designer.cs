namespace CinemaDB_GUI
{
    partial class MoviesForm
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
            this.cbGenres = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnShowtimes = new System.Windows.Forms.Button();
            this.cbSlotType = new System.Windows.Forms.ComboBox();
            this.dgvMovies = new System.Windows.Forms.DataGridView();
            this.lblShowtimes = new System.Windows.Forms.Label();
            this.dgvShowtimes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowtimes)).BeginInit();
            this.SuspendLayout();
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Browse Movies";
            // cbGenres
            this.cbGenres.FormattingEnabled = true;
            this.cbGenres.Items.AddRange(new object[] { "Action", "Sci-Fi", "Drama", "Comedy", "Horror", "Animation", "Romance" });
            this.cbGenres.Location = new System.Drawing.Point(20, 70);
            this.cbGenres.Name = "cbGenres";
            this.cbGenres.Size = new System.Drawing.Size(130, 28);
            this.cbGenres.TabIndex = 1;
            // btnFilter
            this.btnFilter.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFilter.Location = new System.Drawing.Point(155, 68);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(84, 32);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            // btnClear
            this.btnClear.BackColor = System.Drawing.Color.LightGray;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.Location = new System.Drawing.Point(245, 68);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 32);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // btnShowtimes
            this.btnShowtimes.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnShowtimes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowtimes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowtimes.Location = new System.Drawing.Point(340, 68);
            this.btnShowtimes.Name = "btnShowtimes";
            this.btnShowtimes.Size = new System.Drawing.Size(130, 32);
            this.btnShowtimes.TabIndex = 4;
            this.btnShowtimes.Text = "View Showtimes";
            this.btnShowtimes.UseVisualStyleBackColor = false;
            // cbSlotType
            this.cbSlotType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSlotType.FormattingEnabled = true;
            this.cbSlotType.Items.AddRange(new object[] { "Today", "Weekend", "All" });
            this.cbSlotType.Location = new System.Drawing.Point(500, 70);
            this.cbSlotType.Name = "cbSlotType";
            this.cbSlotType.Size = new System.Drawing.Size(110, 28);
            this.cbSlotType.TabIndex = 5;
            // dgvMovies
            this.dgvMovies.AllowUserToAddRows = false;
            this.dgvMovies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovies.Location = new System.Drawing.Point(20, 110);
            this.dgvMovies.Name = "dgvMovies";
            this.dgvMovies.ReadOnly = true;
            this.dgvMovies.RowHeadersWidth = 51;
            this.dgvMovies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovies.Size = new System.Drawing.Size(740, 200);
            this.dgvMovies.TabIndex = 6;
            // lblShowtimes
            this.lblShowtimes.AutoSize = true;
            this.lblShowtimes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblShowtimes.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblShowtimes.Location = new System.Drawing.Point(20, 320);
            this.lblShowtimes.Name = "lblShowtimes";
            this.lblShowtimes.Text = "Showtimes (select a movie above)";
            // dgvShowtimes
            this.dgvShowtimes.AllowUserToAddRows = false;
            this.dgvShowtimes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShowtimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowtimes.Location = new System.Drawing.Point(20, 350);
            this.dgvShowtimes.Name = "dgvShowtimes";
            this.dgvShowtimes.ReadOnly = true;
            this.dgvShowtimes.RowHeadersWidth = 51;
            this.dgvShowtimes.Size = new System.Drawing.Size(740, 200);
            this.dgvShowtimes.TabIndex = 7;
            // MoviesForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.dgvShowtimes);
            this.Controls.Add(this.lblShowtimes);
            this.Controls.Add(this.dgvMovies);
            this.Controls.Add(this.cbSlotType);
            this.Controls.Add(this.btnShowtimes);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.cbGenres);
            this.Controls.Add(this.lblTitle);
            this.Name = "MoviesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Available Movies";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowtimes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cbGenres;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnShowtimes;
        private System.Windows.Forms.ComboBox cbSlotType;
        private System.Windows.Forms.DataGridView dgvMovies;
        private System.Windows.Forms.Label lblShowtimes;
        private System.Windows.Forms.DataGridView dgvShowtimes;
    }
}