<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Master-List-Employee-Report-Print.aspx.cs" Inherits="Master_List_Employee_Report_Print" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Employee Management System</title>
    <style type="text/css">
        body
        {
            margin:0;
	        padding:0;
	        line-height: 1.5em;
	        font-family: "Trebuchet MS", Verdana, Helvetica, Arial;
	        font-size: 12px;
	        color: #000000;
        }
     </style>
</head>
<body>
<form id="form1" runat="server">
<table cellpadding="5" cellspacing="5" width="700px" border="0" align="center">
<tr>
<td>
<hr style="border:dotted 1px #333333" />
</td>
</tr>
<tr>
<td align="center">
<h3 style="margin:0px">List of Employees</h3>
</td>
</tr>
<tr>
<td>
<hr style="border:dotted 1px #333333" />
</td>
</tr>
<tr>
<td>
<asp:GridView id="gvMaster" runat="server" Width="100%" GridLines="Both" ForeColor="Black" CellPadding="4" BorderStyle="None" BorderColor="#CCCCCC" AutoGenerateColumns="False" BackColor="White" BorderWidth="1px">
            <Columns>
                <asp:TemplateField HeaderText="EMP ID">
                    <ItemTemplate>
                        <asp:Label ID="lblEmpID" runat="server" Text='<%# "EMP" + Eval("EmployeeId").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center"  />
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Employee Name">
                    <HeaderStyle HorizontalAlign="Center"  />
                </asp:BoundField>
                <asp:BoundField DataField="Designation" HeaderText="Designation">
                    <HeaderStyle HorizontalAlign="Center"  />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Department">
                    <ItemTemplate>
                        <asp:Label ID="lblDepartment" runat="server" Text='<%# getDepartmentName(Convert.ToInt32(Eval("DepartmentId"))) %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DOB">
                    <ItemTemplate>
                        <asp:Label ID="lblDOB" runat="server" Text='<%# getFormatedDate(Convert.ToDateTime(Eval("DOB"))) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="75px" HorizontalAlign="Center"   />
                    <HeaderStyle HorizontalAlign="Center"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DOJ">
                    <ItemTemplate>
                        <asp:Label ID="lblDOJ" runat="server" Text='<%# getFormatedDate(Convert.ToDateTime(Eval("DOJ"))) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="75px" HorizontalAlign="Center"   />
                    <HeaderStyle HorizontalAlign="Center"  />
                </asp:TemplateField>
               
            </Columns>
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right"  />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White"  />
            <HeaderStyle BackColor="#666666" Font-Bold="True" ForeColor="White"  />
            <FooterStyle BackColor="#CCCC99" ForeColor="Black"  />
        </asp:GridView>
</td>
</tr>
</table>

    </form>
</body>
</html>
