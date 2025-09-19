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
        public VotingForm()
        {
            InitializeComponent();
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
    }
    }

