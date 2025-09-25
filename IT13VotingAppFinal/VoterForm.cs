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
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnClear.Click += btnClear_Click;

            dgvVoters.SelectionChanged += dgvVoters_SelectionChanged;

            LoadVoters();
        }
        private void LoadVoters()
        {
            var dt = DataAccess.ExecuteProcedureToDataTable("sp_GetAllVoters"); // you need sp_GetAllVoters
            dgvVoters.DataSource = dt;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string voterNumber = txtVoterNumber.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(voterNumber) || string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            try
            {
                DataAccess.ExecuteProcedureNonQuery("sp_AddVoter",
                   new MySqlParameter("@in_vnum", txtVoterNumber.Text.Trim()),
                   new MySqlParameter("@in_fn", txtFirstName.Text.Trim()),
                   new MySqlParameter("@in_ln", txtLastName.Text.Trim()),
                   new MySqlParameter("@in_email", txtEmail.Text.Trim())
                   );
                 LoadVoters();
                ClearFields();
                MessageBox.Show("Voter added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding voter: " + ex.Message);
            }
        }
        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvVoters.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a voter to update.");
                return;
            }

            // Get the Id from the selected row in the DataGridView
            var row = dgvVoters.SelectedRows[0];
            string id = row.Cells["VoterId"].Value.ToString(); 
            string voterNumber = txtVoterNumber.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();

            try
            {
                DataAccess.ExecuteProcedureNonQuery("sp_UpdateVoter",
                   new MySqlParameter("@in_id", id),
                   new MySqlParameter("@in_vnum", voterNumber),
                   new MySqlParameter("@in_fn", firstName),
                   new MySqlParameter("@in_ln", lastName),
                   new MySqlParameter("@in_email", email));
                LoadVoters();
                ClearFields();
                MessageBox.Show("Voter updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating voter: " + ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvVoters.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a voter to delete.");
                return;
            }

            // Get the Id from the selected row in the DataGridView
            var row = dgvVoters.SelectedRows[0];
            string id = row.Cells["VoterId"].Value.ToString(); // Use the actual column name

            try
            {
                DataAccess.ExecuteProcedureNonQuery("sp_DeleteVoter",
                    new MySqlParameter("@in_id", id));
                LoadVoters();
                ClearFields();
                MessageBox.Show("Voter deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting voter: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadVoters();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            txtVoterNumber.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
        }
        private void dgvVoters_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVoters.SelectedRows.Count > 0)
            {
                var row = dgvVoters.SelectedRows[0];
                txtVoterNumber.Text = row.Cells["VoterNumber"].Value.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void VoterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
