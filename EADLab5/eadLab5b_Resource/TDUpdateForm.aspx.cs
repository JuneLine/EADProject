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
            if (Page.IsPostBack == false)
            {
                if (Session["SSTDAcNo"] != null)
                {
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
                    DdlRenew.SelectedItem.Text = td.RenewMode;

                    // Store the current renew mode to compare with the new choice
                    ViewState["currRenewMode"] = td.RenewMode; ;
                }
                else
                {
                    Response.Redirect("CustomerForm.aspx");
                }

            }

        }

        // There is no input validation before the update.
        // What validations can you include here?
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int updCnt;
            string newRenewMode = "";

            newRenewMode = DdlRenew.SelectedItem.Text;

            // Update renewal mode in TDMaster table account
            TDMaster td = new TDMaster();
            updCnt = td.UpdTDbyAccount(LblAcno.Text, newRenewMode);

            if (updCnt == 1)
            {
                LblResult.Text = "TD Renew Mode Updated!";
                LblResult.ForeColor = Color.Green;
            }
            else
            {
                LblResult.Text = "Unable to change time deposit, please inform system administrator!";
                LblResult.ForeColor = Color.Red;

            }
            BtnUpdate.Enabled = false;
            
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            // Add in the code for the Back button
        }
    }
}