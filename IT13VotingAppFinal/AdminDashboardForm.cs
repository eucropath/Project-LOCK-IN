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
    public partial class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();
            btnVoters.Click += btnVoters_Click;
            btnCandidates.Click += btnCandidates_Click;
            btnResults.Click += btnResults_Click;
            btnLogout.Click += btnLogout_Click;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnVoters_Click(object sender, EventArgs e)
        {
            var vf = new VoterForm();
            vf.ShowDialog();
        }
        private void btnCandidates_Click(object sender, EventArgs e)
        {
            var candidateForm = new CandidateForm();
            candidateForm.ShowDialog();
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            var resultsForm = new ResultsForm();
            resultsForm.ShowDialog();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }

        private void btnVoting_Click_1(object sender, EventArgs e)
        {

        }
    }
}
