<%@ Page Title="Enquiry" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Enquiry.aspx.cs" Inherits="EADLab4.Enquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%: Title %></h3>
    <hr />
    <p>
        Contact us at telephone 67189999 or email our customer officer at admin@eadp.com.<br />
        Alternatively, submit an enquiry and our customer officer will contact you shortly!
    </p>
    <div>
        <div class="form-group">
            <asp:Label runat="server" for="tbName" ID="lblName" CssClass="control-label">Name</asp:Label>
            <asp:TextBox ID="tbName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server" for="tbEmail" ID="lblEmail" CssClass="control-label" Text="Email">
            </asp:Label>
            <asp:TextBox ID="tbEmail" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblEnquiry" runat="server" for="tbEnquiry" CssClass="control-label" Text="Enquiry">
            </asp:Label>
            <asp:TextBox ID="tbEnquiry" runat="server" class="form-control" Height="49px" TextMode="MultiLine">
            </asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" Text="Submit"
                OnClick="btnSubmit_Click" />
        </div>
    </div>
</asp:Content>
