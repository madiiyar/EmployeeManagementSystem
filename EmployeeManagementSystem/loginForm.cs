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
    public partial class loginForm : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\amadi\Documents\employee.mdf;Integrated Security=True;Connect Timeout=30");

        public loginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassCheck.Checked)
            {
                passwordField.UseSystemPasswordChar = false;
            }

            if (!showPassCheck.Checked)
            {
                passwordField.UseSystemPasswordChar = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            registerForm form = new registerForm();
            form.Show();
            this.Hide();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (usernameField.Text == "" || passwordField.Text == "")
            {
                MessageBox.Show("Fill all blank");
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();

                        string selectData = "select * from users where username = @username and password = @password";

                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@username", usernameField.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", passwordField.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);


                            if (dt.Rows.Count >= 1)
                            {
                                MessageBox.Show("Login Succesfully", "Information Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
                                mainPage mainPage = new mainPage();
                                mainPage.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                    catch (Exception ex)
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
