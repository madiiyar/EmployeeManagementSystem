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
    public partial class AddEmployee : UserControl
    {

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\amadi\\Documents\\employee.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        public AddEmployee()
        {
            InitializeComponent();

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
            if (employeeIdField.Text == "" ||
               fullNameField.Text == "" ||
               genderField.Text == "" ||
               phoneNumberField.Text == "" ||
               postionField.Text == "" ||
               statusField.Text == "" ||
               importPicture.Image == null
               )
            {
                MessageBox.Show("PLease fill all blank fields", "Errror Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        connection.Open();
                        string checkEmployeeId = "SELECT * FROM employees WHERE employee_id = @emID";

                        using (SqlCommand cmd = new SqlCommand(checkEmployeeId, connection))
                        {
                            int count = (int)cmd.ExecuteScalar();
                            if (count >= 1)
                            {
                                MessageBox.Show(employeeIdField.Text.Trim() + " is already taken", "Errror Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INT0 employees (employee_id, full_name, gender, contact_number, position, image, salary, insert_date, status VALUES (@employeeID, @fullname, @gender, @contactNum, @position, @image, @salary, @insertDate, @status))";

                                using (SqlCommand command = new SqlCommand(insertData, connection))
                                {
                                    command.Parameters.AddWithValue("@employeeID", employeeIdField.Text.Trim());
                                    command.Parameters.AddWithValue("@employeeID", fullNameField.Text.Trim());

                                    // mynany bitiru kerek, youtubeta 1:37:13 
                                    // sharshadym
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error: " + ex, "Errror Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            };
        }
    }
}
