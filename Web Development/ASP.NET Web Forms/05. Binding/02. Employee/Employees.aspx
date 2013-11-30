<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_02.Employee.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--Task 2--%>
            <asp:GridView ID="grdEmployers" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="Id"
                    CellPadding="4" ForeColor="#333333" GridLines="None"
                    AllowPaging="True"
                    OnPageIndexChanging="grdEmployers_PageIndexChanging"
                    OnSelectedIndexChanged="grdEmployers_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="Id"
                        DataNavigateUrlFormatString="EmpDetails.aspx?id={0}"
                        DataTextField="FullName"
                        DataTextFormatString="{0}"
                        HeaderText="Exployers" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <i>You are viewing page
                <%=grdEmployers.PageIndex + 1%>
                    of
                <%=grdEmployers.PageCount%>
            </i>
            <br />

            <%--Task 4--%>
            <asp:FormView ID="grdFormView" runat="server"
                CellPadding="4" ForeColor="#333333"
                ItemType="_02.Employee.Employee">
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text="<%#: Item.FirstName + ' ' + Item.LastName %>"></asp:Label>
                </ItemTemplate>
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            </asp:FormView>

            <%--Task 5--%>
            <asp:Repeater ID="rEmployees" runat="server" >
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
            <table>
                <tr>
                    <td>
                        <asp:PlaceHolder ID="plcPaging" runat="server" />
                        <br />
                        <asp:Label runat="server" ID="lblPageName" />
                    </td>
                </tr>
            </table>

            <br />

            <%--Task 5--%>
            <asp:ListView ID="lvEmployees" runat="server" ItemType="_02.Employee.Employee">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text="<%#: Item.FirstName %>"></asp:Label><br />
                </ItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
