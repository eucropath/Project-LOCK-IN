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

namespace IT_13_project
{
    public partial class Form1 : Form
    {

        private string connStr = "Server=Localhost; Database=db;Uid=root;pwd=;";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM users WHERE username=@username AND password=@password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    label3.Text = "Login successful!";
                    // You can open another form here
                    // new Dashboard().Show();
                    // this.Hide();
                }
                else
                {
                    label3.Text = "Invalid username or password!";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (username == "" || password == "")
            {
                label3.Text = "Please enter username and password.";
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                // Check if user exists
                string checkUser = "SELECT COUNT(*) FROM users WHERE username=@username";
                MySqlCommand cmd = new MySqlCommand(checkUser, conn);
                cmd.Parameters.AddWithValue("@username", username);

                int exists = Convert.ToInt32(cmd.ExecuteScalar());

                if (exists > 0)
                {
                    label3.Text = "Username already taken!";
                    return;
                }

                // Insert new user
                string insertUser = "INSERT INTO users (username, password) VALUES (@username, @password)";
                cmd = new MySqlCommand(insertUser, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); // TODO: Hash password in real app

                cmd.ExecuteNonQuery();
                label3.Text = "Sign up successful!";
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
