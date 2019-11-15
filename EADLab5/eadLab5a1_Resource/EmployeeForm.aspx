<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeForm.aspx.cs" Inherits="eadLab5.EmployeeForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 132px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">NRIC:</td>
                    <td>
                        <asp:TextBox ID="TbNric" runat="server" Width="211px"></asp:TextBox>
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
                        <asp:Button ID="BtnAdd" runat="server" OnClick="BtnAdd_Click" Text="Add" Width="55px" />
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
        <asp:GridView ID="GvEmployee" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Nric" HeaderText="NRIC" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
                <asp:BoundField DataField="Dept" HeaderText="Department" ReadOnly="True" />
                <asp:BoundField DataField="Birthdate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Birth Date" ReadOnly="True" />
                <asp:BoundField DataField="MthlyWage" DataFormatString="{0:N}" HeaderText="Monthly Wage($)" ReadOnly="True" />
                <asp:BoundField DataField="EmployeeCPF" DataFormatString="{0:N}" HeaderText="Employee CPF Contribution ($)" ReadOnly="True" />
                <asp:BoundField DataField="EmployerCPF" HeaderText="Employer CPF Contribution ($)" ReadOnly="True" DataFormatString="{0:N}" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>

