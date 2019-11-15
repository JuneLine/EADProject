using eadLab5a23.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace eadLab5a23.DAL
{
    public class TDMasterDAO
    {
        public int Insert(TDMaster td)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO TDMaster (account, custId, principal, term, " +
                                    "effectFrom, maturity,interestAmt,matureAmt,tdRate,renewMode)" +
                             "VALUES (@paraAccount,@paraCustId,@paraPrincipal,@paraTerm," +
                                    "GETDATE(),@paraMaturity,@paraInterest,@paraMatureAmt,@paraTdRate,@paraRenewMode)";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraAccount", td.Account);
            sqlCmd.Parameters.AddWithValue("@paraCustId", td.CustId);
            sqlCmd.Parameters.AddWithValue("@paraPrincipal", td.Principal);
            sqlCmd.Parameters.AddWithValue("@paraTerm", td.Term);
            sqlCmd.Parameters.AddWithValue("@paraMaturity", td.MaturityDate);
            sqlCmd.Parameters.AddWithValue("@paraInterest", td.Interest);
            sqlCmd.Parameters.AddWithValue("@paraMatureAmt", td.MaturedAmt);
            sqlCmd.Parameters.AddWithValue("@paraTdRate", td.IntRate);
            sqlCmd.Parameters.AddWithValue("@paraRenewMode", td.RenewMode);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
    }
}