using eadLab5.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace eadLab5.DAL
{
    public class EmployeeDAO
    {
        public List<Employee> SelectAll()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from Employee";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Employee> empList = new List<Employee>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i=0; i<rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string nric = row["nric"].ToString();
                string name = row["name"].ToString();
                DateTime dob = Convert.ToDateTime(row["birthdate"].ToString());
                string dept = row["department"].ToString();
                string payStr = row["mthlySalary"].ToString();
                double pay = Convert.ToDouble(payStr);
                Employee obj = new Employee(nric, name, dob, dept, pay);
                empList.Add(obj);
            }

            return empList;
        }
        public Employee SelectById(string nric)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from Employee where nric = @paraNric";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraNric", nric);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            Employee emp = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string name = row["name"].ToString();
                DateTime dob = Convert.ToDateTime(row["birthdate"].ToString());
                string dept = row["department"].ToString();
                string payStr = row["mthlySalary"].ToString();
                double pay = Convert.ToDouble(payStr);
                emp = new Employee(nric, name, dob, dept, pay);
            }
            else
            {
                emp = null;
            }

            return emp;
        }

        public int Insert(Employee emp)
        {
            // Execute NonQuery return an integer value
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Instantiate SqlCommand instance to add record 
            //          with INSERT statement
            string sqlStmt = "INSERT INTO Employee (nric, name, birthdate, department, mthlySalary) " +
                "VALUES (@paraNric,@paraName, @paraBirthdate, @paraDept, @paraMthlySalary)";
            sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraNric", emp.NRIC);
            sqlCmd.Parameters.AddWithValue("@paraName", emp.Name);
            sqlCmd.Parameters.AddWithValue("@paraBirthdate", emp.Birthdate.ToShortDateString());
            sqlCmd.Parameters.AddWithValue("@paraDept", emp.Dept);
            sqlCmd.Parameters.AddWithValue("@paraMthlySalary", emp.MthlyWage);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }
        public int Update(Employee emp)
        {
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Instantiate SqlCommand instance to add record 
            //          with INSERT statement
            string sqlStmt = "UPDATE Employee SET name = @paraName, birthdate = @paraBirthdate, " +
                "department = @paraDept, mthlySalary = @paraMthlySalary where nric = @paraNric ";

            sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraNric", emp.NRIC);
            sqlCmd.Parameters.AddWithValue("@paraName", emp.Name);
            sqlCmd.Parameters.AddWithValue("@paraBirthdate", emp.Birthdate.ToShortDateString());
            sqlCmd.Parameters.AddWithValue("@paraDept", emp.Dept);
            sqlCmd.Parameters.AddWithValue("@paraMthlySalary", emp.MthlyWage);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }
    }
}