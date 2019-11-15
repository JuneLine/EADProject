using EADLab4.BLL;
using EADLab4.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADLab4
{
    public partial class AddTermDeposit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                List<TDRate> rateList = TDRateBLL.GetCurrentList();

                DdlTerm.Items.Insert(0, new ListItem("--Select--", ""));
                //AppendDataBoundItems property allows you to add items to the ListControl object before data binding occurs.
                DdlTerm.AppendDataBoundItems = true;

                // set Term as the dropdown list text and intRate as the dropdown list values
                // set the rateList as the DataSource and invoked the DataBind() method.
                DdlTerm.DataTextField = "Term";
                DdlTerm.DataValueField = "Rate";
                DdlTerm.DataSource = rateList;
                DdlTerm.DataBind();
            }
        }

        private bool ValidateInput()
        {
            bool isValid = true;

            try
            {
                Convert.ToDouble(TbPrincipal.Text);
                LblErr.Text = string.Empty;
            }
            catch (FormatException)
            {
                LblErr.Text = "Please input an numeric dollar amount!";
                isValid = false;
            }

            if (DdlTerm.SelectedIndex > 0)
            {
                LblErr2.Text = string.Empty;
            }
            else
            {
                LblErr2.Text = "Select a valid term!";
                isValid = false;
            }

            return isValid;
        }

        protected void DdlTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                double principal = Convert.ToDouble(TbPrincipal.Text);
                int term = Convert.ToInt32(DdlTerm.SelectedItem.Text);
                double rate = Convert.ToDouble(DdlTerm.SelectedValue);

                TDMaster td = TDMasterBLL.GetComputedObject(principal, term, rate);

                LblIntRte.Text = DdlTerm.SelectedValue;
                LblMaturedDte.Text = td.Maturity.ToShortDateString();
                LblInterest.Text = td.InterestAmt.ToString();
                LblMaturedAmt.Text = td.MatureAmt.ToString();
            }
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string account = TbNewAcno.Text.ToString();
                string custId = LblCustId.Text.ToString();
                double principal = Convert.ToDouble(TbPrincipal.Text.ToString());
                int term = Convert.ToInt32(DdlTerm.SelectedItem.Text.ToString());
                double rate = Convert.ToDouble(DdlTerm.SelectedValue);
                string mode = DdlRenew.SelectedItem.Text;

                bool result = TDMasterBLL.Add(account, custId, principal, term, rate, mode);

                if (result)
                {
                    LblResult.Text = "Term Deposit Created!";
                    LblResult.ForeColor = Color.Green;
                }
                else
                {
                    LblResult.Text = "Unable to insert term deposit. Please inform system administrator!";
                    LblResult.ForeColor = Color.Red;
                }
            }
        }
    }
}