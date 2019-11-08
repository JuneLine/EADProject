using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADLab4
{
    public partial class Enquiry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string url = string.Format("~/Acknowledge?Name={0}&Email={1}", tbName.Text, tbEmail.Text);
            Response.Redirect(url);
        }
    }
}