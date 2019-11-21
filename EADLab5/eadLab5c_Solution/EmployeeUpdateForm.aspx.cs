using eadLab5.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5
{
    public partial class EmployeeUpdateForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TbNric.Text = (string)Session["SSId"];
                TbName.Text = (string)Session["SSName"];
                TbBirthdate.Text = (string)Session["SSBirthDate"];
                DdlDept.SelectedItem.Text = (string)Session["SSDept"];
                TbMthlyWage.Text = (string)Session["SSWage"];
            }
        }



        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeViewForm.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                DateTime dob = Convert.ToDateTime(TbBirthdate.Text);
                double wage = Convert.ToDouble(TbMthlyWage.Text);

                Employee emp = new Employee(TbNric.Text, TbName.Text, dob, DdlDept.Text, wage);
                int result = emp.UpdateEmployee();
                if (result == 1)
                {
                    LblMsg.Text = "Record updated successfully!";
                    LblMsg.ForeColor = Color.Green;
                }
                else
                {
                    LblMsg.Text = "Error in adding record! Inform System Administrator!";
                    LblMsg.ForeColor = Color.Red;
                }
            }
        }
        private bool ValidateInput()
        {
            bool result;
            LblMsg.Text = String.Empty;

            if (String.IsNullOrEmpty(TbName.Text))
            {
                LblMsg.Text += "Name is required!" + "<br/>";
            }
            DateTime dob;
            result = DateTime.TryParse(TbBirthdate.Text, out dob);
            if (!result)
            {
                LblMsg.Text += "Birth Date is invalid!" + "<br/>";
            }
            double wage;
            result = double.TryParse(TbMthlyWage.Text, out wage);
            if (!result)
            {
                LblMsg.Text += "Monthly Wage is invalid!" + "<br/>";
            }

            if (String.IsNullOrEmpty(LblMsg.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}