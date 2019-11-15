using EADLab4.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EADLab4.DAL
{
    public class TDMasterDAL
    {
        public static bool Insert(TDMaster td)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();

                string sqlStmt = @"INSERT INTO TDMaster 
                    (Account, CustId, Principal, Term, EffFrom, Maturity, InterestAmt, MatureAmt, TDRate, RenewMode) 
                    VALUES 
                    (@Account, @CustId, @Principal, @Term, @EffFrom, @Maturity, @InterestAmt, @MatureAmt, @TDRate, @RenewMode)";
                SqlCommand cmd = new SqlCommand(sqlStmt, connection);
                cmd.Parameters.AddWithValue("@Account", td.Account);
                cmd.Parameters.AddWithValue("@CustId", td.CustId);
                cmd.Parameters.AddWithValue("@Principal", td.Principal);
                cmd.Parameters.AddWithValue("@Term", td.Term);
                cmd.Parameters.AddWithValue("@EffFrom", td.EffFrom);
                cmd.Parameters.AddWithValue("@Maturity", td.Maturity);
                cmd.Parameters.AddWithValue("@InterestAmt", td.InterestAmt);
                cmd.Parameters.AddWithValue("@MatureAmt", td.MatureAmt);
                cmd.Parameters.AddWithValue("@TDRate", td.TDRate);
                cmd.Parameters.AddWithValue("@RenewMode", td.RenewMode);

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