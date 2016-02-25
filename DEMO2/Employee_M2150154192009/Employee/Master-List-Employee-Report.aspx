<%@ Page Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="Master-List-Employee-Report.aspx.cs" Inherits="Master_List_Employee_Report" %>
<%@ Register Src="includes/ucRightMenu.ascx" TagName="ucRightMenu" TagPrefix="uc1" %>
<asp:Content ID="cMainContent" runat="server" ContentPlaceHolderID="cphMain">
    <div class="title" style="text-align:center">
        List of Employees Report</div><br /> 
        <div style="text-align:right"><a href="Master-List-Employee-Report-Print.aspx" target="_blank">Print Master List</a></div>
        <asp:GridView ID="gvMaster" runat="server" AutoGenerateColumns="False"
            BorderColor="#000000" BorderStyle="Solid" CellPadding="4" ForeColor="#333333"
            GridLines="Both" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lblEmpID" runat="server" Text='<%# "EMP" + Eval("EmployeeId").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center"  />
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Employee Name">
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Designation" HeaderText="Designation">
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                 <asp:TemplateField HeaderText="Department">
                    <ItemTemplate>
                        <asp:Label ID="lblDepartment" runat="server" Text='<%# getDepartmentName(Convert.ToInt32(Eval("DepartmentId"))) %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Trainings">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkTrainings" runat="server" NavigateUrl='<%# "Employee-Training-Report.aspx?EmpId=" + Eval("EmployeeId") %>' Text="View" Target="_blank"></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle Width="50px" HorizontalAlign="Center"  />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
               
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <AlternatingRowStyle BackColor="#EFF3FB" />
        </asp:GridView>
    
    
    

    
    
    
</asp:Content>
<asp:Content ID="cRightMenu" runat="server" ContentPlaceHolderID="cphRight">
    <uc1:ucRightMenu ID="UcRightMenu1" runat="server" />
</asp:Content>
