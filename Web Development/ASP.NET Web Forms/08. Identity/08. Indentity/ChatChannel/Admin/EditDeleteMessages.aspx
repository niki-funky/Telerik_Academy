<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditDeleteMessages.aspx.cs" Inherits="ChatChannel.Admin.EditDeleteMessages" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit messages</h1>
    <asp:GridView ID="grvMessages" runat="server"
        AutoGenerateColumns="False" DataKeyNames="MessageId"
        PageSize="5" AllowPaging="true" AllowSorting="true"
        ItemType="ChatChannel.Models.Message"
        SelectMethod="grvMessages_GetData"
        DeleteMethod="grvMessages_DeleteItem">
        <Columns>
            <asp:BoundField DataField="Content" HeaderText="Message"
                SortExpression="Content" />
            <asp:HyperLinkField Text="Edit..." HeaderText="Action"
                DataNavigateUrlFields="MessageId"
                DataNavigateUrlFormatString="EditMessage.aspx?messageId={0}" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnbDeleteMessage" runat="server"
                        CommandName="Delete"
                        CommandArgument="<%# Item.MessageId %>"
                        OnClientClick="return confirm('Do you want to cancel ?');"
                        Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <a href="EditMessage.aspx">Create New Message</a>

</asp:Content>
