using eadLab5a23.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5a23
{
    public partial class TermDepositForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string custId = string.Empty;
            if (!Page.IsPostBack)
            {
                // Assign session variables for customer Id and Name
                if (Session["SScustId"] != null)
                {
                    LblCustId.Text = Session["SScustId"].ToString();
                    LblCustname.Text = Session["SScustName"].ToString();
                }

                // Instantiate the TDRate class to invoke the GetCurrentRate() method.
                // Instantiate a list to store the TDRate records.
                TDRate tdRate = new TDRate();
                List<TDRate> rateList = tdRate.GetCurrentRate();

                DdlTerm.Items.Clear();
                DdlTerm.Items.Insert(0, new ListItem("--Select--", "0"));
                //AppendDataBoundItems property allows you to add items to the ListControl object before data binding occurs.
                DdlTerm.AppendDataBoundItems = true;

                // set Term as the dropdown list text and intRate as the dropdown list values
                // set the rateList as the DataSource and invoked the DataBind() method.
                DdlTerm.DataTextField = "Term";
                DdlTerm.DataValueField = "IntRate";
                DdlTerm.DataSource = rateList;
                DdlTerm.DataBind();
            }
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            String account = TbNewAcno.Text.ToString();
            String custId = LblCustId.Text.ToString();
            double principal = Convert.ToDouble(TbPrincipal.Text.ToString());
            int term = Convert.ToInt32(DdlTerm.SelectedItem.Text.ToString());
            DateTime mDate = Convert.ToDateTime(LblMaturedDte.Text);
            double interest = Convert.ToDouble(LblInterest.Text.ToString());
            double mAmt = Convert.ToDouble(LblMaturedAmt.Text);
            double rate = Convert.ToSingle(DdlTerm.SelectedValue);
            string mode = DdlRenew.SelectedItem.Text;

            // Instantiate an object from the TDMaster calss and call the AddTermDeposit() method
            TDMaster td = new TDMaster(account, custId, principal, term, interest, mDate, mAmt, rate, mode);
            int insCnt = td.AddTermDeposit();
            if (insCnt == 1)
            {
                LblResult.Text = "Term Deposit Created!";
                LblResult.ForeColor = Color.Green;
            }
            else
            {
                LblResult.Text = "Unable to insert term deposit. Please inform system administrator!";
                LblResult.ForeColor = Color.Red;
            }
            BtnConfirm.Enabled = false;
        }

        // This method calculates the matured amount based on the formula.
        public double CalculateMaturity(double fmPrincipal, int fmTerm, double fmIntRte)
        {
            // A = P x (1 + r/n)nt note that nt is to the power of 
            // r is annual interest rate (1.5% per annual is 0.015)
            // n - number of time interest compounded. Monthly compounding, n will be 12
            //     half yearly compounding will be 2, quarter compounding, n will be 4
            //     This practical assume quarter compounding
            // t - number of months
            int n = 4;
            double r = fmIntRte / 100;
            int t = fmTerm;
            int nt = n * t / 12;
            double fmMaturity = fmPrincipal * Math.Pow((1 + (r / n)), nt);
            fmMaturity = Math.Round(fmMaturity, 1);
            return fmMaturity;
        }

        // Study this code and make sure you know how to use try_catch for your project.
        protected void DdlTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            double fmPrincipal;
            DateTime fmMatureDate;
            double fmInterest, fmMatureAmt;
            int fmTerm;
            double fmIntRate;
            int itemidx = DdlTerm.SelectedIndex;
            if (DdlTerm.SelectedIndex > 0)
            {
                try
                {
                    fmPrincipal = Convert.ToDouble(TbPrincipal.Text);
                    fmIntRate = Convert.ToSingle(DdlTerm.SelectedValue);
                    fmTerm = Convert.ToInt32(DdlTerm.SelectedItem.Text);

                    fmMatureAmt = CalculateMaturity(fmPrincipal, fmTerm, fmIntRate);

                    fmInterest = Math.Round((fmMatureAmt - fmPrincipal), 1);
                    fmMatureDate = DateTime.Now.AddMonths(fmTerm);

                    LblIntRte.Text = DdlTerm.SelectedValue;

                    LblMaturedDte.Text = fmMatureDate.ToString();
                    LblInterest.Text = fmInterest.ToString();
                    LblMaturedAmt.Text = fmMatureAmt.ToString();
                }
                catch (FormatException)
                {
                    LblErr.Text = "Please input an numeric dollar amount!";
                }
            }
            else
            {
                LblErr2.Text = "Select a valid term!";
            }
        }
    }
}