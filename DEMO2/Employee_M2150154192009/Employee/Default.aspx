<%@ Page Language="C#" MasterPageFile="~/default.master"AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Src="includes/ucRightMenu.ascx" TagName="ucRightMenu" TagPrefix="uc1" %>
<asp:Content ID="cMainContent" runat="server" ContentPlaceHolderID="cphMain">
        <div class="text_area" align="justify">
        <div class="title" style="text-align:center">Welcome to Employee Management System</div>
        <center><img src="images/mainpic.jpg" /></center>
        </div>
</asp:Content>
<asp:Content ID="cRightMenu" runat="server" ContentPlaceHolderID="cphRight">
    <uc1:ucRightMenu ID="UcRightMenu1" runat="server" />
</asp:Content>
