using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementSystem
{
     class SalaryData
    {
        
        public string EmployeeID { set; get; }
        public string Name { set; get; }
        public string Gender { set; get; }
        public string Contact { set; get; }

        public string Position { set; get; }
        public int Salary { set; get; }




        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\amadi\Documents\employee.mdf;Integrated Security=True;Connect Timeout=30");

        public List<SalaryData> salaryEmployeeListData()
        {
            List<SalaryData> listdata = new List<SalaryData>();

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
                            SalaryData salaryData = new SalaryData();
                            salaryData.EmployeeID = reader["employee_id"].ToString();
                            salaryData.Name = reader["full_name"].ToString();
                            salaryData.Gender = reader["gender"].ToString();
                            salaryData.Contact = reader["contact_number"].ToString();
                            salaryData.Position = reader["position"].ToString();
                            salaryData.Salary = (int)reader["salary"];


                            listdata.Add(salaryData);
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
