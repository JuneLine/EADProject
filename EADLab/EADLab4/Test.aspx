<%@ Page Title="Test" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="EADLab4.Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%: Title %></h3>
    <hr />
    Count:
    <asp:Label runat="server" ID="lbCount"></asp:Label>
    <br />
    <asp:Button runat="server" ID="btnIncrease" OnClick="btnIncrease_Click" Text="Increase" class="btn btn-primary" Style="margin-top: 10px" />

    <hr />
    <h3>Join Us</h3>
    <hr />
    <p>
        Curious to know what our day to day campus life is like?  
        	Our student ambassadors are more willing to 
        	share their experience with you!
    </p>
    <hr />
    <div class="row">
        <div class="col-sm-4">
            <img alt="location map" src="tutMap.jpg" />
        </div>
        <div class="col-sm-8">
            <p>Join our open house event on 2 Jan to 5 Jan</p>
            <p>Address:180 Ang Mo Kio Ave 8 Singapore 569830</p>
            <p>Phone:6451 5115</p>
            <p>Email:nyp_oh@nyp.edu.sg</p>
        </div>
    </div>

</asp:Content>
