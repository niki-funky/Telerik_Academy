<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditMessages.aspx.cs" Inherits="ChatChannel.Moderator.EditDeleteMessages" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit messages</h1>
    <asp:GridView ID="grvMessages" runat="server"
        AutoGenerateColumns="False" DataKeyNames="MessageId"
        PageSize="5" AllowPaging="true" AllowSorting="true"
        ItemType="ChatChannel.Models.Message"
        SelectMethod="grvMessages_GetData">
        <Columns>
            <asp:BoundField DataField="Content" HeaderText="Message"
                SortExpression="Content" />
            <asp:HyperLinkField Text="Edit..." HeaderText="Action"
                DataNavigateUrlFields="MessageId"
                DataNavigateUrlFormatString="EditMessage.aspx?messageId={0}" />
        </Columns>
    </asp:GridView>

    <a href="EditMessage.aspx">Create New Message</a>

</asp:Content>
