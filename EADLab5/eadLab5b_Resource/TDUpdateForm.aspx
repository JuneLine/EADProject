<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true" CodeBehind="TDUpdateForm.aspx.cs" Inherits="eadLab5a23.TDUpdateForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">

        <h2>Update Term Deposit</h2>
        <table class="table">
            <tr>
                <td class="auto-style1">Customer NRIC: :</td>
                <td>
                    <asp:Label ID="LblCustId" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Customer Name :</td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
                    <asp:Label ID="LblCustname" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">TD Account:</td>
                <td>
                    <asp:Label ID="LblAcno" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Principal (S$) :</td>
                <td>

                    <asp:Label ID="LblPrincipal" runat="server"></asp:Label>
                   
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Maturity Date :</td>
                <td>
                    <asp:Label ID="LblMaturedDte" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">P+I (S$):</td>
                <td>
                    <asp:Label ID="LblMaturedAmt" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">TD Renewal Mode :</td>
                <td>
                    <asp:DropDownList ID="DdlRenew" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                        <asp:ListItem Value="1">Renew P+I</asp:ListItem>
                        <asp:ListItem Value="2">Renew P</asp:ListItem>
                        <asp:ListItem Value="3">Not renewing</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click"  />&nbsp;&nbsp;
                   <asp:Button ID="BtnBack" runat="server" OnClick="BtnBack_Click" Text="Back" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Label ID="LblResult" Text="" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
