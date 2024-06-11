using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class AddEmployee : UserControl
    {
        private SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\amadi\Documents\employee.mdf;Integrated Security=True;Connect Timeout=30");

        public AddEmployee()
        {
            InitializeComponent();
            displayEmployeeData();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            displayEmployeeData();
        }

        public void displayEmployeeData()
        {
            EmployeeData employeeData = new EmployeeData();
            List<EmployeeData> listData = employeeData.employeeListData();
            dataGridView1.DataSource = listData;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(employeeIdField.Text) ||
                string.IsNullOrWhiteSpace(fullNameField.Text) ||
                string.IsNullOrWhiteSpace(genderField.Text) ||
                string.IsNullOrWhiteSpace(phoneNumberField.Text) ||
                string.IsNullOrWhiteSpace(postionField.Text) ||
                string.IsNullOrWhiteSpace(statusField.Text) ||
                importPicture.Image == null)
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (connection.State == ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                    string checkEmployeeId = "SELECT COUNT(*) FROM employees WHERE employee_id = @emID AND delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(checkEmployeeId, connection))
                    {
                        cmd.Parameters.AddWithValue("@emID", employeeIdField.Text.Trim());
                        int count = (int)cmd.ExecuteScalar();
                        if (count >= 1)
                        {
                            MessageBox.Show(employeeIdField.Text.Trim() + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DateTime today = DateTime.Today;
                            string insertData = "INSERT INTO employees (employee_id, full_name, gender, contact_number, position, image, salary, insert_date, status) VALUES (@employeeID, @fullname, @gender, @contactNum, @position, @image, @salary, @insertDate, @status)";

                            string path = Path.Combine(@"C:\Users\amadi\Documents\WorldSkills\EmployeeManagementSystem\EmployeeManagementSystem\Directory\", employeeIdField.Text.Trim() + ".jpg");

                            string directoryPath = Path.GetDirectoryName(path);

                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }

                            File.Copy(importPicture.ImageLocation, path, true);

                            using (SqlCommand command = new SqlCommand(insertData, connection))
                            {
                                command.Parameters.AddWithValue("@employeeID", employeeIdField.Text.Trim());
                                command.Parameters.AddWithValue("@fullname", fullNameField.Text.Trim());
                                command.Parameters.AddWithValue("@gender", genderField.Text.Trim());
                                command.Parameters.AddWithValue("@contactNum", phoneNumberField.Text.Trim());
                                command.Parameters.AddWithValue("@position", postionField.Text.Trim());
                                command.Parameters.AddWithValue("@image", path);
                                command.Parameters.AddWithValue("@salary", 0);
                                command.Parameters.AddWithValue("@insertDate", today);
                                command.Parameters.AddWithValue("@status", statusField.Text.Trim());

                                command.ExecuteNonQuery();

                                displayEmployeeData();

                                MessageBox.Show("Added successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                clearFields();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    importPicture.ImageLocation = dialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                employeeIdField.Text = row.Cells[1].Value.ToString();
                fullNameField.Text = row.Cells[2].Value.ToString();
                genderField.Text = row.Cells[3].Value.ToString();
                phoneNumberField.Text = row.Cells[4].Value.ToString();
                postionField.Text = row.Cells[5].Value.ToString();

                string imagePath = row.Cells[6].Value.ToString();

                if (imagePath != null)
                {
                    importPicture.Image = Image.FromFile(imagePath);

                }
                else
                {
                    importPicture.Image = null;
                }

                
                statusField.Text = row.Cells[8].Value.ToString();
            }
        }


        public void clearFields()
        {
            employeeIdField.Text = "";
            fullNameField.Text = "";
            genderField.SelectedIndex = -1;
            phoneNumberField.Text = "";
            postionField.SelectedIndex = -1;
            statusField.SelectedIndex = -1;
            importPicture.Image = null;

        }
        private void updateBtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(employeeIdField.Text) ||
                string.IsNullOrWhiteSpace(fullNameField.Text) ||
                string.IsNullOrWhiteSpace(genderField.Text) ||
                string.IsNullOrWhiteSpace(phoneNumberField.Text) ||
                string.IsNullOrWhiteSpace(postionField.Text) ||
                string.IsNullOrWhiteSpace(statusField.Text) ||
                importPicture.Image == null)
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else

            {
                DialogResult check = MessageBox.Show("Are you sure you want to UPDATE " + "Employee ID: " + employeeIdField.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        DateTime date = DateTime.Today;
                        string updateData = "UPDATE employees SET full_name = @fullName" +
                            ", gender = @gender, contact_number = @contactNum" +
                            ", position = @position, update_date = @updateDate, status = @status " +
                            "WHERE employee_id = @employeeID";

                        using (SqlCommand cmd = new SqlCommand(updateData, connection))
                        {
                            cmd.Parameters.AddWithValue("@fullname", fullNameField.Text.Trim());
                            cmd.Parameters.AddWithValue("@gender", genderField.Text.Trim());
                            cmd.Parameters.AddWithValue("@contactNum", phoneNumberField.Text.Trim());
                            cmd.Parameters.AddWithValue("@position", postionField.Text.Trim());
                            cmd.Parameters.AddWithValue("@updateDate", date);
                            cmd.Parameters.AddWithValue("@status", statusField.Text.Trim());
                            cmd.Parameters.AddWithValue("@employeeID", employeeIdField.Text.Trim());

                            cmd.ExecuteNonQuery();

                            displayEmployeeData();

                            MessageBox.Show("Updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            clearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Cancelled", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


               
            }

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(employeeIdField.Text) ||
                string.IsNullOrWhiteSpace(fullNameField.Text) ||
                string.IsNullOrWhiteSpace(genderField.Text) ||
                string.IsNullOrWhiteSpace(phoneNumberField.Text) ||
                string.IsNullOrWhiteSpace(postionField.Text) ||
                string.IsNullOrWhiteSpace(statusField.Text) ||
                importPicture.Image == null)
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else

            {
                DialogResult check = MessageBox.Show("Are you sure you want to DELETE " + "Employee ID: " + employeeIdField.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        DateTime date = DateTime.Today;
                        string updateData = "UPDATE employees SET  delete_date = @deleteDate WHERE employee_id = @employeeID";

                        using (SqlCommand cmd = new SqlCommand(updateData, connection))
                        {
                            
                            cmd.Parameters.AddWithValue("@deleteDate", date);
                            cmd.Parameters.AddWithValue("@employeeID", employeeIdField.Text.Trim());

                            cmd.ExecuteNonQuery();

                            displayEmployeeData();

                            MessageBox.Show("Updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            clearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Cancelled", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }



            }
        }
    }
}

