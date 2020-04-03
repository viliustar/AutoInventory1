<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AutoInventory1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div>
            <h2>Inventory</h2>
            <p>Please upload a csv input file:</p>
            <asp:FileUpload ID="Upload" runat="server" ToolTip="Please upload a CSV file" />
            <asp:Button ID="UploadButton" Text="Submit" OnClick="UploadButton_Click" runat="server" />
            
            <asp:Panel ID="Inventories" runat="server" Visible="false">
                <asp:DataGrid ID="CurrentInventory" runat="server">
                    <HeaderStyle Font-Bold="true" />
                    <Columns>
                        <asp:BoundColumn DataField="Type" HeaderText="Inventory"></asp:BoundColumn>
                    </Columns>
                </asp:DataGrid>

                <asp:DataGrid ID="EndDayInventory" runat="server">
                    <HeaderStyle Font-Bold="true" />
                    <Columns>
                        <asp:BoundColumn DataField="Type" HeaderText="End Day Inventory"></asp:BoundColumn>
                    </Columns>
                </asp:DataGrid>

                <div style="clear: both;"></div>
                <asp:Button ID="EndDayButton" Text="End Day" OnClick="EndDayButton_Click" runat="server" />
            </asp:Panel>
        </div>
    </div>

</asp:Content>
