namespace Login
{
    partial class ProfilePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfilePage));
            this.nameLabel = new System.Windows.Forms.Label();
            this.dobLabel = new System.Windows.Forms.Label();
            this.genderLabel = new System.Windows.Forms.Label();
            this.phLabel = new System.Windows.Forms.Label();
            this.mailLabel = new System.Windows.Forms.Label();
            this.interviewDataGrid = new System.Windows.Forms.DataGridView();
            this.viewResultsBtnColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.resultsHeader = new System.Windows.Forms.Label();
            this.btnViewFamilyObservations = new System.Windows.Forms.Button();
            this.editUserDataBtn = new System.Windows.Forms.Button();
            this.deleteUserBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.interviewDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.nameLabel.Location = new System.Drawing.Point(11, 27);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(119, 29);
            this.nameLabel.TabIndex = 26;
            this.nameLabel.Text = "FILL NAME";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dobLabel
            // 
            this.dobLabel.AutoSize = true;
            this.dobLabel.BackColor = System.Drawing.Color.Transparent;
            this.dobLabel.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dobLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.dobLabel.Location = new System.Drawing.Point(12, 56);
            this.dobLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dobLabel.Name = "dobLabel";
            this.dobLabel.Size = new System.Drawing.Size(80, 23);
            this.dobLabel.TabIndex = 27;
            this.dobLabel.Text = "FILL DOB";
            this.dobLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // genderLabel
            // 
            this.genderLabel.AutoSize = true;
            this.genderLabel.BackColor = System.Drawing.Color.Transparent;
            this.genderLabel.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genderLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.genderLabel.Location = new System.Drawing.Point(12, 79);
            this.genderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(109, 23);
            this.genderLabel.TabIndex = 28;
            this.genderLabel.Text = "FILL GENDER";
            this.genderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // phLabel
            // 
            this.phLabel.AutoSize = true;
            this.phLabel.BackColor = System.Drawing.Color.Transparent;
            this.phLabel.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.phLabel.Location = new System.Drawing.Point(12, 102);
            this.phLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.phLabel.Name = "phLabel";
            this.phLabel.Size = new System.Drawing.Size(100, 23);
            this.phLabel.TabIndex = 29;
            this.phLabel.Text = "FILL PHONE";
            this.phLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mailLabel
            // 
            this.mailLabel.AutoSize = true;
            this.mailLabel.BackColor = System.Drawing.Color.Transparent;
            this.mailLabel.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mailLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.mailLabel.Location = new System.Drawing.Point(12, 125);
            this.mailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mailLabel.Name = "mailLabel";
            this.mailLabel.Size = new System.Drawing.Size(95, 23);
            this.mailLabel.TabIndex = 30;
            this.mailLabel.Text = "FILL EMAIL";
            this.mailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // interviewDataGrid
            // 
            this.interviewDataGrid.AllowUserToDeleteRows = false;
            this.interviewDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.interviewDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.viewResultsBtnColumn});
            this.interviewDataGrid.Location = new System.Drawing.Point(188, 194);
            this.interviewDataGrid.Name = "interviewDataGrid";
            this.interviewDataGrid.ReadOnly = true;
            this.interviewDataGrid.Size = new System.Drawing.Size(581, 231);
            this.interviewDataGrid.TabIndex = 31;
            // 
            // viewResultsBtnColumn
            // 
            this.viewResultsBtnColumn.HeaderText = "View";
            this.viewResultsBtnColumn.Name = "viewResultsBtnColumn";
            this.viewResultsBtnColumn.ReadOnly = true;
            this.viewResultsBtnColumn.Text = "Edit";
            this.viewResultsBtnColumn.UseColumnTextForButtonValue = true;
            // 
            // resultsHeader
            // 
            this.resultsHeader.AutoSize = true;
            this.resultsHeader.BackColor = System.Drawing.Color.Transparent;
            this.resultsHeader.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultsHeader.ForeColor = System.Drawing.Color.DarkBlue;
            this.resultsHeader.Location = new System.Drawing.Point(183, 162);
            this.resultsHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.resultsHeader.Name = "resultsHeader";
            this.resultsHeader.Size = new System.Drawing.Size(182, 29);
            this.resultsHeader.TabIndex = 32;
            this.resultsHeader.Text = "Interview History";
            this.resultsHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnViewFamilyObservations
            // 
            this.btnViewFamilyObservations.BackColor = System.Drawing.Color.White;
            this.btnViewFamilyObservations.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnViewFamilyObservations.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnViewFamilyObservations.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnViewFamilyObservations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewFamilyObservations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewFamilyObservations.ForeColor = System.Drawing.Color.Navy;
            this.btnViewFamilyObservations.Image = ((System.Drawing.Image)(resources.GetObject("btnViewFamilyObservations.Image")));
            this.btnViewFamilyObservations.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewFamilyObservations.Location = new System.Drawing.Point(11, 286);
            this.btnViewFamilyObservations.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewFamilyObservations.Name = "btnViewFamilyObservations";
            this.btnViewFamilyObservations.Size = new System.Drawing.Size(164, 60);
            this.btnViewFamilyObservations.TabIndex = 33;
            this.btnViewFamilyObservations.Text = "View Family Observations";
            this.btnViewFamilyObservations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewFamilyObservations.UseVisualStyleBackColor = false;
            // 
            // editUserDataBtn
            // 
            this.editUserDataBtn.BackColor = System.Drawing.Color.White;
            this.editUserDataBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.editUserDataBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.editUserDataBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.editUserDataBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editUserDataBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editUserDataBtn.ForeColor = System.Drawing.Color.Navy;
            this.editUserDataBtn.Image = ((System.Drawing.Image)(resources.GetObject("editUserDataBtn.Image")));
            this.editUserDataBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editUserDataBtn.Location = new System.Drawing.Point(11, 208);
            this.editUserDataBtn.Margin = new System.Windows.Forms.Padding(2);
            this.editUserDataBtn.Name = "editUserDataBtn";
            this.editUserDataBtn.Size = new System.Drawing.Size(164, 60);
            this.editUserDataBtn.TabIndex = 34;
            this.editUserDataBtn.Text = "Edit     Information";
            this.editUserDataBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editUserDataBtn.UseVisualStyleBackColor = false;
            this.editUserDataBtn.Click += new System.EventHandler(this.editUserDataBtn_Click);
            // 
            // deleteUserBtn
            // 
            this.deleteUserBtn.BackColor = System.Drawing.Color.White;
            this.deleteUserBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.deleteUserBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.deleteUserBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.deleteUserBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteUserBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteUserBtn.ForeColor = System.Drawing.Color.Navy;
            this.deleteUserBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteUserBtn.Image")));
            this.deleteUserBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteUserBtn.Location = new System.Drawing.Point(11, 365);
            this.deleteUserBtn.Margin = new System.Windows.Forms.Padding(2);
            this.deleteUserBtn.Name = "deleteUserBtn";
            this.deleteUserBtn.Size = new System.Drawing.Size(164, 60);
            this.deleteUserBtn.TabIndex = 35;
            this.deleteUserBtn.Text = "Delete Profile";
            this.deleteUserBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteUserBtn.UseVisualStyleBackColor = false;
            this.deleteUserBtn.Click += new System.EventHandler(this.deleteUserBtn_Click);
            // 
            // ProfilePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deleteUserBtn);
            this.Controls.Add(this.editUserDataBtn);
            this.Controls.Add(this.btnViewFamilyObservations);
            this.Controls.Add(this.resultsHeader);
            this.Controls.Add(this.interviewDataGrid);
            this.Controls.Add(this.mailLabel);
            this.Controls.Add(this.phLabel);
            this.Controls.Add(this.genderLabel);
            this.Controls.Add(this.dobLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "ProfilePage";
            this.Text = "ProfilePage";
            this.Enter += new System.EventHandler(this.ProfilePage_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.interviewDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label dobLabel;
        private System.Windows.Forms.Label genderLabel;
        private System.Windows.Forms.Label phLabel;
        private System.Windows.Forms.Label mailLabel;
        private System.Windows.Forms.DataGridView interviewDataGrid;
        private System.Windows.Forms.Label resultsHeader;
        private System.Windows.Forms.Button btnViewFamilyObservations;
        private System.Windows.Forms.DataGridViewButtonColumn viewResultsBtnColumn;
        private System.Windows.Forms.Button editUserDataBtn;
        private System.Windows.Forms.Button deleteUserBtn;
    }
}