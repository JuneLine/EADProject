using eadLab5a23.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5a23
{
    public partial class CustomerForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SScustId"] != null)
                {
                    TbCustId.Text = Session["SScustId"].ToString();
                    LoadCustomerForm();
                }
            }
        }

        protected void BtnGetCustomer_Click(object sender, EventArgs e)
        {
            LoadCustomerForm();
        }

        protected void LoadCustomerForm()
        {
            Customer cusObj = new Customer();
            cusObj = cusObj.GetCustomerById(TbCustId.Text);
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
                GvTD.Visible = true;

                TDMaster td = new TDMaster();
                List<TDMaster> list = td.GetTDbyCustId(TbCustId.Text);
                RefreshGridView(list);
                Session["SScustId"] = TbCustId.Text;
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
                GvTD.Visible = false;
            }
        }

        private void RefreshGridView(List<TDMaster> list)
        {
            // using gridview to bind to the list of employee objects
            GvTD.DataSource = list;
            GvTD.DataBind();
        }

        protected void GvTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GvTD.SelectedRow;
            // In this grid, the first cell (index 0) contains
            // the TD Account.
            Session["SSTDAcNo"] = row.Cells[0].Text;
            Response.Redirect("TDUpdateForm.aspx");
        }
    }
}