using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IT13VotingApp
{
    public partial class Login : Form
    {
        string connectionString = "server=localhost;database=VotingAppDB;uid=root;pwd=;";
        public Login()
        {
            InitializeComponent();
        }

        private void RegisterLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register rf = new Register();
            rf.Show();
            this.Hide();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (FullnameTxt.Text.Length > 0 && EmailTxt.Text.Length > 0)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT * FROM Voter WHERE Fullnames=@fullnames AND Email=@email";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@fullnames", FullnameTxt.Text);
                        cmd.Parameters.AddWithValue("@email", EmailTxt.Text);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            int userId = Convert.ToInt32(result);
                            MessageBox.Show("Login successful!");

                            // ✅ Open Vote form and pass UserID
                            Vote voteForm = new Vote(userId);
                            voteForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Fullname or Email.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Fullname and Email are required.");
            }

            }
        }
    }



