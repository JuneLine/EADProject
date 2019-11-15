using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADLab4.Models
{
    public class TDMaster
    {
        public string Account { get; set; }

        public string CustId { get; set; }

        public double Principal { get; set; }

        public int Term { get; set; }

        public DateTime EffFrom { get; set; }

        public DateTime Maturity { get; set; }

        public double InterestAmt { get; set; }

        public double MatureAmt { get; set; }

        public double TDRate { get; set; }

        public string RenewMode { get; set; }
    }
}