using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_Final
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(
        @"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=C:\Users\hp\OneDrive\Documents\GitHub\Event-Final\Event Final\Database1.mdf;
        Integrated Security=True");
        private void pictureBox2_Click(object sender, EventArgs e)
        {

                if (txtFullName.Text == "" ||
                    txtEmail.Text == "" ||
                    txtPassword.Text == "" ||
                    txtConfirmPassword.Text == "")
                {
                    MessageBox.Show("Please fill all fields");
                    return;
                }
               if (txtFullName.Text.Any(char.IsDigit))
               {
                    MessageBox.Show("Name must contain letters only");
                    return;
               }

               if (txtFullName.Text.Trim().Split(' ').Length < 2)
               {
                    MessageBox.Show("Please enter your full name");
                    return;
               }
                 string[] words = txtFullName.Text.Trim().Split(' ');
                  foreach (string word in words)
                  {
                       if (word.Length > 0 && !char.IsUpper(word[0]))
                          {
                        MessageBox.Show("Each word must start with a capital letter\nExample: H***** R*****");
                        return;
                          }
                }
                if (txtPassword.Text.Length < 7)
                {
                    MessageBox.Show("Password must be at least 7 characters");
                    return;
                }

                if (!txtPassword.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Password must contain numbers only");
                    return;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match");
                    return;
                }

                if (!txtEmail.Text.Contains("@gmail.com"))
                {
                    MessageBox.Show("Email must be gmail.com");
                    return;
                }

            try {

                con.Open();
                Users user = new Users(
                  txtFullName.Text,
                  txtEmail.Text,
                  txtPassword.Text
                  );

                string query =
                "INSERT INTO Users (FullName, Email, Password) VALUES (@FullName,@Email,@Password)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Register Completed Successfully ✔️");

                Login login = new Login();

                login.Show();

                this.Close();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { 
                con.Close();
            }
           
        }

        private void Register_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login login = new Login();

            login.Show();

            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

        
