<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditMessage.aspx.cs" Inherits="ChatChannel.Moderator.EditMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit Message</h1>

    Message Text:
    <asp:TextBox ID="tbMessageContent" runat="server" />
    <asp:LinkButton ID="lnbSaveMessage" runat="server"
        Text="Save" OnClick="lnbSaveMessage_Click" />
    <br />
    <asp:LinkButton ID="lnbReturn" runat="server"
        Text="Return" OnClick="lnbReturn_Click" />
</asp:Content>
