<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" %>

<asp:Content ID="ContentPage" runat="server" ContentPlaceHolderID="ContentPlaceHolderPageContent">
    <h1 id="welcome-text">Welcome to the International web site</h1>
    <asp:HyperLink runat="server" NavigateUrl="~/Bulgaria/BulgariaHome.aspx"
        Text="Bulgaria Area" CssClass="bulgaria icon" />
    <asp:HyperLink runat="server" NavigateUrl="~/Germany/GermanyHome.aspx"
        Text="Germany Area" CssClass="germany icon" />
    <asp:HyperLink runat="server" NavigateUrl="~/Brazil/BrazilHome.aspx"
        Text="Brazil Area" CssClass="brazil icon" />
</asp:Content>
