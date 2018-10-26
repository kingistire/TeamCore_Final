namespace Login {
    partial class GuidedInstructions {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuidedInstructions));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.readOutLoudPanel = new System.Windows.Forms.Panel();
            this.readOutLoudToggleBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.readOutLoudPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(226, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Instructions";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(483, 361);
            this.label2.TabIndex = 15;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 508);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(483, 81);
            this.label3.TabIndex = 17;
            this.label3.Text = "When you circle things, the person interviewing you might ask you to talk a bit m" +
    "ore about it. You can also talk about things you react to that are not on the pa" +
    "ge.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Login.Properties.Resources.aLotaLittle;
            this.pictureBox1.Location = new System.Drawing.Point(230, 421);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Navy;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(312, 599);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(190, 43);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Begin Interview";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // readOutLoudPanel
            // 
            this.readOutLoudPanel.BackColor = System.Drawing.Color.White;
            this.readOutLoudPanel.Controls.Add(this.readOutLoudToggleBtn);
            this.readOutLoudPanel.Location = new System.Drawing.Point(59, 599);
            this.readOutLoudPanel.Name = "readOutLoudPanel";
            this.readOutLoudPanel.Size = new System.Drawing.Size(163, 48);
            this.readOutLoudPanel.TabIndex = 58;
            // 
            // readOutLoudToggleBtn
            // 
            this.readOutLoudToggleBtn.BackColor = System.Drawing.Color.Transparent;
            this.readOutLoudToggleBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.readOutLoudToggleBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.readOutLoudToggleBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.readOutLoudToggleBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.readOutLoudToggleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readOutLoudToggleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readOutLoudToggleBtn.ForeColor = System.Drawing.Color.Navy;
            this.readOutLoudToggleBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.readOutLoudToggleBtn.Location = new System.Drawing.Point(0, 0);
            this.readOutLoudToggleBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.readOutLoudToggleBtn.Name = "readOutLoudToggleBtn";
            this.readOutLoudToggleBtn.Size = new System.Drawing.Size(163, 48);
            this.readOutLoudToggleBtn.TabIndex = 55;
            this.readOutLoudToggleBtn.Text = "ReadOutLoud: Off";
            this.readOutLoudToggleBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.readOutLoudToggleBtn.UseVisualStyleBackColor = false;
            this.readOutLoudToggleBtn.Click += new System.EventHandler(this.readOutLoudToggleBtn_Click);
            // 
            // GuidedInstructions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(567, 659);
            this.Controls.Add(this.readOutLoudPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(582, 696);
            this.Name = "GuidedInstructions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guided Interview Instructions";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.readOutLoudPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel readOutLoudPanel;
        private System.Windows.Forms.Button readOutLoudToggleBtn;
    }
}