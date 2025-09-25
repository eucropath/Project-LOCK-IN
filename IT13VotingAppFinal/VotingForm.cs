using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT13VotingAppFinal
{
    public partial class VotingForm : Form
    {
        private Form voterDashboard;

        public VotingForm(Form dashboard)
        {
            InitializeComponent();
            voterDashboard = dashboard;
            LoadPositions();
            LoadCandidates();
            cmbPositions.SelectedIndexChanged += cmbPositions_SelectedIndexChanged;

            this.Load += VotingForm_Load;
        }

        private void btnCastVote_Click(object sender, EventArgs e)
        {
            if (dgvCandidates.CurrentRow == null)
            {
                MessageBox.Show("Select a candidate.");
                return;
            }
            string vnum = txtVoterNumber.Text.Trim();
            if (string.IsNullOrEmpty(vnum)) { MessageBox.Show("Enter voter number."); return; }

            try
            {
                var dt = DataAccess.ExecuteProcedureToDataTable("sp_GetVoterByNumber",
                    new MySqlParameter("@in_vnum", vnum));
                if (dt.Rows.Count == 0) { MessageBox.Show("Voter not found."); return; }
                int voterId = Convert.ToInt32(dt.Rows[0]["VoterID"]);

                int candidateId = Convert.ToInt32(dgvCandidates.CurrentRow.Cells["CandidateID"].Value);

                // Call transactional stored procedure
                DataAccess.ExecuteProcedureNonQuery("sp_CastVote",
                    new MySqlParameter("@in_voterid", voterId),
                    new MySqlParameter("@in_candidateid", candidateId)
                );

                MessageBox.Show("Vote cast successfully.");
                // refresh UI, mark voter as voted etc.
            }
            catch (MySqlException mex)
            {
                MessageBox.Show("Database error: " + mex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void LoadPositions()
        {
            var dt = DataAccess.ExecuteProcedureToDataTable("sp_GetAllPositions");
            cmbPositions.DataSource = dt;
            cmbPositions.DisplayMember = "Position"; // column name from your table
            cmbPositions.ValueMember = "Position";   // same as DisplayMember if just using text
        }
        private void cmbPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPositions.SelectedValue != null)
            {
                string selectedPosition = cmbPositions.SelectedValue.ToString();
                var dt = DataAccess.ExecuteProcedureToDataTable("sp_GetCandidatesByPosition",
                    new MySqlParameter("@in_position", selectedPosition));
                dgvCandidates.DataSource = dt;

                // Fill the candidate ComboBox with filtered candidates
                dt.Columns.Add("FullName", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    row["FullName"] = row["FirstName"] + " " + row["LastName"];
                }
                cmbCandidates.DataSource = dt;
                cmbCandidates.DisplayMember = "FullName";
                cmbCandidates.ValueMember = "CandidateId";
            }
        }
        private void LoadCandidates()
        {
            var dt = DataAccess.ExecuteProcedureToDataTable("sp_GetAllCandidates");
            dgvCandidates.DataSource = dt;

            // Fill ComboBox with candidates (showing full name and position)
            cmbCandidates.DataSource = dt;
            cmbCandidates.DisplayMember = "FirstName"; // or use a custom property for full name
            cmbCandidates.ValueMember = "CandidateId";

            dt.Columns.Add("FullName", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                row["FullName"] = row["FirstName"] + " " + row["LastName"] + " (" + row["Position"] + ")";
            }

            cmbCandidates.DataSource = dt;
            cmbCandidates.DisplayMember = "FullName";
            cmbCandidates.ValueMember = "CandidateId";
        }

        private void VotingForm_Load(object sender, EventArgs e)
        {
            // === Form Styling ===
            this.Text = "Voting Form";
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(900, 600);

            // === Title Label ===
            label1.Text = "Voting Form";
            label1.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(16, 40, 64); // dark blue
            label1.AutoSize = true;

            // === Labels ===
            StyleLabel(label2, "Voter Number:");
            StyleLabel(label3, "Position:");
            StyleLabel(label4, "Candidate:");

            // === Inputs ===
            StyleTextBox(txtVoterNumber);
            StyleComboBox(cmbPositions);
            StyleComboBox(cmbCandidates);

            // === DataGridView ===
            StyleDataGridView(dgvCandidates);

            // === Buttons ===
            StyleButton(btnCastVote, "Cast Vote", Color.FromArgb(0, 123, 255), Color.White); // blue
            StyleButton(button1, "Back", Color.FromArgb(220, 53, 69), Color.White); // red

            // Center everything
            CenterControls();

            // Recenter when resized
            this.Resize += (s, ev) => CenterControls();
        }

        private void StyleLabel(Label lbl, string text)
        {
            lbl.Text = text;
            lbl.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            lbl.ForeColor = Color.Black;
            lbl.BackColor = Color.Transparent;
            lbl.AutoSize = true;
        }
        private void StyleTextBox(TextBox txt)
        {
            txt.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            txt.Width = 250;
        }

        private void StyleComboBox(ComboBox cmb)
        {
            cmb.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            cmb.Width = 250;
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dgv.ForeColor = Color.Black;
            dgv.BackgroundColor = Color.White;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.Height = 200;
        }

      private void StyleButton(Button btn, string text, Color backColor, Color foreColor)
        {
            btn.Text = text;
            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Size = new Size(140, 40);
        }

        private void CenterControls()
        {
            int centerX = this.ClientSize.Width / 2;

            // Title
            label1.Left = centerX - (label1.Width / 2);
            label1.Top = 30;

            // DataGridView
            dgvCandidates.Width = this.ClientSize.Width - 100;
            dgvCandidates.Left = (this.ClientSize.Width - dgvCandidates.Width) / 2;
            dgvCandidates.Top = 80;

            int currentY = dgvCandidates.Bottom + 30;
            int labelX = centerX - 200;
            int inputX = centerX;

            // Voter Number
            label2.Left = labelX;
            label2.Top = currentY;
            txtVoterNumber.Left = inputX;
            txtVoterNumber.Top = currentY - 3;
            currentY += 50;

            // Position
            label3.Left = labelX;
            label3.Top = currentY;
            cmbPositions.Left = inputX;
            cmbPositions.Top = currentY - 3;
            currentY += 50;

            // Candidate
            label4.Left = labelX;
            label4.Top = currentY;
            cmbCandidates.Left = inputX;
            cmbCandidates.Top = currentY - 3;
            currentY += 70;

            // Buttons
            btnCastVote.Left = centerX - (btnCastVote.Width + 20);
            btnCastVote.Top = currentY;

            button1.Left = centerX + 20;
            button1.Top = currentY;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtVoterNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvCandidates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbPositions_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void cmbCandidates_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            voterDashboard.Show();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
    }

    


