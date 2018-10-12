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
            this.resultsHeader = new System.Windows.Forms.Label();
            this.viewFamilyObservationBtn = new System.Windows.Forms.Button();
            this.editUserDataBtn = new System.Windows.Forms.Button();
            this.deleteUserBtn = new System.Windows.Forms.Button();
            this.exportProfileBtn = new System.Windows.Forms.Button();
            this.InterviewHistoryDataGrid = new System.Windows.Forms.DataGridView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.selectInterview = new System.Windows.Forms.DataGridViewButtonColumn();
            this.interviewType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.InterviewHistoryDataGrid)).BeginInit();
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
            // resultsHeader
            // 
            this.resultsHeader.AutoSize = true;
            this.resultsHeader.BackColor = System.Drawing.Color.Transparent;
            this.resultsHeader.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultsHeader.ForeColor = System.Drawing.Color.DarkBlue;
            this.resultsHeader.Location = new System.Drawing.Point(183, 125);
            this.resultsHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.resultsHeader.Name = "resultsHeader";
            this.resultsHeader.Size = new System.Drawing.Size(182, 29);
            this.resultsHeader.TabIndex = 32;
            this.resultsHeader.Text = "Interview History";
            this.resultsHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // viewFamilyObservationBtn
            // 
            this.viewFamilyObservationBtn.BackColor = System.Drawing.Color.White;
            this.viewFamilyObservationBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.viewFamilyObservationBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.viewFamilyObservationBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.viewFamilyObservationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewFamilyObservationBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewFamilyObservationBtn.ForeColor = System.Drawing.Color.Navy;
            this.viewFamilyObservationBtn.Image = ((System.Drawing.Image)(resources.GetObject("viewFamilyObservationBtn.Image")));
            this.viewFamilyObservationBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.viewFamilyObservationBtn.Location = new System.Drawing.Point(356, 42);
            this.viewFamilyObservationBtn.Margin = new System.Windows.Forms.Padding(2);
            this.viewFamilyObservationBtn.Name = "viewFamilyObservationBtn";
            this.viewFamilyObservationBtn.Size = new System.Drawing.Size(164, 60);
            this.viewFamilyObservationBtn.TabIndex = 33;
            this.viewFamilyObservationBtn.Text = "[View Family Observations]";
            this.viewFamilyObservationBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.viewFamilyObservationBtn.UseVisualStyleBackColor = false;
            this.viewFamilyObservationBtn.Click += new System.EventHandler(this.viewFamilyObservationBtn_Click);
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
            this.editUserDataBtn.Location = new System.Drawing.Point(188, 42);
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
            this.deleteUserBtn.Location = new System.Drawing.Point(702, 42);
            this.deleteUserBtn.Margin = new System.Windows.Forms.Padding(2);
            this.deleteUserBtn.Name = "deleteUserBtn";
            this.deleteUserBtn.Size = new System.Drawing.Size(164, 60);
            this.deleteUserBtn.TabIndex = 35;
            this.deleteUserBtn.Text = "Delete Profile";
            this.deleteUserBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteUserBtn.UseVisualStyleBackColor = false;
            this.deleteUserBtn.Click += new System.EventHandler(this.deleteUserBtn_Click);
            // 
            // exportProfileBtn
            // 
            this.exportProfileBtn.BackColor = System.Drawing.Color.White;
            this.exportProfileBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exportProfileBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.exportProfileBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.exportProfileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportProfileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportProfileBtn.ForeColor = System.Drawing.Color.Navy;
            this.exportProfileBtn.Image = ((System.Drawing.Image)(resources.GetObject("exportProfileBtn.Image")));
            this.exportProfileBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exportProfileBtn.Location = new System.Drawing.Point(524, 42);
            this.exportProfileBtn.Margin = new System.Windows.Forms.Padding(2);
            this.exportProfileBtn.Name = "exportProfileBtn";
            this.exportProfileBtn.Size = new System.Drawing.Size(174, 60);
            this.exportProfileBtn.TabIndex = 36;
            this.exportProfileBtn.Text = "Export Profile";
            this.exportProfileBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportProfileBtn.UseVisualStyleBackColor = false;
            this.exportProfileBtn.Click += new System.EventHandler(this.exportProfileBtn_Click);
            // 
            // InterviewHistoryDataGrid
            // 
            this.InterviewHistoryDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InterviewHistoryDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectInterview,
            this.interviewType});
            this.InterviewHistoryDataGrid.Location = new System.Drawing.Point(188, 169);
            this.InterviewHistoryDataGrid.Name = "InterviewHistoryDataGrid";
            this.InterviewHistoryDataGrid.Size = new System.Drawing.Size(678, 218);
            this.InterviewHistoryDataGrid.TabIndex = 37;
            this.InterviewHistoryDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InterviewHistoryDataGrid_CellContentClick);
            // 
            // selectInterview
            // 
            this.selectInterview.HeaderText = "Select Interview";
            this.selectInterview.Name = "selectInterview";
            this.selectInterview.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.selectInterview.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.selectInterview.Text = "View Interview";
            this.selectInterview.UseColumnTextForButtonValue = true;
            // 
            // interviewType
            // 
            this.interviewType.HeaderText = "Interview Type";
            this.interviewType.Name = "interviewType";
            // 
            // ProfilePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 399);
            this.Controls.Add(this.InterviewHistoryDataGrid);
            this.Controls.Add(this.exportProfileBtn);
            this.Controls.Add(this.deleteUserBtn);
            this.Controls.Add(this.editUserDataBtn);
            this.Controls.Add(this.viewFamilyObservationBtn);
            this.Controls.Add(this.resultsHeader);
            this.Controls.Add(this.mailLabel);
            this.Controls.Add(this.phLabel);
            this.Controls.Add(this.genderLabel);
            this.Controls.Add(this.dobLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "ProfilePage";
            this.Text = "ProfilePage";
            this.Load += new System.EventHandler(this.ProfilePage_Load);
            this.Enter += new System.EventHandler(this.ProfilePage_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.InterviewHistoryDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label dobLabel;
        private System.Windows.Forms.Label genderLabel;
        private System.Windows.Forms.Label phLabel;
        private System.Windows.Forms.Label mailLabel;
        private System.Windows.Forms.Label resultsHeader;
        private System.Windows.Forms.Button viewFamilyObservationBtn;
        private System.Windows.Forms.Button editUserDataBtn;
        private System.Windows.Forms.Button deleteUserBtn;
        private System.Windows.Forms.Button exportProfileBtn;
        private System.Windows.Forms.DataGridView InterviewHistoryDataGrid;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridViewButtonColumn selectInterview;
        private System.Windows.Forms.DataGridViewTextBoxColumn interviewType;
    }
}