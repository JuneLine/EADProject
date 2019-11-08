using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADLab2
{
    public partial class EventRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbAdminNo.Text = string.Empty;
            tbName.Text = string.Empty;
            rblGender.SelectedIndex = -1;
            ddlCourse.ClearSelection();
            cblEvent.ClearSelection();
            tbMobile.Text = string.Empty;

            panelResult.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lbName.Text = tbName.Text;
                lbGenderText.Text = rblGender.SelectedItem.Text;
                lbGenderValue.Text = rblGender.SelectedValue;
                lbCourseIndex.Text = ddlCourse.SelectedIndex.ToString();
                lbCourseText.Text = ddlCourse.SelectedItem.Text;
                lbCourseValue.Text = ddlCourse.SelectedValue;
                lbEvent.Items.Clear();
                foreach (ListItem item in cblEvent.Items)
                {
                    if (item.Selected)
                    {
                        lbEvent.Items.Add(item.Value);
                    }
                }

                panelResult.Visible = true;
            }
            else
            {
                panelResult.Visible = false;
            }
        }

        protected void eventValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            foreach (ListItem item in cblEvent.Items)
            {
                if (item.Selected)
                {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }
    }
}