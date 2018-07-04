<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Dynamic Solutions
    </title>
    <link href="CSS/LoginCSS.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="mainDiv">
            <center><img src="Images/DECLogo.png" /></center>
              <div id="loginPanelDiv">
                <br />
                <br />
                    <asp:TextBox ID="txtUser" runat="server" placeholder="Enter Username" CssClass="textBox"></asp:TextBox>
                    <br /><br />
                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Enter Password" CssClass="textBox" TextMode="Password"></asp:TextBox>
                  <asp:Label ID="lblError" runat="server" ForeColor="White" ></asp:Label>
                    <br />
                  <br />
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn" Text="Log In" OnClick="btnLogin_Click" />
                    <br />
            </div>
        </div>
    </form>
</body>
</html>
