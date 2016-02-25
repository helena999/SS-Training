<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Employee Management System</title>
<link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="frmMain" runat="server">
<div id="container_wrapper">
	<div class="spacer"></div>
<div id="container">
<div id="top"></div>
  <div id="header">
      <div id="inner_header">
        <div id="site_title">Employee Management System</div>
          <div id="site_slogan">Version 1.0</div>
      </div>
  </div>
  
    <div id="left_column">
 		<div class="text_area" align="justify">
        <div class="title" style="text-align:center">Employee Management System</div>
        <center><img src="images/mainpic.jpg" /></center>
        </div>
      </div>
	
    <div id="right_column">
       <div class="section_box" align="justify">
  <div class="subtitle">Members Area</div>
    <table cellpadding="3" cellspacing="3" width="100%" border="0">
    <tr>
    <td>Username</td>
    <td><asp:TextBox ID="txtUsername" runat="server" CssClass="input100"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Password</td>
    <td><asp:TextBox ID="txtPassword" runat="server" CssClass="input100" TextMode="Password"></asp:TextBox></td>
    </tr>
    <tr>
    <td colspan="2" align="center"><asp:Button ID="btnLogin" runat="server" CssClass="buttonBlue" Text="Login" OnClick="btnLogin_Click" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername"
            Display="None" ErrorMessage="Please enter Username"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
            Display="None" ErrorMessage="Please enter Password"></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" />
    </td>
    </tr>
    <tr>
    <td colspan="2" align="center"><asp:label ID="lblMessage" runat="server" /></td>
    </tr>
    </table>
    </div>
    <br />
    <div class="section_box">
      <div class="subtitle">For Support and Queries</div>
        Email : <a href="mailto:shyamsrinivas@gmail.com">shyamsrinivas@gmail.com</a>
        Web : <a href="http://www.shyamsrinivas.com" target="_blank">www.shyamsrinivas.com</a>
        Mobile : +91 97890 62700
    </div>
    <br />
    </div>
    <div id="footer">
    Designed and Developed by <a href="http://www.shyamsrinivas.com" target="_blank">Shyam Srinivas</a>
    </div>
</div>
<div class="spacer"></div>
</div>
</form>
</body>
</html>
