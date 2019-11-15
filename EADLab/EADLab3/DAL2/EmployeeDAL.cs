using EADLab3.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EADLab3.DAL2
{
    public class EmployeeDAL
    {
        public static Employee Read(SqlDataReader dr)
        {
            Employee emp = new Employee();

            emp.NRIC = dr["NRIC"].ToString();
            emp.Name = dr["Name"].ToString();
            emp.BirthDate = Convert.ToDateTime(dr["BirthDate"]);
            emp.Dept = dr["Dept"].ToString();
            emp.MthlyWage = Convert.ToInt32(dr["MthlyWage"]);

            return emp;
        }

        public static List<Employee> SelectAll()
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

        public static Employee Select(string nric)
        {
            Employee emp = null;

            string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();

                string sqlStmt = "Select * from Employee where NRIC = @NRIC";
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

        public static bool Insert(Employee emp)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();

                string sqlStmt = @"INSERT INTO Employee (NRIC, Name, BirthDate, Dept, MthlyWage) 
                    VALUES (@NRIC, @Name, @BirthDate, @Dept, @MthlyWage)";
                SqlCommand cmd = new SqlCommand(sqlStmt, connection);
                cmd.Parameters.AddWithValue("@NRIC", emp.NRIC);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@BirthDate", emp.BirthDate);
                cmd.Parameters.AddWithValue("@Dept", emp.Dept);
                cmd.Parameters.AddWithValue("@MthlyWage", emp.MthlyWage);

                int count = cmd.ExecuteNonQuery();
                return count > 0;
            }
            finally
            {
                connection.Close();
                
            }
        }
    }
}