<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="generate_random_number.aspx.cs" Inherits="ASP.NET_Controls.generate_random_number" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        First number:
        <br />
        <asp:TextBox ID="firstNumber" runat="server" Style="margin-left: 0px" Width="204px"></asp:TextBox>
        <br />
        Second number:
        <br />
        <asp:TextBox ID="secondNumber" runat="server" Style="margin-left: 0px; margin-right: 0px" Width="207px"></asp:TextBox>
        <br />
        <asp:Button ID="btn_generateNumber" runat="server" Text="Generate Number" Width="119px" OnClick="btn_generateNumber_Click" />
        <br />
        <asp:Label ID="lblRangeResult" runat="server"></asp:Label>
    </form>
</body>
</html>

