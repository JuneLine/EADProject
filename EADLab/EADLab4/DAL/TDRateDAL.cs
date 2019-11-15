using EADLab4.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EADLab4.DAL
{
    public class TDRateDAL
    {
        public static TDRate Read(SqlDataReader dr)
        {
            TDRate rate = new TDRate();

            rate.Term = Convert.ToInt32(dr["Term"].ToString());
            rate.Rate = Convert.ToDouble(dr["Rate"].ToString());

            return rate;
        }

        public static List<TDRate> SelectCurrent()
        {
            List<TDRate> rateList = new List<TDRate>();

            string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();

                string sqlStmt = "Select * from TDRate where GETDATE() between EffFrom and EffTo order by Term";
                SqlCommand cmd = new SqlCommand(sqlStmt, connection);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TDRate rate = Read(dr);
                    rateList.Add(rate);
                }
            }
            finally
            {
                connection.Close();
            }

            return rateList;
        }
    }
}