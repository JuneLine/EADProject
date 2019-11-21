<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeViewForm.aspx.cs" Inherits="eadLab5.EmployeeForm" %>

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
        </div>
        <asp:GridView ID="GvEmployee" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GvEmployee_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Nric" HeaderText="NRIC" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
                <asp:BoundField DataField="Dept" HeaderText="Department" ReadOnly="True" />
                <asp:BoundField DataField="Birthdate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Birth Date" ReadOnly="True" />
                <asp:BoundField DataField="MthlyWage" DataFormatString="{0:N}" HeaderText="Monthly Wage($)" ReadOnly="True" />
                <asp:BoundField DataField="EmployeeCPF" DataFormatString="{0:N}" HeaderText="Employee CPF Contribution ($)" ReadOnly="True" />
                <asp:BoundField DataField="EmployerCPF" HeaderText="Employer CPF Contribution ($)" ReadOnly="True" DataFormatString="{0:N}" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <p>
                        <asp:Button ID="BtnAdd" runat="server" OnClick="BtnAdd_Click" Text="Add" Width="55px" />
                    </p>
    </form>
</body>
</html>

