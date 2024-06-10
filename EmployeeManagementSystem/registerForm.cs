using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;    

namespace EmployeeManagementSystem
{
    public partial class registerForm : Form
    {

        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\amadi\Documents\employee.mdf;Integrated Security=True;Connect Timeout=30");
        public registerForm()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            loginForm form = new loginForm();
            form.Show();
            this.Hide();
        }

        private void loginForm_load(object sender, EventArgs e)
        {

        }

        private void showpassCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (showpassCheck.Checked)
            {
                passwordField.UseSystemPasswordChar = false;
            }

            if (!showpassCheck.Checked)
            {
                passwordField.UseSystemPasswordChar = true;
            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if (usernameField.Text == "" || passwordField.Text == "")
            {
                MessageBox.Show("Fill all blank");
            }
            else
            {
                if(connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();
                        string selectUsername = "SELECT count(id) from users where username = @user";

                        using (SqlCommand checkuser = new SqlCommand(selectUsername, connect))
                        {

                            checkuser.Parameters.AddWithValue("user", usernameField.Text.Trim());
                            int count = (int)checkuser.ExecuteScalar();

                            if (count >= 1)
                            {
                                MessageBox.Show("This username already existed");
                            }
                            else
                            {
                                DateTime today = DateTime.Today;

                                string insertData = "INSERT INTO users (username, password, date_register) VALUES (@username, @password, @dateReg)";

                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@username", usernameField.Text.Trim());
                                    cmd.Parameters.AddWithValue("@password", passwordField.Text.Trim());
                                    cmd.Parameters.AddWithValue("@dateReg", today);

                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Registered succesfully", "Information Message", MessageBoxButtons.OK);

                                    loginForm form1 = new loginForm();
                                    form1.Show();
                                    this.Hide();
                                }
                            }
                        }


                           
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error");
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }

        }
    }
}
