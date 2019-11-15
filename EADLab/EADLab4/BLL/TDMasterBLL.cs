using EADLab4.DAL;
using EADLab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADLab4.BLL
{
    public class TDMasterBLL
    {
        // This method calculates the matured amount based on the formula.
        private static double CalculateMaturity(double principal, int term, double rate)
        {
            // A = P x (1 + r/n)nt note that nt is to the power of 
            // r is annual interest rate (1.5% per annual is 0.015)
            // n - number of time interest compounded. Monthly compounding, n will be 12
            //     half yearly compounding will be 2, quarter compounding, n will be 4
            //     This practical assume quarter compounding
            // t - number of months
            int n = 4;
            double r = rate / 100;
            int t = term;
            int nt = n * t / 12;
            double maturity = principal * Math.Pow((1 + (r / n)), nt);
            maturity = Math.Round(maturity, 1);
            return maturity;
        }

        private static void Compute(TDMaster td)
        {
            double principal = td.Principal;
            int term = td.Term;
            double rate = td.TDRate;
            
            DateTime effDate = DateTime.Today;
            DateTime matureDate = effDate.AddMonths(term);
            double matureAmt = CalculateMaturity(principal, term, rate);
            double interestAmt = Math.Round(matureAmt - principal, 1);

            td.EffFrom = effDate;
            td.Maturity = matureDate;
            td.MatureAmt = matureAmt;
            td.InterestAmt = interestAmt;
        }

        public static TDMaster GetComputedObject(double principal, int term, double rate)
        {
            TDMaster td = new TDMaster();
            td.Principal = principal;
            td.Term = term;
            td.TDRate = rate;

            Compute(td);
            return td;
        }

        public static bool Add(string account, string custId, double principal, int term, double rate, string renewMode)
        {
            TDMaster td = new TDMaster();
            td.Account = account;
            td.CustId = custId;
            td.Principal = principal;
            td.Term = term;
            td.TDRate = rate;
            td.RenewMode = renewMode;

            Compute(td);

            return TDMasterDAL.Insert(td);
        }
    }
}