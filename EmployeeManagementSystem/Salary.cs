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
    public partial class Salary : UserControl
    {

        private SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\amadi\Documents\employee.mdf;Integrated Security=True;Connect Timeout=30");

        public Salary()
        {
            InitializeComponent();

            displayEmployee();

            disableFields();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            displayEmployee();

            disableFields();
        }


        public void disableFields()
        {
            employeeIDField.Enabled = false;
            fullNameField.Enabled = false;
            positionField.Enabled = false;

        }

        public void displayEmployee()
        {
            SalaryData ed = new SalaryData();
            List<SalaryData> listdata = ed.salaryEmployeeListData();

            dataGridView1.DataSource = listdata;
        }
        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (employeeIDField.Text == "" || fullNameField.Text == "" || positionField.Text == "" || salaryField.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to UPDATE Employee ID: " + salaryField.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (check == DialogResult.Yes)
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        try
                        {
                            DateTime today = DateTime.Today;
                            connection.Open();

                            string updateData = "UPDATE employees SET salary = @salary, update_date = @updateData WHERE employee_id = @employeeID";

                            using (SqlCommand cmd = new SqlCommand(updateData, connection))
                            {
                                cmd.Parameters.AddWithValue("@salary", salaryField.Text.Trim());
                                cmd.Parameters.AddWithValue("@updateData", today);
                                cmd.Parameters.AddWithValue("@employeeID", employeeIDField.Text.Trim());

                                cmd.ExecuteNonQuery();

                                displayEmployee();

                                MessageBox.Show("Updated successfully!", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                clearFields();
                            }


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Cancelled", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        public void clearFields()
        {
            employeeIDField.Text = "";
            fullNameField.Text = "";
            positionField.Text = "";
            salaryField.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                employeeIDField.Text = row.Cells[0].Value.ToString();
                fullNameField.Text = row.Cells[1].Value.ToString();
                positionField.Text = row.Cells[4].Value.ToString();
                salaryField.Text = row.Cells[5].Value.ToString();
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}
