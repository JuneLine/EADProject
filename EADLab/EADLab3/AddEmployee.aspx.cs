using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EADLab3.BLL;

namespace EADLab3
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                EmployeeBLL.AddEmployee(
                    tbNRIC.Text,
                    tbName.Text,
                    Convert.ToDateTime(tbBirthDate.Text),
                    ddlDepartment.SelectedValue,
                    Convert.ToDouble(tbMonthlyWage.Text));

                GvEmployee.DataSource = EmployeeBLL.GetAll();
                GvEmployee.DataBind();
            }
        }

        protected void NRICValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = EmployeeBLL.ValidateNRICNotDuplicate(args.Value);
        }

        protected void BirthDateValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = EmployeeBLL.ValidateBirthDate(Convert.ToDateTime(args.Value));
        }
    }
}