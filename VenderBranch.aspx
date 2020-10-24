<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VenderBranch.aspx.cs" Inherits="WebApplication1.VenderBranch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="pk" HeaderText="pk" InsertVisible="False" ReadOnly="True" SortExpression="pk" />
                    <asp:BoundField DataField="Vendorid" HeaderText="Vendorid" SortExpression="Vendorid" />
                    <asp:BoundField DataField="VBranchid" HeaderText="VBranchid" SortExpression="VBranchid" />
                    <asp:BoundField DataField="UpdateDate" HeaderText="UpdateDate" SortExpression="UpdateDate" />
                    <asp:BoundField DataField="UpdateUserId" HeaderText="UpdateUserId" SortExpression="UpdateUserId" />
                    <asp:BoundField DataField="Valid" HeaderText="Valid" SortExpression="Valid" />
                    <asp:TemplateField ShowHeader="False">
                 <ItemTemplate>
                <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="subtact_list"
                    Text="SubtactMaster_List" CommandArgument='<%# Eval("VBranchid")+","+ Eval("pk") %>' OnCommand="GridView1_Command" />
               </ItemTemplate>
                 </asp:TemplateField>
                     <asp:TemplateField ShowHeader="False">
                 <ItemTemplate>
                <asp:Button ID="But" runat="server" CausesValidation="false" CommandName="sub_list"
                    Text="Frequancy" CommandArgument='<%# Eval("VBranchid")+","+ Eval("pk") %>' OnCommand="GridView_Command" />
               </ItemTemplate>
                 </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DummyDBConnectionString %>" SelectCommand="SELECT * FROM [tbl_VendorBranchMapping] WHERE ([Vendorid] = @Vendorid)">
                <SelectParameters>
                    <asp:SessionParameter Name="Vendorid" SessionField="id" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
