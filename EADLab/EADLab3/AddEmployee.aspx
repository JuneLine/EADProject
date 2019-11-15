<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="EADLab3.AddEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .error {
            color: red;
        }

        th {
            padding: 5px 10px;
        }

        td {
            padding: 5px 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>NRIC:
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbNRIC" CssClass="error" ErrorMessage="NRIC is required">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="tbNRIC" ValidationExpression="^[STFG]\d{7}[A-Z]$" CssClass="error" ErrorMessage="Invalid NRIC">!</asp:RegularExpressionValidator>
                        <asp:CustomValidator runat="server" ControlToValidate="tbNRIC" CssClass="error" ErrorMessage="NRIC already exists" ID="NRICValidator" OnServerValidate="NRICValidator_ServerValidate">!</asp:CustomValidator>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tbNRIC"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Name:
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbName" CssClass="error" ErrorMessage="Name is required">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tbName" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Birhth Date:
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbBirthDate" CssClass="error" ErrorMessage="Birth Date is required">*</asp:RequiredFieldValidator>
                        <asp:CustomValidator runat="server" ControlToValidate="tbBirthDate" CssClass="error" ErrorMessage="Age is below minimum" ID="BirthDateValidator" OnServerValidate="BirthDateValidator_ServerValidate">!</asp:CustomValidator>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tbBirthDate" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Department:
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlDepartment" CssClass="error" ErrorMessage="Department is required">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlDepartment">
                            <asp:ListItem Value="">- Select -</asp:ListItem>
                            <asp:ListItem>Finance</asp:ListItem>
                            <asp:ListItem>HR</asp:ListItem>
                            <asp:ListItem>IT</asp:ListItem>
                            <asp:ListItem>Sales</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Monthly Wage ($):
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbMonthlyWage" CssClass="error" ErrorMessage="Monthly Wage is required">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tbMonthlyWage" TextMode="Number" min="0"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <br />
            <div>
                <asp:Button runat="server" ID="btnAdd" Text="Add" OnClick="btnAdd_Click" />
                <asp:ValidationSummary runat="server" CssClass="error" />
            </div>
            <br />
            <asp:GridView ID="GvEmployee" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="NRIC" HeaderText="NRIC" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Dept" HeaderText="Department" />
                    <asp:BoundField DataField="BirthDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Birth Date" />
                    <asp:BoundField DataField="MthlyWage" DataFormatString="{0:N}" HeaderText="Monthly Wage($)" />
                    <asp:BoundField DataField="EmployeeCPF" DataFormatString="{0:N}" HeaderText="Employee CPF <br/>Contribution ($)" HtmlEncode="false" />
                    <asp:BoundField DataField="EmployerCPF" DataFormatString="{0:N}" HeaderText="Employer CPF <br/>Contribution ($)" HtmlEncode="false" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
