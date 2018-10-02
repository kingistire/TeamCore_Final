﻿namespace Login
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
            this.createProfileBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userProfileManagmentGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(399, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 73);
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
            this.label8.Location = new System.Drawing.Point(103, 45);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(262, 36);
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
            this.label2.Location = new System.Drawing.Point(145, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 23);
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
            this.userProfileManagmentGrid.Location = new System.Drawing.Point(30, 164);
            this.userProfileManagmentGrid.Name = "userProfileManagmentGrid";
            this.userProfileManagmentGrid.ReadOnly = true;
            this.userProfileManagmentGrid.Size = new System.Drawing.Size(654, 272);
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
            // createProfileBtn
            // 
            this.createProfileBtn.Location = new System.Drawing.Point(30, 95);
            this.createProfileBtn.Name = "createProfileBtn";
            this.createProfileBtn.Size = new System.Drawing.Size(124, 46);
            this.createProfileBtn.TabIndex = 27;
            this.createProfileBtn.Text = "Create Profile";
            this.createProfileBtn.UseVisualStyleBackColor = true;
            this.createProfileBtn.Click += new System.EventHandler(this.createProfileBtn_Click);
            // 
            // UserManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 462);
            this.Controls.Add(this.createProfileBtn);
            this.Controls.Add(this.userProfileManagmentGrid);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserManagment";
            this.Text = "Create Profile";
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
        private System.Windows.Forms.Button createProfileBtn;
        private System.Windows.Forms.DataGridViewButtonColumn editProfileBtnCol;
        private System.Windows.Forms.DataGridViewButtonColumn viewProfileBtnCol;
    }
}