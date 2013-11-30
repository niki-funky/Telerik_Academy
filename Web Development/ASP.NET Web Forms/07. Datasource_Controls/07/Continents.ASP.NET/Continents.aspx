<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Continents.aspx.cs" Inherits="Continents.Continents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Continents</title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--continents--%>
            <asp:EntityDataSource ID="EntityDataSource1" runat="server"
                ConnectionString="name=ContinentDBEntities"
                DefaultContainerName="ContinentDBEntities"
                EntitySetName="Continents">
            </asp:EntityDataSource>

            <asp:ListBox ID="lbContinents" runat="server"
                DataSourceID="EntityDataSource1"
                DataTextField="Name" DataValueField="Id"
                Rows="10" AutoPostBack="True" />
            <%--countries--%>
            <asp:EntityDataSource ID="EntityDataSource2" runat="server"
                ConnectionString="name=ContinentDBEntities"
                DefaultContainerName="ContinentDBEntities"
                EntitySetName="Countries"
                Where="it.Continent_Id=@ContiID"
                EnableDelete="True" EnableInsert="True" EnableUpdate="True"
                EnableFlattening="False">
                <WhereParameters>
                    <asp:ControlParameter Name="ContiID" Type="Int32"
                        ControlID="lbContinents" />
                </WhereParameters>
            </asp:EntityDataSource>

            <asp:GridView ID="grdCountries" runat="server"
                DataSourceID="EntityDataSource2"
                AutoGenerateColumns="False" DataKeyNames="Id"
                AllowPaging="True" AllowSorting="True"
                PageSize="5"
                OnRowCommand="grdCountries_RowCommand"
                OnRowDeleting="grdCountries_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" />
                    <asp:ImageField DataImageUrlField="Id" DataImageUrlFormatString="~/ImageHttpHandler.ashx?id={0}" HeaderText="Flag">
                        <ControlStyle Height="100px" Width="100px" />
                    </asp:ImageField>
                    <asp:TemplateField HeaderText="Logo Upload">
                        <ItemTemplate>
                            <asp:FileUpload ID="fileupload" runat="server" />
                            <%--OnClick="upload_Click"--%>
                            <asp:Button ID="Upload" runat="server"
                                Font-Bold="true" Text="Upload"
                                CommandName="Upload" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
            <%--towns--%>
            <asp:EntityDataSource ID="EntityDataSource3" runat="server"
                EnableInsert="True" EnableUpdate="True" EnableDelete="True"
                ConnectionString="name=ContinentDBEntities"
                DefaultContainerName="ContinentDBEntities"
                EntitySetName="Towns"
                EnableFlattening="false"
                Where="it.Country_Id=@CountryID">
                <WhereParameters>
                    <asp:ControlParameter Name="CountryID" Type="Int32"
                        ControlID="grdCountries" />
                </WhereParameters>
                <InsertParameters>
                    <asp:ControlParameter Name="Id" ControlID="grdCountries" Type="Int32" />
                </InsertParameters>
            </asp:EntityDataSource>

            <asp:ListView ID="lvTowns" runat="server"
                DataSourceID="EntityDataSource3"
                DataKeyNames="Id"
                ItemType="Continents.Town"
                InsertItemPosition="None"
                OnItemInserted="ListViewTowns_ItemInserted">

                <LayoutTemplate>
                    <span runat="server" id="itemPlaceholder" />
                    <div class="pagerLine">
                        <asp:Button ID="ButtonInsertTown" Text="Insert" runat="server"
                            OnClick="ButtonInsertTown_Click" />
                        |
                    <asp:DataPager ID="DataPagerTowns" runat="server" PageSize="4">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="True"
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowLastPageButton="True"
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                    </div>
                </LayoutTemplate>

                <EmptyDataTemplate>
                    <div>No data was returned.</div>
                </EmptyDataTemplate>

                <ItemTemplate>
                    <div class="item">
                        Name: <%#: Item.Name %>
                        <br />
                        Population: <%#: Item.Population %>
                        <br />
                        <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" />
                    </div>
                </ItemTemplate>

                <EditItemTemplate>
                    <div class="editItem">
                        Name:
                    <asp:TextBox ID="TextBoxName" runat="server" Text='<%# Bind("Name") %>' />
                        <br />
                        Population:
                    <asp:TextBox ID="TextBoxPopulation" runat="server" Text='<%# Bind("Population") %>' />
                        <br />
                        <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                    </div>
                </EditItemTemplate>

                <InsertItemTemplate>
                    <div class="insertItem">
                        Name:
                    <asp:TextBox ID="TextBoxName" runat="server" Text='<%# Bind("Name") %>' />
                        <br />
                        Population:
                    <asp:TextBox ID="TextBoxPopulation" runat="server" Text='<%# Bind("Population") %>' />
                        <br />
                        <asp:Button ID="ButtonInsert" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Clear" />
                    </div>
                </InsertItemTemplate>

            </asp:ListView>

            <%--<asp:DataPager ID="lvDataPager" runat="server" PagedControlID="lvTowns" PageSize="5">
                <Fields>
                    <asp:NumericPagerField ButtonType="Link" />
                </Fields>
            </asp:DataPager>--%>
        </div>
    </form>
</body>
</html>
