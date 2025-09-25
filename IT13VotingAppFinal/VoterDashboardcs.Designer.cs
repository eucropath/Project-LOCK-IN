namespace IT13VotingAppFinal
{
    partial class VoterDashboardcs
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
            this.btnVoting = new System.Windows.Forms.Button();
            this.btnResults = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVoting
            // 
            this.btnVoting.Location = new System.Drawing.Point(152, 146);
            this.btnVoting.Margin = new System.Windows.Forms.Padding(2);
            this.btnVoting.Name = "btnVoting";
            this.btnVoting.Size = new System.Drawing.Size(66, 19);
            this.btnVoting.TabIndex = 4;
            this.btnVoting.Text = "Voting";
            this.btnVoting.UseVisualStyleBackColor = true;
            this.btnVoting.Click += new System.EventHandler(this.btnVoting_Click);
            // 
            // btnResults
            // 
            this.btnResults.Location = new System.Drawing.Point(247, 146);
            this.btnResults.Margin = new System.Windows.Forms.Padding(2);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(66, 19);
            this.btnResults.TabIndex = 5;
            this.btnResults.Text = "Results";
            this.btnResults.UseVisualStyleBackColor = true;
            this.btnResults.Click += new System.EventHandler(this.btnResults_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(332, 146);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(66, 19);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // VoterDashboardcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnResults);
            this.Controls.Add(this.btnVoting);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VoterDashboardcs";
            this.Text = "VoterDashboardcs";
            this.Load += new System.EventHandler(this.VoterDashboardcs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVoting;
        private System.Windows.Forms.Button btnResults;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label1;
    }
}