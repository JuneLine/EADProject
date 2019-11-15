using eadLab5a23.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eadLab5a23.BLL
{
    public class TDMaster
    {
        public string Account { get; set; }
        public string CustId { get; set; }
        public double Principal { get; set; }
        public int Term { get; set; }
        public DateTime MaturityDate { get; set; }
        public double Interest { get; set; }
        public double MaturedAmt { get; set; }
        public double IntRate { get; set; }
        public string RenewMode { get; set; }

        public TDMaster(string acc, string id, double principal, int term, double interest, DateTime mDate, double mAmt, double rate, string mode)
        {
            Account = acc;
            CustId = id;
            Principal = principal;
            Term = term;
            Interest = interest;
            MaturityDate = mDate;
            MaturedAmt = mAmt;
            IntRate = rate;
            RenewMode = mode;
        }

        public int AddTermDeposit()
        {
            TDMasterDAO dao = new TDMasterDAO();
            return (dao.Insert(this));
        }
    }
}