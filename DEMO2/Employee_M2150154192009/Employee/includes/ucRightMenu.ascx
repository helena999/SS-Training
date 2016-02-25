<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucRightMenu.ascx.cs" Inherits="includes_ucRightMenu" %>
<ul class="menu">
    <div id="divAdmin" runat="server">
    <li><a href="Manage-Login.aspx">Manage Login Details</a></li>
    <li><a href="Manage-Department.aspx">Manage Deparments</a></li>
    <li><a href="Manage-Employee.aspx">Manage Employee Details</a></li>
    </div>
    <li><a href="Master-List-Employee-Report.aspx">List of Employees Report</a></li>
    <li><a href="Employee-Service-Report.aspx">Employees Service Report</a></li>
    <li><asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click">Logout</asp:LinkButton></li>
</ul>
<br />
<div class="section_box">
      <div class="subtitle">Birthday Alerts</div>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <asp:DataList ID="dlBirthday" runat="server" Width="100%">
        <ItemTemplate>
        <b><asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label></b><br />
        <asp:Label ID="lblDOB" runat="server" Text='<%# Convert.ToDateTime(Eval("DOB")).ToString("MMM dd, yyyy") %>'></asp:Label><br /><hr style="border:dotted 1px #333333" />
        </ItemTemplate>
        </asp:DataList>
        <br />
</div>
<br />
<div class="section_box">
      <div class="subtitle">Total No. of Employees</div>
        <br />
        <center><h1><asp:Label ID="lblEmpCount" runat="server"></asp:Label></h1></center>
</div>