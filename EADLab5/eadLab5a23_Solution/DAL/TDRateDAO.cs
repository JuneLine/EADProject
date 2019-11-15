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
    public class TDRateDAO
    {
        public List<TDRate> SelectCurrent()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            String sqlstmt = "SELECT tdTerm, tdRate From TDRate " +
                             "where GETDATE() between tdEffFrom and tdEffTo";

            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<TDRate> rteList = new List<TDRate>();

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 0)
            {
                rteList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int term = Convert.ToInt32(row["tdTerm"]);
                    float rate = Convert.ToSingle(row["tdRate"]);
                    TDRate objRate = new TDRate(term, rate);
                    rteList.Add(objRate);
                }
            }
            return rteList;
        }
    }
}