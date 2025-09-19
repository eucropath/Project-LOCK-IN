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
    public partial class CandidateForm : Form
    {
        public CandidateForm()
        {
            InitializeComponent();
        }
        private void LoadParties()
        {
            var dt = DataAccess.ExecuteProcedureToDataTable("sp_GetAllParties");
            cmbParty.DataSource = dt;
            cmbParty.DisplayMember = "PartyName";
            cmbParty.ValueMember = "PartyID";
            DataAccess.ExecuteProcedureNonQuery("sp_AddCandidate",
   new MySqlParameter("@in_fn", txtFirst.Text.Trim()),
   new MySqlParameter("@in_ln", txtLast.Text.Trim()),
   new MySqlParameter("@in_party", Convert.ToInt32(cmbParty.SelectedValue)),
   new MySqlParameter("@in_position", txtPosition.Text.Trim())
);
        }

        private void dgvCandidates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
