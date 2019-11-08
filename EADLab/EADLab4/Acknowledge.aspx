<%@ Page Title="Acknowledge" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Acknowledge.aspx.cs" Inherits="EADLab4.Acknowledge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" ID="pError" Visible="false">
        <div class="alert alert-danger" role="alert" style="margin-top:10px">
            Pease provide your contact!
        </div>
    </asp:Panel>

    <h3><%: Title %></h3>
    <hr />
    <asp:Label ID="lbMsg" runat="server"></asp:Label>
</asp:Content>
