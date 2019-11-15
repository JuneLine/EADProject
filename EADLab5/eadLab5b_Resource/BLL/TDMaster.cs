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
        public DateTime EffectiveFrom { get; set; }
        public DateTime MaturityDate { get; set; }
        public double Interest { get; set; }
        public double MaturedAmt { get; set; }
        public double IntRate { get; set; }
        public string RenewMode { get; set; }

        public TDMaster()
        {
        }

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

        // You will need to amend this method retrieve data from database
        public List<TDMaster> GetTDbyCustId(string custId)
        {
            // Hard-code TDMaster to test the form
            List<TDMaster> tdList = new List<TDMaster>();
            string acc = "1000101";
            double principal = 50000;
            int term = 3;
            double rate = 1.25;
            double interest = principal * rate / 100;
            DateTime mDate = DateTime.Now.AddMonths(term);
            double mAmt = principal + interest;
            string mode = "Not renewing";

            TDMaster td1 = new TDMaster(acc, custId, principal, term, interest, mDate, mAmt, rate, mode)
            {
                EffectiveFrom = DateTime.Now
            };
            tdList.Add(td1);

            acc = "1000102";
            principal = 10000;
            term = 6;
            rate = 1.5;
            interest = principal * rate / 100;
            mDate = DateTime.Now.AddMonths(term);
            mAmt = principal + interest;
            mode = "P+I";

            td1 = new TDMaster(acc, custId, principal, term, interest, mDate, mAmt, rate, mode)
            {
                EffectiveFrom = DateTime.Now
            };

            tdList.Add(td1);

            return tdList;
        }

        // You will need to amend this method retrieve data from database
        public TDMaster GetTDbyAccount(string acc)
        {
            // Hard-code TDMaster to test the form
            string custId = "S1111111D";
            double principal = 50000;
            int term = 3;
            double rate = 1.5;
            double interest = principal * rate / 100;
            DateTime mDate = DateTime.Now.AddMonths(term);
            double mAmt = principal + interest;
            string mode = "Not renewing";

            TDMaster td1 = new TDMaster(acc, custId, principal, term, interest, mDate, mAmt, rate, mode)
            {
                EffectiveFrom = DateTime.Now
            };

            // The above hardcoding codes should be replaced by the database retrieval 

            return td1;
        }

        // This method is coded to show you how to call methods in the DAL layer
        public int UpdTDbyAccount(string acc, string renewMode)
        {
            TDMasterDAO dao = new TDMasterDAO();
            return dao.UpdateRenewMode(acc, renewMode);
        }
    }
}