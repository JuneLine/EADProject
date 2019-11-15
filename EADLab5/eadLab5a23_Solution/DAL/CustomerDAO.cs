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
    }
}