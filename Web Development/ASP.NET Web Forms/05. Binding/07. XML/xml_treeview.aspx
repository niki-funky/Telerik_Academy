<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xml_treeview.aspx.cs" Inherits="_07.XML.xml_treeview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>XML treeView</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TreeView ID="TreeView1" runat="server" DataSourceID="XmlDataSource1"
                ExpandImageUrl="Images/icon-expand.gif"
                CollapseImageUrl="Images/icon-collapse.gif">
            <DataBindings>
                <asp:TreeNodeBinding DataMember="Category"
                    ValueField="ID" 
                    TextField="Name"></asp:TreeNodeBinding>
                <asp:TreeNodeBinding DataMember="Description"
                    ValueField="Value"
                    TextField="Value"></asp:TreeNodeBinding>
            </DataBindings>
        </asp:TreeView>

        <asp:XmlDataSource ID="XmlDataSource1" runat="server"
            DataFile="~/XMLFile.xml"
            XPath="Categories/Category"></asp:XmlDataSource>
    </form>
</body>
</html>
