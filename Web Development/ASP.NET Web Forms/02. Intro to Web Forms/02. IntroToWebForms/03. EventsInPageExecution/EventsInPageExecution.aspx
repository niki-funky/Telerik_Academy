<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventsInPageExecution.aspx.cs" Inherits="_03.EventsInPageExecution.EventsInPageExecution" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Click Image to see all events on page execution</h2>
        <asp:ImageButton ID="ImageButton1" runat="server" 
            BorderColor="Black" BorderStyle="Solid" Height="138px" 
            ImageUrl="http://academy.telerik.com/images/default-album/programming-champion-telerik-academy.png?sfvrsn=2" Width="159px" 
            OnInit="ButtonOK_Init" OnLoad="ButtonOK_Load" OnClick="ButtonOK_Click"
            OnPreRender="ButtonOK_PreRender" OnUnload="ButtonOK_Unload" />
    
    </div>
    </form>
</body>
</html>
