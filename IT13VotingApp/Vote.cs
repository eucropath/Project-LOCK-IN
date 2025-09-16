using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IT13VotingApp
{
    public partial class Vote : Form
    {
        string connectionString = "server=localhost;database=VotingAppDB;uid=root;pwd=;";

        private int VoterID;

        public Vote(int loggedInVoterID)
        {
            InitializeComponent();
            VoterID = loggedInVoterID;
        }

        private void VoteBtn_Click(object sender, EventArgs e)
        {
            if (PartyComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a party for voting.");
                return;
            }
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // ✅ Prevent duplicate voting
                    string checkQuery = "SELECT COUNT(*) FROM Results WHERE UserID=@UserID";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@UserID", VoterID);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("You have already voted!");
                        return;
                    }
                    string insertQuery = "INSERT INTO Results (VoterID, PartyID) VALUES (@VoterID, @PartyID)";
                    MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@VoterID", VoterID);
                    cmd.Parameters.AddWithValue("@PartyID", PartyComboBox.SelectedValue); // assumes ComboBox is data-bound

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Vote successfully recorded!");
                        this.Close(); // or redirect to dashboard
                    }
                    else
                    {
                        MessageBox.Show("Vote failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to log out?",
                                                       "Logout",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    Login loginForm = new Login();
                    loginForm.Show();
                    this.Hide(); // or this.Close();
                }
            }
        }
    }
}
