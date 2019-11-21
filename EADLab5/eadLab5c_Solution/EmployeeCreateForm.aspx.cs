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
    public partial class EmployeeCreateForm : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        private bool ValidateInput()
        {
            bool result;
            LblMsg.Text = String.Empty;

            if (TbNric.Text == "")
            {
                LblMsg.Text += "NRIC is required!" + "<br/>";
            }
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

            if (DdlDept.SelectedIndex == 0)
            {
                LblMsg.Text += "Department must be selected!" + "<br/>";
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

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();

            if (emp.GetEmployeeById(TbNric.Text) != null)
            {
                LblMsg.Text = "Record already exists!";
                LblMsg.ForeColor = Color.Red;
            }
            else
            {
                if (ValidateInput())
                {
                    DateTime dob = Convert.ToDateTime(TbBirthdate.Text);
                    double wage = Convert.ToDouble(TbMthlyWage.Text);

                    emp = new Employee(TbNric.Text, TbName.Text, dob, DdlDept.Text, wage);
                    int result = emp.AddEmployee();
                    if (result == 1)
                    {
                        LblMsg.Text = "Record added successfully!";
                        LblMsg.ForeColor = Color.Green;
                    }
                    else
                    {
                        LblMsg.Text = "Error in adding record! Inform System Administrator!";
                        LblMsg.ForeColor = Color.Red;
                    }
                }
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeViewForm.aspx");
        }
    }
}