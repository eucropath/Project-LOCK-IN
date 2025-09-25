namespace IT13VotingAppFinal
{
    partial class AdminDashboardForm
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
            this.btnVoters = new System.Windows.Forms.Button();
            this.btnCandidates = new System.Windows.Forms.Button();
            this.btnVoting = new System.Windows.Forms.Button();
            this.btnResults = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVoters
            // 
            this.btnVoters.Location = new System.Drawing.Point(21, 93);
            this.btnVoters.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVoters.Name = "btnVoters";
            this.btnVoters.Size = new System.Drawing.Size(66, 19);
            this.btnVoters.TabIndex = 0;
            this.btnVoters.Text = "Voters";
            this.btnVoters.UseVisualStyleBackColor = true;
            this.btnVoters.Click += new System.EventHandler(this.btnVoters_Click);
            // 
            // btnCandidates
            // 
            this.btnCandidates.Location = new System.Drawing.Point(21, 127);
            this.btnCandidates.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCandidates.Name = "btnCandidates";
            this.btnCandidates.Size = new System.Drawing.Size(66, 19);
            this.btnCandidates.TabIndex = 1;
            this.btnCandidates.Text = "Candidates";
            this.btnCandidates.UseVisualStyleBackColor = true;
            // 
            // btnVoting
            // 
            this.btnVoting.Location = new System.Drawing.Point(21, 158);
            this.btnVoting.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVoting.Name = "btnVoting";
            this.btnVoting.Size = new System.Drawing.Size(66, 19);
            this.btnVoting.TabIndex = 3;
            this.btnVoting.Text = "Voting";
            this.btnVoting.UseVisualStyleBackColor = true;
            this.btnVoting.Click += new System.EventHandler(this.btnVoting_Click_1);
            // 
            // btnResults
            // 
            this.btnResults.Location = new System.Drawing.Point(21, 194);
            this.btnResults.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(66, 19);
            this.btnResults.TabIndex = 4;
            this.btnResults.Text = "Results";
            this.btnResults.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(21, 231);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(66, 19);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.button6_Click);
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnResults);
            this.Controls.Add(this.btnVoting);
            this.Controls.Add(this.btnCandidates);
            this.Controls.Add(this.btnVoters);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AdminDashboardForm";
            this.Text = "AdminDashboardForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVoters;
        private System.Windows.Forms.Button btnCandidates;
        private System.Windows.Forms.Button btnVoting;
        private System.Windows.Forms.Button btnResults;
        private System.Windows.Forms.Button btnLogout;
    }
}