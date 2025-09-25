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
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
            LoadPositions();
            LoadResults();
            cmbPositions.SelectedIndexChanged += cmbPositions_SelectedIndexChanged;
        }
        private void LoadPositions()
        {
            var dt = DataAccess.ExecuteProcedureToDataTable("sp_GetAllPositions");
            cmbPositions.DataSource = dt;
            cmbPositions.DisplayMember = "Position";
            cmbPositions.ValueMember = "Position";
            cmbPositions.SelectedIndexChanged += cmbPositions_SelectedIndexChanged;
        }
        private void LoadResults(string position = "")
        {
            DataTable dt;
            if (string.IsNullOrEmpty(position))
                dt = DataAccess.ExecuteProcedureToDataTable("sp_GetResults");
            else
                dt = DataAccess.ExecuteProcedureToDataTable("sp_GetResultsByPosition",
                    new MySql.Data.MySqlClient.MySqlParameter("@in_position", position));

            dgvResults.DataSource = dt;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.Columns["VoteCount"].DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Show winner
            if (dt.Rows.Count > 0)
            {
                var maxVotes = dt.AsEnumerable().Max(r => r.Field<Int64>("VoteCount"));
                var winnerRows = dt.AsEnumerable()
                    .Where(r => r.Field<Int64>("VoteCount") == maxVotes)
                    .Select(r => r.Field<string>("Candidate"));
                lblWinner.Text = $"Winner: {string.Join(", ", winnerRows)} ({maxVotes} votes)";
            }
            else
            {
                lblWinner.Text = "Winner: N/A";
            }

            // Show total votes
            var totalVotes = dt.AsEnumerable().Sum(r => r.Field<Int64>("VoteCount"));
            lblTotalVotes.Text = $"Total Votes: {totalVotes}";
        }
        private void ResultsForm_Load(object sender, EventArgs e)
        {

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Get the currently selected position from the ComboBox
            var pos = cmbPositions.SelectedValue?.ToString() ?? "";

            // Reload the results for the selected position
            LoadResults(pos);
        }
        private void cmbPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pos = cmbPositions.SelectedValue?.ToString() ?? "";
            LoadResults(pos);
        }

    }

}

