using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADLab4
{
    public partial class Acknowledge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string name = Request.QueryString["Name"];
                string email = Request.QueryString["Email"];

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
                {
                    pError.Visible = true;
                    return;
                }

                lbMsg.Text = string.Format("Thank you, <b>{0}</b>. We will contact you via email <b>{1}</b>.", name, email);
            }
        }
    }
}