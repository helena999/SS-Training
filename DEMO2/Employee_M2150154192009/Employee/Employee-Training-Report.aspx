<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Employee-Training-Report.aspx.cs" Inherits="Employee_Training_Report" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
<h3 style="margin:0px">
    Employee In Job / Off Job Trainings</h3><hr style="border:dotted 1px #333333" />
</td>
</tr>
<tr>
<td>
<table cellpadding="5" cellspacing="0" width="100%" border="0">
<tr>
<td><strong>Name</strong></td>
<td>: <asp:Label ID="lblEmployeeName" runat="server"></asp:Label></td>
<td ><strong>EMP ID</strong></td>
<td>: <asp:Label ID="lblEmpId" runat="server"></asp:Label></td>
<td><strong>Department</strong></td>
<td>: <asp:Label ID="lblDepartment" runat="server"></asp:Label></td>
</tr>
<tr>
<td><strong>Designation</strong></td>
<td>: <asp:Label ID="lblDesignation" runat="server"></asp:Label></td>
<td><strong>DOJ</strong></td>
<td>: <asp:Label ID="lblDOJ" runat="server"></asp:Label></td>
<td><strong>Degree</strong></td>
<td>: <asp:Label ID="lblDegree" runat="server"></asp:Label></td>
</tr>
</table>
</td>
</tr>
<tr>
<td>
<asp:GridView id="gvOnJob" runat="server" Width="100%" GridLines="Both" ForeColor="Black" CellPadding="4" BorderStyle="None" BorderColor="#CCCCCC" AutoGenerateColumns="False" BackColor="White" BorderWidth="1px">
            <Columns>
                <asp:TemplateField HeaderText="In Job Trainings">
                    <ItemTemplate>
                        <b>Date : </b><%# getDurationDate(Convert.ToDateTime(Eval("StartDate")), Convert.ToDateTime(Eval("EndDate")))%><br /><br />
                        <b>Training Program : </b><asp:Label ID="lblTraining" runat="server" Text='<%# Eval("TrainingDetails") %>'></asp:Label><br /><br />
                        <b>Effectiveness : </b><asp:Label ID="lblTEffectiveness" runat="server" Text='<%# Eval("Effectiveness") %>'></asp:Label><br /><br />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
               
            </Columns>
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right"  />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White"  />
            <HeaderStyle BackColor="#666666" Font-Bold="True" ForeColor="White"  />
            <FooterStyle BackColor="#CCCC99" ForeColor="Black"  />
        </asp:GridView>
</td>
</tr>
<tr>
<td>
<asp:GridView id="gvOffJob" runat="server" Width="100%" GridLines="Both" ForeColor="Black" CellPadding="4" BorderStyle="None" BorderColor="#CCCCCC" AutoGenerateColumns="False" BackColor="White" BorderWidth="1px">
            <Columns>
                <asp:TemplateField HeaderText="Off Job Trainings">
                    <ItemTemplate>
                        <b>Date : </b><%# getDurationDate(Convert.ToDateTime(Eval("StartDate")), Convert.ToDateTime(Eval("EndDate")))%><br /><br />
                        <b>Training Program : </b><asp:Label ID="lblTraining" runat="server" Text='<%# Eval("TrainingDetails") %>'></asp:Label><br /><br />
                        <b>Effectiveness : </b><asp:Label ID="lblTEffectiveness" runat="server" Text='<%# Eval("Effectiveness") %>'></asp:Label><br /><br />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
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
