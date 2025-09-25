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
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandidates)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCandidates
            // 
            this.dgvCandidates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCandidates.Location = new System.Drawing.Point(59, 50);
            this.dgvCandidates.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCandidates.Name = "dgvCandidates";
            this.dgvCandidates.RowHeadersWidth = 51;
            this.dgvCandidates.RowTemplate.Height = 24;
            this.dgvCandidates.Size = new System.Drawing.Size(471, 122);
            this.dgvCandidates.TabIndex = 0;
            this.dgvCandidates.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCandidates_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(262, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vote";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbPositions
            // 
            this.cmbPositions.FormattingEnabled = true;
            this.cmbPositions.Location = new System.Drawing.Point(240, 194);
            this.cmbPositions.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPositions.Name = "cmbPositions";
            this.cmbPositions.Size = new System.Drawing.Size(92, 21);
            this.cmbPositions.TabIndex = 2;
            this.cmbPositions.SelectedIndexChanged += new System.EventHandler(this.cmbPositions_SelectedIndexChanged_1);
            // 
            // cmbCandidates
            // 
            this.cmbCandidates.FormattingEnabled = true;
            this.cmbCandidates.Location = new System.Drawing.Point(240, 233);
            this.cmbCandidates.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCandidates.Name = "cmbCandidates";
            this.cmbCandidates.Size = new System.Drawing.Size(92, 21);
            this.cmbCandidates.TabIndex = 3;
            this.cmbCandidates.SelectedIndexChanged += new System.EventHandler(this.cmbCandidates_SelectedIndexChanged);
            // 
            // txtVoterNumber
            // 
            this.txtVoterNumber.Location = new System.Drawing.Point(245, 281);
            this.txtVoterNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtVoterNumber.Name = "txtVoterNumber";
            this.txtVoterNumber.Size = new System.Drawing.Size(76, 20);
            this.txtVoterNumber.TabIndex = 4;
            this.txtVoterNumber.TextChanged += new System.EventHandler(this.txtVoterNumber_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(975, 552);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 5;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 266);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Voter Number:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnCastVote
            // 
            this.btnCastVote.Location = new System.Drawing.Point(193, 317);
            this.btnCastVote.Margin = new System.Windows.Forms.Padding(2);
            this.btnCastVote.Name = "btnCastVote";
            this.btnCastVote.Size = new System.Drawing.Size(79, 19);
            this.btnCastVote.TabIndex = 7;
            this.btnCastVote.Text = "Cast Vote";
            this.btnCastVote.UseVisualStyleBackColor = true;
            this.btnCastVote.Click += new System.EventHandler(this.btnCastVote_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(323, 317);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 9;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 179);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Position";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // VotingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCastVote);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVoterNumber);
            this.Controls.Add(this.cmbCandidates);
            this.Controls.Add(this.cmbPositions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCandidates);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VotingForm";
            this.Text = "VotingForm";
            this.Load += new System.EventHandler(this.VotingForm_Load);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
    }
}