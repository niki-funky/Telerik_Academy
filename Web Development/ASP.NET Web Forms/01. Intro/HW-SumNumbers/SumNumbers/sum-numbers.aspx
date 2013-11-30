<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sum-numbers.aspx.cs" Inherits="SumNumbers.sum_numbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 198px; width: 272px">
    
        <asp:Label ID="LabelFirstNumber" runat="server" Text="First Number:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxNum1" runat="server" OnTextChanged="TextBox1_TextChanged" style="width: 128px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Second Number: "></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxNum2" runat="server" style="width: 128px"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="TextBoxSum" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="Silver" Height="35px" OnTextChanged="TextBoxSum_TextChanged" ReadOnly="True" Width="220px">Result</asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Press to Sum the Numbers" Width="248px" />
    
    </div>
    </form>
</body>
</html>
