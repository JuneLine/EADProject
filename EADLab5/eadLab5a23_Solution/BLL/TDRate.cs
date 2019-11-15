using eadLab5a23.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eadLab5a23.BLL
{
    public class TDRate
    {
        //
        //  construct interestRte attribute
        //
        public int Term { get; set; }
        public double IntRate { get; set; }

        public TDRate()
        {
        }
        public TDRate(int term, double rate)
        {
            this.Term = term;
            this.IntRate = rate;
        }

        public List<TDRate> GetCurrentRate()
        {
            TDRateDAO dao = new TDRateDAO();
            return dao.SelectCurrent();
        }
    }
}