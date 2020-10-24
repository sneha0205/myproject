<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ID : <asp:TextBox ID="Text_id" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Id" ControlToValidate="Text_id"></asp:RequiredFieldValidator>
            <br />
            <br />
            Vender Name&nbsp; :&nbsp; <asp:TextBox ID="Text_vendername" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Vender Name" ControlToValidate="Text_vendername"></asp:RequiredFieldValidator>
           
            <br />
            <br />
            <asp:Button ID="But_login" runat="server" Text="LogIn" OnClick="But_login_Click" />
        </div>
    </form>
</body>
</html>
