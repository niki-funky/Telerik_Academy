<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Chat.aspx.cs" Inherits="ChatChannel.Chat" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Chat channel</h1>
    <div id="messages">
        <asp:ListView ID="lvMessages" runat="server"
            ItemType="ChatChannel.Models.MessageModel">
            <LayoutTemplate>
                <div id="itemPlaceholder" runat="server"></div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="chat-message">
                    <span id="username"><%#: Item.UserName %></span>
                    <span id="content"><%#: Item.Content %></span>
                    <span id="date"><%#: Item.PostDate %></span>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>

    <a href="CreateMessage.aspx">Create New Message</a>

</asp:Content>
