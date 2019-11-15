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

        private static TDMaster Read(SqlDataReader rd)
        {
            string custId = rd["custId"].ToString();
            string acc = rd["account"].ToString();
            double principal = Convert.ToDouble(rd["principal"]);
            int term = Convert.ToInt32(rd["term"]);
            DateTime effFrom = Convert.ToDateTime(rd["effectFrom"]);
            DateTime mDate = Convert.ToDateTime(rd["maturity"]);
            double interest = Convert.ToDouble(rd["interestAmt"]);
            double mAmt = Convert.ToDouble(rd["matureAmt"]);
            double rate = Convert.ToDouble(rd["tdRate"]);
            string mode = rd["renewMode"].ToString();

            TDMaster td = new TDMaster
            {
                CustId = custId,
                Account = acc,
                Principal = principal,
                Term = term,
                EffectiveFrom = effFrom,
                MaturityDate = mDate,
                Interest = interest,
                MaturedAmt = mAmt,
                IntRate = rate,
                RenewMode = mode
            };
            return td;
        }

        public static List<TDMaster> SelectByCustId(string custId)
        {
            List<TDMaster> tdList = new List<TDMaster>();

            string connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(connStr);

            string sqlstmt = @"SELECT * From TDMaster where custId = @paraId and maturity >= GETDATE()";

            SqlCommand cmd = new SqlCommand(sqlstmt, myConn);
            cmd.Parameters.AddWithValue("@paraId", custId);

            myConn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TDMaster td = Read(dr);
                tdList.Add(td);
            }
            myConn.Close();

            return tdList;
        }
        public static TDMaster SelectByAccount(string acc)
        {
            TDMaster td = null;

            string connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(connStr);

            string sqlstmt = @"SELECT * From TDMaster where account = @paraAcc and maturity >= GETDATE()";

            SqlCommand cmd = new SqlCommand(sqlstmt, myConn);
            cmd.Parameters.AddWithValue("@paraAcc", acc);

            myConn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                td = Read(dr);
            }
            myConn.Close();

            return td;
        }

        public static int UpdateRenewMode(string acc, string renewMode)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(connStr);

            string sqlStmt = @"UPDATE TDMaster SET renewMode = @paraRenewMode where account =  @paraAcNum";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);
            sqlCmd.Parameters.AddWithValue("@paraRenewMode", renewMode);
            sqlCmd.Parameters.AddWithValue("@paraAcNum", acc);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }
    }
}