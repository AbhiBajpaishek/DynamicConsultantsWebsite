<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CSS/changePasswordCSS.css" rel="stylesheet" />
    <link href="CSS/LoginCSS.css" rel="stylesheet" />
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="childCPH" Runat="Server">
    <div id="mainDiv">
        <center><img src="Images/DECLogo.png" style="margin-top:100px;" /></center>
        
          <div id="changePasswordPanelDiv">
                    <asp:TextBox ID="txtUser" runat="server" placeholder="Enter Username" CssClass="textBox"></asp:TextBox>
              &nbsp; &nbsp; 
              <asp:Label ID="lblUsernameError" runat="server"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtOldPassword" runat="server" placeholder="Enter Old Password" CssClass="textBox" TextMode="Password"></asp:TextBox>
              &nbsp; &nbsp; 
              <asp:Label ID="lblOldPassError" runat="server"></asp:Label>
              <br />
               <asp:TextBox ID="txtNewPassword" runat="server" placeholder="Create New Password" CssClass="textBox" TextMode="Password"></asp:TextBox>
              &nbsp; <asp:CheckBox ID="showHidePassword" runat="server"  Text="Show" ForeColor="White" OnCheckedChanged="showHidePassword_CheckedChanged"/>
              <br />
               <asp:TextBox ID="txtReNewPassword" runat="server" placeholder="Re-enter New Password" CssClass="textBox" TextMode="Password"></asp:TextBox>
                  <asp:Label ID="lblError" runat="server" ForeColor="White" ></asp:Label>
                    <br />
                  <br />
                    <asp:Button ID="btnChangePassword" runat="server" CssClass="btn" Text="Change Password" OnClick="btnLogin_Click" />
                    <br />
            </div>
    </div>
</asp:Content>

