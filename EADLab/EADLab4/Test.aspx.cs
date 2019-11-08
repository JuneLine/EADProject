using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADLab4
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int count = 0;
                ViewState["count"] = count;
                lbCount.Text = count.ToString();
            }
        }

        protected void btnIncrease_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(ViewState["count"]);
            count++;
            ViewState["count"] = count;
            lbCount.Text = count.ToString();
        }
    }
}