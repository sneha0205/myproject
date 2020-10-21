<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyMaster.aspx.cs" Inherits="CompanyMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
        <h1>Company Master Page</h1>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label_name" runat="server" Text="Name : "></asp:Label>
        <asp:TextBox ID="name" runat="server" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidaton_name" runat="server" ErrorMessage="Enter company name" ControlToValidate="name"></asp:RequiredFieldValidator>
         <br />
        <br />&nbsp;<asp:FileUpload ID="FileUpload1" runat="server" Width="203px" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_fileuplode" runat="server" Display="Dynamic" ErrorMessage="Please uplode file" ControlToValidate="FileUpload1"></asp:RequiredFieldValidator>
        <br />
        <br />
    
        <asp:Button ID="btn_submit" runat="server" Text="Submit" 
            onclick="btn_submit_Click" />
        <br />
         <br />
          <br />
         <asp:LinkButton ID="Button1" runat="server" Text="Company_View_Page" PostBackUrl="~/companyviewpage.aspx" CausesValidation="false"/>

    </div>
    </form>
</body>
</html>
