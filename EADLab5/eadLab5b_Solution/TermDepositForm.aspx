<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true" CodeBehind="TermDepositForm.aspx.cs" Inherits="eadLab5a23.TermDepositForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <h2>Term Deposit Placement</h2>
        <table class="table">
            <tr>
                <td class="auto-style1">Customer Id:</td>
                <td>
                    <asp:Label ID="LblCustId" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Customer Name:</td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
                    <asp:Label ID="LblCustname" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">New TD Account:</td>
                <td>
                    <asp:TextBox ID="TbNewAcno" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Principal (S$) :</td>
                <td>

                    <asp:TextBox ID="TbPrincipal" runat="server"></asp:TextBox>
                    &nbsp;<asp:Label ID="LblErr" Text="" ForeColor="Red" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Term (months): </td>
                <td>
                    <asp:DropDownList ID="DdlTerm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlTerm_SelectedIndexChanged">
                    </asp:DropDownList>&nbsp;<asp:Label ID="LblErr2" ForeColor="Red" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Interest Rate (%) :</td>
                <td>
                    <asp:Label ID="LblIntRte" Text="" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="auto-style1">Maturity Date :</td>
                <td>
                    <asp:Label ID="LblMaturedDte" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Interest Earned (S$):</td>
                <td>
                    <asp:Label ID="LblInterest" Text="" runat="server"></asp:Label>
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
                    <asp:DropDownList ID="DdlRenew" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlTerm_SelectedIndexChanged">
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
                    <asp:Button ID="BtnConfirm" runat="server" Text="Confirm" OnClick="BtnConfirm_Click" />&nbsp;</td>
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
