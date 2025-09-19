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
            this.btnParties = new System.Windows.Forms.Button();
            this.btnVoting = new System.Windows.Forms.Button();
            this.btnResults = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVoters
            // 
            this.btnVoters.Location = new System.Drawing.Point(12, 68);
            this.btnVoters.Name = "btnVoters";
            this.btnVoters.Size = new System.Drawing.Size(88, 23);
            this.btnVoters.TabIndex = 0;
            this.btnVoters.Text = "Voters";
            this.btnVoters.UseVisualStyleBackColor = true;
            this.btnVoters.Click += new System.EventHandler(this.btnVoters_Click);
            // 
            // btnCandidates
            // 
            this.btnCandidates.Location = new System.Drawing.Point(12, 110);
            this.btnCandidates.Name = "btnCandidates";
            this.btnCandidates.Size = new System.Drawing.Size(88, 23);
            this.btnCandidates.TabIndex = 1;
            this.btnCandidates.Text = "Candidates";
            this.btnCandidates.UseVisualStyleBackColor = true;
            // 
            // btnParties
            // 
            this.btnParties.Location = new System.Drawing.Point(12, 152);
            this.btnParties.Name = "btnParties";
            this.btnParties.Size = new System.Drawing.Size(88, 23);
            this.btnParties.TabIndex = 2;
            this.btnParties.Text = "Parties";
            this.btnParties.UseVisualStyleBackColor = true;
            // 
            // btnVoting
            // 
            this.btnVoting.Location = new System.Drawing.Point(12, 190);
            this.btnVoting.Name = "btnVoting";
            this.btnVoting.Size = new System.Drawing.Size(88, 23);
            this.btnVoting.TabIndex = 3;
            this.btnVoting.Text = "Voting";
            this.btnVoting.UseVisualStyleBackColor = true;
            // 
            // btnResults
            // 
            this.btnResults.Location = new System.Drawing.Point(12, 234);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(88, 23);
            this.btnResults.TabIndex = 4;
            this.btnResults.Text = "Results";
            this.btnResults.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(12, 274);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(88, 23);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.button6_Click);
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnResults);
            this.Controls.Add(this.btnVoting);
            this.Controls.Add(this.btnParties);
            this.Controls.Add(this.btnCandidates);
            this.Controls.Add(this.btnVoters);
            this.Name = "AdminDashboardForm";
            this.Text = "AdminDashboardForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVoters;
        private System.Windows.Forms.Button btnCandidates;
        private System.Windows.Forms.Button btnParties;
        private System.Windows.Forms.Button btnVoting;
        private System.Windows.Forms.Button btnResults;
        private System.Windows.Forms.Button btnLogout;
    }
}