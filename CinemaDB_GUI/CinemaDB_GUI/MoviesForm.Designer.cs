namespace CinemaDB_GUI
{
    partial class MoviesForm
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
            this.cbGenres = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvMovies = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovies)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(217, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Browse Movies";
            // 
            // cbGenres
            // 
            this.cbGenres.FormattingEnabled = true;
            this.cbGenres.Items.AddRange(new object[] {
            "Action",
            "Sci-Fi",
            "Drama",
            "Comedy",
            "Horror"});
            this.cbGenres.Location = new System.Drawing.Point(20, 70);
            this.cbGenres.Name = "cbGenres";
            this.cbGenres.Size = new System.Drawing.Size(150, 28);
            this.cbGenres.TabIndex = 1;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Location = new System.Drawing.Point(180, 68);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(84, 32);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "Filter Genre";
            this.btnFilter.UseVisualStyleBackColor = false;
            // Note: Event handler (this.btnFilter.Click += BtnFilter_Click;) remains in the main .cs file or is bound here if using VS.
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightGray;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(270, 68);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 32);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear Filter";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // dgvMovies
            // 
            this.dgvMovies.AllowUserToAddRows = false;
            this.dgvMovies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovies.Location = new System.Drawing.Point(20, 110);
            this.dgvMovies.Name = "dgvMovies";
            this.dgvMovies.ReadOnly = true;
            this.dgvMovies.RowHeadersWidth = 51;
            this.dgvMovies.Size = new System.Drawing.Size(740, 320);
            this.dgvMovies.TabIndex = 4;
            // 
            // MoviesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.dgvMovies);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.cbGenres);
            this.Controls.Add(this.lblTitle);
            this.Name = "MoviesForm";
            this.Text = "Available Movies";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        // Notice these are moved here from the main .cs file
        private System.Windows.Forms.ComboBox cbGenres;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvMovies;
    }
}