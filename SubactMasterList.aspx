﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubactMasterList.aspx.cs" Inherits="vdbsdemo.SubactMasterList" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                
                <Columns>
                 <asp:TemplateField ShowHeader="False">
                 <ItemTemplate>
                <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="fre_list"
                    Text="Frequency_List" CommandArgument='<%# Eval("pk") %>' OnCommand="GridView1_Command" />
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
      
    </div>
    </form>
</body>
</html>
