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
using System.Security.Cryptography;

namespace IT13VotingAppFinal
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string pass = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Enter username and password.");
                return;
            }

            try
            {
                var dt = DataAccess.ExecuteProcedureToDataTable("sp_GetUserByUsername",
                    new MySqlParameter("@in_username", username));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid credentials.");
                    return;
                }

                var row = dt.Rows[0];
                string storedPassword = row["Password"].ToString();

                if (pass == storedPassword)
                {
                    // login success
                    this.Hide();
                    var dash = new AdminDashboardForm();
                    dash.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid credentials.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message);
            }
        }
    }
}
