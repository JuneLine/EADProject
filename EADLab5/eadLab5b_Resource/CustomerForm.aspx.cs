﻿using eadLab5a23.BLL;
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

        }

        protected void BtnGetCustomer_Click(object sender, EventArgs e)
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
                Lbl_err.Text = String.Empty;

                HyplinkAdd.Visible = true;

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
                Lbl_custname.Text = String.Empty;
                Lbl_Address.Text = String.Empty;
                Lbl_HomePhone.Text = String.Empty;
                Lbl_Mobile.Text = String.Empty;
                HyplinkAdd.Visible = false;
            }
        }
        private void RefreshGridView(List<TDMaster> list)
        {
            // add your codes here
        }

        protected void GvTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            // add your codes here
        }
    }
}