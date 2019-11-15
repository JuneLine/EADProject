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
    public partial class TDUpdateForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["SScustId"] == null || Session["SSTDAcNo"] == null)
                {
                    Response.Redirect("CustomerForm.aspx");
                }

                // Assign session variables for customer id, name and account labels
                LblCustId.Text = Session["SScustId"].ToString();
                LblCustname.Text = Session["SScustName"].ToString();
                LblAcno.Text = Session["SSTDAcNo"].ToString();

                // Retrieve TDMaster records by account
                TDMaster td = new TDMaster();
                td = td.GetTDbyAccount(LblAcno.Text);

                // Show TDMaster info on form
                LblPrincipal.Text = td.Principal.ToString();
                LblMaturedAmt.Text = td.MaturedAmt.ToString();
                LblMaturedDte.Text = td.MaturityDate.ToString();
                DdlRenew.SelectedValue = td.RenewMode;

                // Store the current renew mode to compare with new choice
                ViewState["currRenewMode"] = td.RenewMode;
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            // Retrieve the current renew mode from ViewState
            string currRenewMode = (string)ViewState["currRenewMode"];

            if (DdlRenew.SelectedIndex == 0)
            {
                LblResult.Text = "Please select a value";
                LblResult.ForeColor = Color.Red;
            }
            else if (DdlRenew.SelectedItem.Text.Equals(currRenewMode))
            {
                LblResult.Text = "No change in the renewal mode!";
                LblResult.ForeColor = Color.Red;
            }
            else
            {
                string newRenewMode = DdlRenew.SelectedItem.Text;

                // Update renewal mode in TDMaster table account
                TDMaster td = new TDMaster();
                int updCnt = td.UpdTDbyAccount(LblAcno.Text, newRenewMode);

                if (updCnt == 1)
                {
                    LblResult.Text = "TD Renew Mode Updated!";
                    LblResult.ForeColor = Color.Green;
                    ViewState["currRenewMode"] = newRenewMode;
                }
                else
                {
                    LblResult.Text = "Unable to change time deposit, please inform system administrator!";
                    LblResult.ForeColor = Color.Red;
                }
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            // Add in the code for the Back button
            Response.Redirect("CustomerForm.aspx");
        }
    }
}