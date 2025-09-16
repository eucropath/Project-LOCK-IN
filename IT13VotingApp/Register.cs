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
using System.Net.Mail;
using System.Net;


namespace IT13VotingApp
{
    public partial class Register : Form
    {
        string connectionString = "server=localhost;database=VotingAppDB;uid=root;pwd=;";
        public Register()
        {
            InitializeComponent();
        }

        private void LoginLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login lf = new Login();
            lf.Show();
            this.Hide();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (FullnameTxt.Text.Length > 0 && EmailTxt.Text.Length > 0)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        // Prevent duplicate emails
                        string checkQuery = "SELECT COUNT(*) FROM Voter WHERE Email=@Email";
                        MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                        checkCmd.Parameters.AddWithValue("@Email", EmailTxt.Text);

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("This email is already registered.");
                            return;
                        }
                        string insertQuery = "INSERT INTO Voter(Fullnames, Email) VALUES (@Fullnames, @Email)";
                        MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                        cmd.Parameters.AddWithValue("@Fullnames", FullnameTxt.Text);
                        cmd.Parameters.AddWithValue("@Email", EmailTxt.Text);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Registration successful!");
                            Login lf = new Login();
                            lf.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Registration failed.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }


            else
                MessageBox.Show("Fullname and Email are required.");
        }
        
    private void SendEmail(string fullname, string recipientEmail)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("yourgmail@gmail.com"); // sender
                mail.To.Add(recipientEmail);
                mail.Subject = "Voting App Registration";
                mail.Body = $"Hello {fullname},\n\nYou have successfully registered for the Voting App.\n\nThank you!";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("yourgmail@gmail.com", "your-app-password");
                smtp.EnableSsl = true;

                smtp.Send(mail);

                MessageBox.Show("Confirmation email sent to " + recipientEmail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Email error: " + ex.Message);
            }
        }
    }
}


