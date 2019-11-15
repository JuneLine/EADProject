using eadLab5.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace eadLab5.DAL2
{
    public class EmployeeDAO
    {
        public Employee Read(SqlDataReader dr)
        {
            string nric = dr["nric"].ToString();
            string name = dr["name"].ToString();
            DateTime birthdate = Convert.ToDateTime(dr["birthdate"]);
            string dept = dr["department"].ToString();
            double mthlyWage = Convert.ToInt32(dr["mthlySalary"]);

            Employee emp = new Employee(nric, name, birthdate, dept, mthlyWage);
            return emp;
        }

        public List<Employee> SelectAll()
        {
            List<Employee> empList = new List<Employee>();

            string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();

                string sqlStmt = "Select * from Employee";
                SqlCommand cmd = new SqlCommand(sqlStmt, connection);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Employee emp = Read(dr);
                    empList.Add(emp);
                }
            }
            finally
            {
                connection.Close();
            }

            return empList;
        }

        public Employee SelectById(string nric)
        {
            Employee emp = null;

            string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();

                string sqlStmt = "Select * from Employee where nric = @NRIC";
                SqlCommand cmd = new SqlCommand(sqlStmt, connection);
                cmd.Parameters.AddWithValue("NRIC", nric);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    emp = Read(dr);
                }
            }
            finally
            {
                connection.Close();
            }

            return emp;
        }

        public int Insert(Employee emp)
        {
            int count = 0;

            //Step 1: Create connection to database
            string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Step 2: Open connection
                connection.Open();

                // Step 3: Create SQL command with parameters
                string sqlStmt = @"INSERT INTO Employee (nric, name, birthdate, department, mthlySalary) 
                    VALUES (@NRIC, @Name, @BirthDate, @Dept, @MthlyWage)";
                SqlCommand cmd = new SqlCommand(sqlStmt, connection);
                cmd.Parameters.AddWithValue("@NRIC", emp.NRIC);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@BirthDate", emp.Birthdate);
                cmd.Parameters.AddWithValue("@Dept", emp.Dept);
                cmd.Parameters.AddWithValue("@MthlyWage", emp.MthlyWage);

                // Step 3: Exeute SQL command
                count = cmd.ExecuteNonQuery();
            }
            finally
            {
                // Step 4: Close connection
                connection.Close();
            }

            return count;
        }
    }
}