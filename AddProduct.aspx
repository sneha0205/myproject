<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masterpage.master" CodeFile="AddProduct.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <p class="style26">
        ADD PRODUCT <br /></p>
        Category * :<br />
        <asp:DropDownList ID="DropDownList_add_category" runat="server">
            <asp:ListItem Value="1" Text="Women's Fashion">Women's Fashion</asp:ListItem>
            <asp:ListItem Value="2" Text="Men's Fashion">Men's Fashion</asp:ListItem>
            <asp:ListItem Value="3" Text="Electronics">Electronics</asp:ListItem>
            <asp:ListItem Value="4" Text="Bags">Bags</asp:ListItem>
            <asp:ListItem Value="5" Text="Other">Other</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_add_category" runat="server" ErrorMessage="select Category" ControlToValidate="DropDownList_add_category"></asp:RequiredFieldValidator>
        <br />
        <br />
        Product Name* :<br />
        <asp:TextBox ID="add_productname" runat="server" Width="275px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_add_productname" runat="server" ErrorMessage="Enter product name" ControlToValidate="add_productname"></asp:RequiredFieldValidator>
        <br />
        <br />
        Description :<br />
        <asp:TextBox ID="add_productdescription" runat="server" Width="275px" 
            Height="51px" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        Initial Price* :<br />
        <asp:TextBox ID="add_initialprice" runat="server" Width="275px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_add_initialprice" runat="server" ErrorMessage="Enter amount" ControlToValidate="add_initialprice"></asp:RequiredFieldValidator>
        <br />
        <br />Auction End Date *:
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
       <br />
        <asp:TextBox ID="t1" runat="server" Width="147px"></asp:TextBox>
        <asp:Button ID="but_add_date" runat="server" Text="Date" 
            CausesValidation="False" />
      <cc1:CalendarExtender ID="cal" runat="server" BehaviorID="cal" TargetControlID="t1" Format="yyyy-MM-dd" PopupButtonID="but_add_date" PopupPosition="BottomRight">
        </cc1:CalendarExtender>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator_add_timeperiod" runat="server" ErrorMessage="Enter Auction Time Period" ControlToValidate="t1"></asp:RequiredFieldValidator>
        <br />
        <br />
      Auction End Time *:<br />
        <cc2:TimeSelector ID="TimeSelector1" runat="server" Height="24px" SelectedTimeFormat="Twelve">
        </cc2:TimeSelector>
        &nbsp;
        <br />
        image*&nbsp;
        :<br />
&nbsp;<asp:FileUpload ID="FileUpload1" runat="server" Width="203px" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_fileuplode" runat="server" Display="Dynamic" ErrorMessage="Please uplode image of product" ControlToValidate="FileUpload1"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="But_creatauction" runat="server" Text="Creat Auction" 
            onclick="But_creatauction_Click" />
        <br />
        <br />
        <br />
    
    </div>
    </asp:Content>
  
