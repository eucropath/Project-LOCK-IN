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
    public partial class VoterForm : Form
    {
        public VoterForm()
        {
            InitializeComponent();
        }
        private void LoadVoters()
        {
            var dt = DataAccess.ExecuteProcedureToDataTable("sp_GetAllVoters"); // you need sp_GetAllVoters
            dgvVoters.DataSource = dt;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.ExecuteProcedureNonQuery("sp_AddVoter",
                    new MySqlParameter("@in_vnum", txtVoterNumber.Text.Trim()),
                    new MySqlParameter("@in_fn", txtFirstName.Text.Trim()),
                    new MySqlParameter("@in_ln", txtLastName.Text.Trim()),
                    new MySqlParameter("@in_email", txtEmail.Text.Trim())
                );
                MessageBox.Show("Voter added.");
                LoadVoters();
                
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
    }
}
