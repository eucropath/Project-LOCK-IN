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
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;

            dgvCandidates.CellContentClick += dgvCandidates_CellContentClick;

            LoadCandidates();
        }
        private void LoadCandidates()
        {
            var dt = DataAccess.ExecuteProcedureToDataTable("sp_GetAllCandidates");
            dgvCandidates.DataSource = dt;
        }


        private void dgvCandidates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCandidates.SelectedRows.Count > 0)
            {
                var row = dgvCandidates.SelectedRows[0];
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtPosition.Text = row.Cells["Position"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string position = txtPosition.Text.Trim();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(position))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            try
            {
                DataAccess.ExecuteProcedureNonQuery("sp_AddCandidate",
                   new MySqlParameter("@FirstName", firstName),
                   new MySqlParameter("@LastName", lastName),
                   new MySqlParameter("@Position", position)
                );
                LoadCandidates();
                ClearFields();
                MessageBox.Show("Candidate added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding candidate: " + ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCandidates.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a candidate to update.");
                return;
            }

            var row = dgvCandidates.SelectedRows[0];
            string candidateId = row.Cells["CandidateID"].Value.ToString();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string position = txtPosition.Text.Trim();

            try
            {
                DataAccess.ExecuteProcedureNonQuery("sp_UpdateCandidate",
                   new MySqlParameter("@in_id", candidateId),
                   new MySqlParameter("@in_fn", firstName),
                   new MySqlParameter("@in_ln", lastName),
                   new MySqlParameter("@in_position", position)
                );
                LoadCandidates();
                ClearFields();
                MessageBox.Show("Candidate updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating candidate: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCandidates.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a candidate to delete.");
                return;
            }

            var row = dgvCandidates.SelectedRows[0];
            string candidateID = row.Cells["CandidateID"].Value.ToString();

            try
            {
                DataAccess.ExecuteProcedureNonQuery("sp_DeleteCandidate",
                    new MySqlParameter("@CandidateID", candidateID)
                );
                LoadCandidates();
                ClearFields();
                MessageBox.Show("Candidate deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting candidate: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPosition.Text = "";
        }
    }
}
