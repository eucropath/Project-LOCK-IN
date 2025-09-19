namespace IT13VotingAppFinal
{
    partial class VotingForm
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
            this.dgvCandidates = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPositions = new System.Windows.Forms.ComboBox();
            this.cmbCandidates = new System.Windows.Forms.ComboBox();
            this.txtVoterNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCastVote = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandidates)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCandidates
            // 
            this.dgvCandidates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCandidates.Location = new System.Drawing.Point(243, 61);
            this.dgvCandidates.Name = "dgvCandidates";
            this.dgvCandidates.RowHeadersWidth = 51;
            this.dgvCandidates.RowTemplate.Height = 24;
            this.dgvCandidates.Size = new System.Drawing.Size(276, 150);
            this.dgvCandidates.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(349, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vote";
            // 
            // cmbPositions
            // 
            this.cmbPositions.FormattingEnabled = true;
            this.cmbPositions.Location = new System.Drawing.Point(320, 231);
            this.cmbPositions.Name = "cmbPositions";
            this.cmbPositions.Size = new System.Drawing.Size(121, 24);
            this.cmbPositions.TabIndex = 2;
            // 
            // cmbCandidates
            // 
            this.cmbCandidates.FormattingEnabled = true;
            this.cmbCandidates.Location = new System.Drawing.Point(320, 270);
            this.cmbCandidates.Name = "cmbCandidates";
            this.cmbCandidates.Size = new System.Drawing.Size(121, 24);
            this.cmbCandidates.TabIndex = 3;
            // 
            // txtVoterNumber
            // 
            this.txtVoterNumber.Location = new System.Drawing.Point(330, 329);
            this.txtVoterNumber.Name = "txtVoterNumber";
            this.txtVoterNumber.Size = new System.Drawing.Size(100, 22);
            this.txtVoterNumber.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1300, 679);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Voter Number:";
            // 
            // btnCastVote
            // 
            this.btnCastVote.Location = new System.Drawing.Point(340, 357);
            this.btnCastVote.Name = "btnCastVote";
            this.btnCastVote.Size = new System.Drawing.Size(75, 23);
            this.btnCastVote.TabIndex = 7;
            this.btnCastVote.Text = "Cast Vote";
            this.btnCastVote.UseVisualStyleBackColor = true;
            this.btnCastVote.Click += new System.EventHandler(this.btnCastVote_Click);
            // 
            // VotingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCastVote);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVoterNumber);
            this.Controls.Add(this.cmbCandidates);
            this.Controls.Add(this.cmbPositions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCandidates);
            this.Name = "VotingForm";
            this.Text = "VotingForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandidates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCandidates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPositions;
        private System.Windows.Forms.ComboBox cmbCandidates;
        private System.Windows.Forms.TextBox txtVoterNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCastVote;
    }
}