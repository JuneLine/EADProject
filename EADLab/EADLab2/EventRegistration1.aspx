<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventRegistration1.aspx.cs" Inherits="EADLab2.EventRegistration1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Registration</title>
    <link href="CommonStyle.css" rel="stylesheet" type="text/css" />
    <script>
        function valiateGender(source, args) {
            args.IsValid = args.Value != ""
        }

        function validateEvent(source, args) {
            var items = $("input[name^='cblEvent']");
            for (i = 0; i < items.length; i++) {
                if ($(items[i]).is(":checked")) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img src="LabBanner.jpg" /><br />
            <h3 class="title">Sports League Registration</h3>
            <table>
                <tr>
                    <td>
                        Admin No:
                        <!-- RequiredFieldValidator -->
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tbAdminNo"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        Name:
                        <!-- RequiredFieldValidator -->
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tbName"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        Gender:
                        <!-- CustomValidator ValidateEmptyText ClientValidationFunction -->
                    </td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="rblGender" RepeatDirection="Horizontal">
                            <asp:ListItem Value="M">Male</asp:ListItem>
                            <asp:ListItem Value="F">Feale</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Course:
                        <!-- RequiredFieldValidator InitialValue -->
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlCourse">
                            <asp:ListItem Value="-1">-- Select --</asp:ListItem>
                            <asp:ListItem Value="ITDF01">DIT</asp:ListItem>
                            <asp:ListItem Value="ITDF03">DBI</asp:ListItem>
                            <asp:ListItem Value="ITDF07">DBT</asp:ListItem>
                            <asp:ListItem Value="ITDF10">DBA</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Event:
                        <!-- CustomValidator ValidateEmptyText ClientValidationFunction -->
                        <!-- CustomValidator OnServerValidate -->
                    </td>
                    <td>
                        <asp:CheckBoxList runat="server" ID="cblEvent" RepeatDirection="Horizontal" RepeatColumns="3">
                            <asp:ListItem>100m Running</asp:ListItem>
                            <asp:ListItem>400m Running</asp:ListItem>
                            <asp:ListItem>100m Butterfly Swimming</asp:ListItem>
                            <asp:ListItem>200m Freestyle Swimming</asp:ListItem>
                            <asp:ListItem>Badminton</asp:ListItem>
                            <asp:ListItem>Table Tennis</asp:ListItem>
                            <asp:ListItem>Tennis</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Mobile:
                        <!-- RequiredFieldValidator -->
                        <!-- RegularExpressionValidator ValidationExpression="^[89]\d{7}$" -->
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tbMobile"/>
                    </td>
                </tr>
            </table>
            <br />
            <div>
                <asp:Button runat="server" ID="btnClear" Text="Clear" style="margin-right:20px" OnClick="btnClear_Click" CausesValidation="false"/>
                <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click"/>
            </div>
            <br />
            <div>
                <!-- RequiredFieldValidator HeaderText -->
            </div>
            <br />
            <asp:Panel runat="server" ID="panelResult" Visible="false">
                Thank you, <asp:Label runat="server" ID="lbName"></asp:Label>.<br />
                Gender Text: <asp:Label runat="server" ID="lbGenderText"></asp:Label>
                &nbsp;&nbsp;&nbsp; Gender Value: <asp:Label runat="server" ID="lbGenderValue"></asp:Label><br />
                Course Selected Index: <asp:Label runat="server" ID="lbCourseIndex"></asp:Label><br />
                Course Text: <asp:Label runat="server" ID="lbCourseText"></asp:Label>
                &nbsp;&nbsp;&nbsp; Course Value: <asp:Label runat="server" ID="lbCourseValue"></asp:Label><br />
                <asp:ListBox runat="server" ID="lbEvent"></asp:ListBox>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
