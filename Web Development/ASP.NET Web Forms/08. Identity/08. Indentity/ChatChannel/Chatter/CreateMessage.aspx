<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CreateMessage.aspx.cs" Inherits="ChatChannel.Chatter.CreateMessage" %>

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
