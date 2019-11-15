using EADLab4.BLL;
using EADLab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADLab4
{
    public partial class RetrieveCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGetCustomer_Click(object sender, EventArgs e)
        {
            Customer cusObj = CustomerBLL.GetCustomer(tbCustId.Text);
            if (cusObj != null)
            {
                PanelErrorResult.Visible = false;
                PanelCust.Visible = true;
                Lbl_custname.Text = cusObj.Name;
                Lbl_Address.Text = cusObj.Address;
                Lbl_HomePhone.Text = cusObj.HomePhone;
                Lbl_Mobile.Text = cusObj.Mobile;
                Lbl_err.Text = string.Empty;

                HyplinkAdd.Visible = true;
                Session["SScustId"] = tbCustId.Text;
                Session["SScustName"] = cusObj.Name;
            }
            else
            {
                Lbl_err.Text = "Customer record not found!";
                PanelErrorResult.Visible = true;
                PanelCust.Visible = false;
                Lbl_custname.Text = string.Empty;
                Lbl_Address.Text = string.Empty;
                Lbl_HomePhone.Text = string.Empty;
                Lbl_Mobile.Text = string.Empty;
                HyplinkAdd.Visible = false;
            }
        }
    }
}