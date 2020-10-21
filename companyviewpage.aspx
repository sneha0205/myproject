<%@ Page Language="C#" AutoEventWireup="true" CodeFile="companyviewpage.aspx.cs" Inherits="companyviewpage" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <style type="text/css">
        .modelback
        {
            background-color:Black;
            filter:alpha(opacity=90) !important;
            opacity:0.6 ! important;
            z-index:20;
           
        }
          .modelpopup
        {
            padding:20px 0px 24px 10px;
            position:relative;
            width:462px;
            height:383px;
            background-color:White;
            top: 78px;
            left: 43px;
        }
        
        </style>
</head>
<body>
    <h1>Company View Page</h1>
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" DataKeyNames="Id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" 
                    ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Status" HeaderText="Status" 
                    SortExpression="Status" />
               <asp:TemplateField HeaderText="" ItemStyle-Width="250">
            <ItemTemplate>
                <asp:Button ID="show" runat="server" Text="Show" Enabled='<%# Eval("Status").ToString() == "1" ? true : false %>' />
                 <asp:Button ID="app_status" runat="server" Text="Approve/Disapprove" CommandName="app_satusclick" CommandArgument='<%# Eval("Id") %>'  oncommand="appstatus_Command"/>
                <asp:Label ID="hid_popup" runat="server" Text='<%# Eval("id") %>' Visible="false"></asp:Label>
          <center>
        <asp:Panel ID="Panel2"  runat="server" Width="250px" Height="50px" CssClass="modelpopup">
           <asp:Button ID="But_approve" runat="server" Text="Approve" BackColor="Red" ForeColor="White" Height="30px" CommandName="app_statusclick" CommandArgument='<%# Eval("Id") %>'  oncommand="appstatus_Command" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="But_disapprove" runat="server" Text="Disapprove" BackColor="Red" Height="30px" ForeColor="White" CommandName="dis_statusclick" CommandArgument='<%# Eval("Id") %>'  oncommand="disstatus_Command"  />
            <asp:Button ID="But_cancle" runat="server" Text="Close" BackColor="Red" ForeColor="White" Height="30px" />
         </asp:Panel>
        <cc1:ModalPopupExtender runat="server" ID="popup" CancelControlID="But_cancle" TargetControlID="app_status" PopupControlID="panel2" BackgroundCssClass="modelback">
        </cc1:ModalPopupExtender>
         </center>
        <center>
        <asp:Panel ID="Panel1"  runat="server" Width="350px" Height="200px" CssClass="modelpopup">
            <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource2">
            <ItemTemplate>
                FileName:
                <asp:LinkButton ID="FileNameLabel" runat="server" Text='<%# Eval("FileName") %>' CommandName="link_click" CommandArgument='<%# Eval("FileName") %>'  oncommand="link_Command" />
                <br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:sampleConnectionString %>" 
            SelectCommand="SELECT [FileName] FROM [FileMaster] WHERE ([CompanyId] = @CompanyId)">
             <SelectParameters>
                <asp:ControlParameter ControlID="hid_popup" Name="CompanyId" PropertyName="Text" 
                    Type="Int32" />
            </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <br />
          <asp:Button ID="But_close" runat="server" Text="Close" BackColor="Red" ForeColor="White" Height="30px" />
        </asp:Panel>
        <cc1:ModalPopupExtender runat="server" ID="ModalPopupExtender2" CancelControlID="But_close" TargetControlID="show" PopupControlID="panel1" BackgroundCssClass="modelback">
        </cc1:ModalPopupExtender>
       </center>

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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:sampleConnectionString %>" 
            SelectCommand="SELECT * FROM [CompanyMaster]"></asp:SqlDataSource>
    </div>
   
    </form>
</body>
</html>
