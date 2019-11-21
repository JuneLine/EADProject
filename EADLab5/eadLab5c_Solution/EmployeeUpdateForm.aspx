<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeUpdateForm.aspx.cs" Inherits="eadLab5.EmployeeUpdateForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">NRIC:</td>
                    <td>
                        <asp:TextBox ID="TbNric" runat="server" Width="211px" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Name:</td>
                    <td>
                        <asp:TextBox ID="TbName" runat="server" Width="211px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Birth Date:</td>
                    <td>
                        <asp:TextBox ID="TbBirthdate" runat="server" Width="211px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Department:</td>
                    <td>
                        <asp:DropDownList ID="DdlDept" runat="server" Width="124px">
                            <asp:ListItem Value="- Select -">- Select -</asp:ListItem>
                            <asp:ListItem>Finance</asp:ListItem>
                            <asp:ListItem>HR</asp:ListItem>
                            <asp:ListItem>IT</asp:ListItem>
                            <asp:ListItem>Sales</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Monthly Wage ($):</td>
                    <td>
                        <asp:TextBox ID="TbMthlyWage" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="BtnUpdate" runat="server" OnClick="BtnUpdate_Click" Text="Update" Width="55px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BtnBack" runat="server" OnClick="BtnBack_Click" Text="Back" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Label ID="LblMsg" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
