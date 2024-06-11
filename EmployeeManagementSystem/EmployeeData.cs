using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementSystem
{


     class EmployeeData
    {

        public int ID { set; get; }
        public string EmployeeID { set; get; }
        public string Name { set; get; }

        public string Gender { set; get; }
        public string Contact { set; get; }
        public string Position { set; get; }
        public string Image { set; get; }
        public int Salary { set; get; }
        public string Status { set; get; }




        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\amadi\Documents\employee.mdf;Integrated Security=True;Connect Timeout=30");

        public List<EmployeeData> employeeListData()
        {
            List<EmployeeData> listdata = new List<EmployeeData>();

            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();

                    string selectData = "SELECT * FROM employees WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            EmployeeData employeedata = new EmployeeData();
                            employeedata.ID = (int)reader["id"];
                            employeedata.EmployeeID = reader["employee_id"].ToString();
                            employeedata.Name = reader["full_name"].ToString();
                            employeedata.Gender = reader["gender"].ToString();
                            employeedata.Contact = reader["contact_number"].ToString();
                            employeedata.Position = reader["position"].ToString();
                            employeedata.Image = reader["image"].ToString();
                            employeedata.Salary = (int)reader["salary"];
                            employeedata.Status = reader["status"].ToString();

                            listdata.Add(employeedata);
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    connection.Close();
                }
            }

            return listdata;
        }

        public List<EmployeeData> salaryEmployeeListData()
        {
            List<EmployeeData> listdata = new List<EmployeeData>();

            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();

                    string selectData = "SELECT * FROM employees WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            EmployeeData employeedata = new EmployeeData();
                            employeedata.EmployeeID = reader["employee_id"].ToString();
                            employeedata.Name = reader["full_name"].ToString();
                            employeedata.Position = reader["position"].ToString();
                            employeedata.Salary = (int)reader["salary"];


                            listdata.Add(employeedata);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    connection.Close();
                }
            }

            return listdata;
        }
    }
}
