﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AdminRegistration.aspx.cs" Inherits="AdminRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CSS/adminRegistrationCSS.css" rel="stylesheet" />
    <link href="CSS/LoginCSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="childCPH" Runat="Server">
    <div id="mainPanel">
        <div id="registrationFormDiv">
            <table runat="server">
                <tr>
                    <td><asp:Label ID="lblName" runat="server">Name</asp:Label></td>
                    <td><asp:TextBox ID="txtName" runat="server" CssClass="textBox"></asp:TextBox></td>
                    <td><asp:Label ID="lblNameError" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblmail" runat="server">Enter E-mail</asp:Label></td>
                    <td><asp:TextBox ID="txtMail" runat="server" CssClass="textBox"></asp:TextBox></td>
                    <td><asp:Label ID="lblMailError" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblPassword" runat="server">Enter Password</asp:Label></td>
                    <td><asp:TextBox ID="txtPassword" runat="server" CssClass="textBox"></asp:TextBox></td>
                    <td><asp:Label ID="lblPasswordError" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblRePassword" runat="server">Re-enter Password</asp:Label></td>
                    <td><asp:TextBox ID="txtRePassword" runat="server" CssClass="textBox"></asp:TextBox></td>
                    <td><asp:Label ID="lblRePasswordError" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td><asp:Label ID="lblAge" runat="server">Enter Age</asp:Label></td>
                    <td><asp:DropDownList ID="ageDropDown" runat="server"></asp:DropDownList></td>
                    <td><asp:Label ID="lblAgeError" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td><asp:Label ID="lblGender" runat="server">Select Gender</asp:Label></td>
                    <td>
                        <asp:RadioButtonList ID="genderList" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem> Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td><asp:Label ID="lblGenderError" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td><asp:Button ID="btnRegister" runat="server" Text="Register/Update" CssClass="btn" OnClick="btnRegister_Click" /></td>
                </tr>
            </table>
        </div>

        <div id="dataGrid">
            <asp:GridView ID="registeredDataGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowEditing="registeredDataGridView_RowEditing" OnRowDeleting="registeredDataGridView_RowDeleting">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Edit" ShowHeader="True" Text="Edit" />
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete" ShowHeader="True" Text="Delete" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

