namespace Login
{
    partial class UserManagment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagment));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userProfileManagmentGrid = new System.Windows.Forms.DataGridView();
            this.editProfileBtnCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.viewProfileBtnCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.importProfilesBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.exportAllProfilesBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userProfileManagmentGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1069, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkBlue;
            this.label8.Location = new System.Drawing.Point(321, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(388, 54);
            this.label8.TabIndex = 23;
            this.label8.Text = "Here you can view all of the user profiles \r\nyou have created for your patients";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(385, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 35);
            this.label2.TabIndex = 24;
            this.label2.Text = "View user profiles";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userProfileManagmentGrid
            // 
            this.userProfileManagmentGrid.AllowUserToAddRows = false;
            this.userProfileManagmentGrid.AllowUserToDeleteRows = false;
            this.userProfileManagmentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userProfileManagmentGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.editProfileBtnCol,
            this.viewProfileBtnCol});
            this.userProfileManagmentGrid.Location = new System.Drawing.Point(69, 261);
            this.userProfileManagmentGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userProfileManagmentGrid.Name = "userProfileManagmentGrid";
            this.userProfileManagmentGrid.ReadOnly = true;
            this.userProfileManagmentGrid.Size = new System.Drawing.Size(1279, 418);
            this.userProfileManagmentGrid.TabIndex = 26;
            this.userProfileManagmentGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userProfileManagmentGrid_CellContentClick);
            // 
            // editProfileBtnCol
            // 
            this.editProfileBtnCol.HeaderText = "Edit";
            this.editProfileBtnCol.Name = "editProfileBtnCol";
            this.editProfileBtnCol.ReadOnly = true;
            this.editProfileBtnCol.Text = "Edit";
            this.editProfileBtnCol.UseColumnTextForButtonValue = true;
            // 
            // viewProfileBtnCol
            // 
            this.viewProfileBtnCol.HeaderText = "ViewProfile";
            this.viewProfileBtnCol.Name = "viewProfileBtnCol";
            this.viewProfileBtnCol.ReadOnly = true;
            this.viewProfileBtnCol.Text = "View";
            this.viewProfileBtnCol.UseColumnTextForButtonValue = true;
            // 
            // importProfilesBtn
            // 
            this.importProfilesBtn.BackColor = System.Drawing.Color.White;
            this.importProfilesBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.importProfilesBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.importProfilesBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.importProfilesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importProfilesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importProfilesBtn.ForeColor = System.Drawing.Color.Navy;
            this.importProfilesBtn.Location = new System.Drawing.Point(391, 155);
            this.importProfilesBtn.Name = "importProfilesBtn";
            this.importProfilesBtn.Size = new System.Drawing.Size(192, 71);
            this.importProfilesBtn.TabIndex = 35;
            this.importProfilesBtn.Text = "Import Profiles";
            this.importProfilesBtn.UseVisualStyleBackColor = false;
            this.importProfilesBtn.Click += new System.EventHandler(this.importProfilesBtn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(212, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 71);
            this.button1.TabIndex = 36;
            this.button1.Text = "Create Profile";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.createProfileBtn_Click);
            // 
            // exportAllProfilesBtn
            // 
            this.exportAllProfilesBtn.BackColor = System.Drawing.Color.White;
            this.exportAllProfilesBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exportAllProfilesBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.exportAllProfilesBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.exportAllProfilesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportAllProfilesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportAllProfilesBtn.ForeColor = System.Drawing.Color.Navy;
            this.exportAllProfilesBtn.Location = new System.Drawing.Point(589, 155);
            this.exportAllProfilesBtn.Name = "exportAllProfilesBtn";
            this.exportAllProfilesBtn.Size = new System.Drawing.Size(230, 71);
            this.exportAllProfilesBtn.TabIndex = 37;
            this.exportAllProfilesBtn.Text = "Export All Profiles";
            this.exportAllProfilesBtn.UseVisualStyleBackColor = false;
            this.exportAllProfilesBtn.Click += new System.EventHandler(this.exportAllProfilesBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // UserManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 735);
            this.Controls.Add(this.exportAllProfilesBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.importProfilesBtn);
            this.Controls.Add(this.userProfileManagmentGrid);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserManagment";
            this.Text = "User Management";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Enter += new System.EventHandler(this.UserManagment_GotFocus);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userProfileManagmentGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView userProfileManagmentGrid;
        private System.Windows.Forms.DataGridViewButtonColumn editProfileBtnCol;
        private System.Windows.Forms.DataGridViewButtonColumn viewProfileBtnCol;
        private System.Windows.Forms.Button importProfilesBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button exportAllProfilesBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}