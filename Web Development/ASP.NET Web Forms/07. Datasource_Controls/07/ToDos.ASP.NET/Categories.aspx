﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="ToDos.ASP.NET.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListBox ID="lbCategories" runat="server"
        DataSourceID="dsCategories"
        DataTextField="Name" DataValueField="Id"
        AutoPostBack="True"
        OnSelectedIndexChanged="lbCategories_SelectedIndexChanged"></asp:ListBox>

    <asp:EntityDataSource ID="dsCategories" runat="server"
        ConnectionString="name=ToDosDBEntities2"
        DefaultContainerName="ToDosDBEntities2"
        EnableDelete="True" EnableInsert="True" EnableUpdate="True"
        EnableFlattening="False"
        EntitySetName="Categories">
    </asp:EntityDataSource>
    <br />
    Category Name:
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click">Save Category</asp:LinkButton>
</asp:Content>
