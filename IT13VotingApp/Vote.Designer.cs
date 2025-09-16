namespace IT13VotingApp
{
    partial class Vote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vote));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.VoteBtn = new System.Windows.Forms.Button();
            this.PartyLbl = new System.Windows.Forms.Label();
            this.LogoutBtn = new System.Windows.Forms.Button();
            this.PartyComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(332, 108);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // VoteBtn
            // 
            this.VoteBtn.Location = new System.Drawing.Point(412, 283);
            this.VoteBtn.Name = "VoteBtn";
            this.VoteBtn.Size = new System.Drawing.Size(75, 23);
            this.VoteBtn.TabIndex = 11;
            this.VoteBtn.Text = "Vote";
            this.VoteBtn.UseVisualStyleBackColor = true;
            this.VoteBtn.Click += new System.EventHandler(this.VoteBtn_Click);
            // 
            // PartyLbl
            // 
            this.PartyLbl.AutoSize = true;
            this.PartyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartyLbl.Location = new System.Drawing.Point(290, 208);
            this.PartyLbl.Name = "PartyLbl";
            this.PartyLbl.Size = new System.Drawing.Size(59, 20);
            this.PartyLbl.TabIndex = 7;
            this.PartyLbl.Text = "Party:";
            // 
            // LogoutBtn
            // 
            this.LogoutBtn.Location = new System.Drawing.Point(306, 283);
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Size = new System.Drawing.Size(75, 23);
            this.LogoutBtn.TabIndex = 14;
            this.LogoutBtn.Text = "Logout";
            this.LogoutBtn.UseVisualStyleBackColor = true;
            this.LogoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // PartyComboBox
            // 
            this.PartyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PartyComboBox.FormattingEnabled = true;
            this.PartyComboBox.Location = new System.Drawing.Point(355, 208);
            this.PartyComboBox.Name = "PartyComboBox";
            this.PartyComboBox.Size = new System.Drawing.Size(121, 24);
            this.PartyComboBox.TabIndex = 15;
            // 
            // Vote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PartyComboBox);
            this.Controls.Add(this.LogoutBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.VoteBtn);
            this.Controls.Add(this.PartyLbl);
            this.Name = "Vote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vote";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button VoteBtn;
        private System.Windows.Forms.Label PartyLbl;
        private System.Windows.Forms.Button LogoutBtn;
        private System.Windows.Forms.ComboBox PartyComboBox;
    }
}