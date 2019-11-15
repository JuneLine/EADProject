using EADLab4.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EADLab4.DAL
{
    public class CustomerDAL
    {
        public static Customer Read(SqlDataReader dr)
        {
            Customer cust = new Customer();

            cust.Id = dr["Id"].ToString();
            cust.Name = dr["Name"].ToString();
            cust.Address = dr["Address"].ToString();
            cust.Postal = dr["Postal"].ToString();
            cust.HomePhone = dr["HomePhone"].ToString();
            cust.Mobile = dr["Mobile"].ToString();

            return cust;
        }

        public static Customer Select(string id)
        {
            Customer cust = null;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();

                string sqlStmt = "Select * from Customer where Id = @Id";
                SqlCommand cmd = new SqlCommand(sqlStmt, connection);
                cmd.Parameters.AddWithValue("Id", id);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cust = Read(dr);
                }
            }
            finally
            {
                connection.Close();
            }

            return cust;
        }
    }
}