using eadLab5a23.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace eadLab5a23.DAL
{
    public class CustomerDAO
    {
        private Customer Read(SqlDataReader dr)
        {
            Customer cust = new Customer
            {
                Id = dr["id"].ToString(),
                Name = dr["name"].ToString(),
                Address = dr["address"].ToString() + " Singapore " + dr["postal"].ToString(),
                HomePhone = dr["homePhone"].ToString(),
                Mobile = dr["mobile"].ToString()
            };

            return cust;
        }

        public Customer SelectById(string id)
        {
            Customer cust = null;

            //Step 1: Create connection to database
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Step 2: Open connection
                connection.Open();

                // Step 3: Create SQL command with parameters
                string sqlStmt = "Select * from Customer where id = @Id";
                SqlCommand cmd = new SqlCommand(sqlStmt, connection);
                cmd.Parameters.AddWithValue("Id", id);

                // Step 3: Exeute SQL command
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cust = Read(dr);
                }
            }
            finally
            {
                // Step 4: Close connection
                connection.Close();
            }

            return cust;
        }

        /*
        public Customer SelectById(string custId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from Customer where id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", custId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Customer obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string id = row["id"].ToString();
                string name = row["name"].ToString();
                string address = row["address"].ToString() + " Singapore " + row["postal"].ToString();
                string homePhone = row["homePhone"].ToString();
                string mobile = row["mobile"].ToString();
                obj = new Customer(id, name, address, homePhone, mobile);
            }
            return obj;
        }
        */
    }
}