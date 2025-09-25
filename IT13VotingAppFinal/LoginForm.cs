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
            this.Load += LoginForm_Load;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("You need to fill up the box first.");
                return;
            }

            try
            {
                var dt = DataAccess.ExecuteProcedureToDataTable("sp_GetUserByUsername",
                    new MySqlParameter("@in_username", username));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("User not found.");
                    return;
                }

                var row = dt.Rows[0];
                string role = row["Role"].ToString();

                this.Hide();

                if (role == "Admin")
                {
                    var adminForm = new AdminDashboardForm();
                    adminForm.ShowDialog();
                }
                else
                {
                    var voterForm = new VoterDashboardcs();
                    voterForm.ShowDialog();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message);
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtFields_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            txtUsername.KeyDown += txtFields_KeyDown;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.KeyDown += txtFields_KeyDown;

        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VoterRegistration registerForm = new VoterRegistration();
            registerForm.Show();
            this.Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Text = "Login";
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(900, 600); // same fixed size as voter registration

            // === Title ===
            label1.Text = "Login";
            label1.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            label1.ForeColor = ColorTranslator.FromHtml("#102840");
            label1.BackColor = Color.Transparent;
            label1.AutoSize = true;
            label1.Parent = pictureBox1;

            // === Labels ===
            StyleLabel(label2, "Enter Username:", 0, 0);
            label2.ForeColor = Color.Black;

            StyleLabel(label3, "Enter Password:", 0, 0);
            label3.ForeColor = Color.Black;

            // === Textboxes ===
            StyleTextBox(txtUsername, 0, 0);
            StyleTextBox(txtPassword, 0, 0);
            txtPassword.PasswordChar = '*';

            // === Buttons ===
            StyleButton(btnLogin, "Enter", 0, 0, ColorTranslator.FromHtml("#0A2E5C"), Color.White);
            StyleButton(btnExit, "Exit", 0, 0, Color.White, Color.FromArgb(231, 76, 60));
            StyleButton(Register, "Register", 0, 0, Color.White, ColorTranslator.FromHtml("#0D47A1"));

            // === Background ===
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.SendToBack();

            // Center everything
            CenterControls();

            // Recenter on resize
            this.Resize += (s, ev) => CenterControls();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            VoterRegistration registerForm = new VoterRegistration();
            registerForm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void StyleButton(Button btn, string text, int x, int y, Color foreColor, Color backColor)
        {
            btn.Text = text;
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btn.ForeColor = foreColor;
            btn.BackColor = backColor;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Size = new Size(100, 40);
            btn.Location = new Point(x, y);
            btn.Cursor = Cursors.Hand;
        }
        private void StyleTextBox(TextBox txt, int x, int y)
        {
            txt.Size = new Size(200, 30);
            txt.Font = new Font("Segoe UI", 12);
            txt.Location = new Point(x, y);
        }
        private void StyleLabel(Label lbl, string text, int x, int y)
        {
            lbl.Text = text;
            lbl.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            lbl.ForeColor = ColorTranslator.FromHtml("#0A2E5C");
            lbl.BackColor = Color.Transparent;
            lbl.AutoSize = true;
            lbl.Location = new Point(x, y);

        }

        private void CenterControls()
        {
            int centerX = this.ClientSize.Width / 2;

            // Title
            label1.Left = centerX - (label1.Width / 2);
            label1.Top = 60;

            // Username
            label2.Left = centerX - 200;
            label2.Top = 160;
            txtUsername.Left = centerX;
            txtUsername.Top = 155;

            // Password
            label3.Left = centerX - 200;
            label3.Top = 220;
            txtPassword.Left = centerX;
            txtPassword.Top = 215;

            // Buttons
            int buttonsTop = 280;
            int totalWidth = (btnLogin.Width + Register.Width + btnExit.Width) + 40; // with spacing
            int buttonsLeft = centerX - (totalWidth / 2);

            btnLogin.Left = buttonsLeft;
            btnLogin.Top = buttonsTop;

            Register.Left = btnLogin.Right + 20;
            Register.Top = buttonsTop;

            btnExit.Left = Register.Right + 20;
            btnExit.Top = buttonsTop;
        }
    }
    }