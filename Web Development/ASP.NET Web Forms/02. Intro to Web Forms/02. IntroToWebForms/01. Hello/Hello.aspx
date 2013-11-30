<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hello.aspx.cs" Inherits="_01.Hello.Hello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    &nbsp;<asp:Label ID="Label1" runat="server" Text="Please enter your name: "></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxName" runat="server" AutoCompleteType="FirstName" Width="290px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="ButtonResult" runat="server" OnClick="ButtonResult_Click" Text="Push The Button" />
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxResult" runat="server" Enabled="False" Width="286px"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
