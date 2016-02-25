<%@ Page Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="Manage-Employee.aspx.cs" Inherits="Manage_Employee" %>
<%@ Register Src="includes/ucRightMenu.ascx" TagName="ucRightMenu" TagPrefix="uc1" %>
<asp:Content ID="cMainContent" runat="server" ContentPlaceHolderID="cphMain">
    <div class="title">Manage Employees Details<br /><br /></div>
        <div style="text-align:center"><asp:Label ID="lblMessage" runat="server"></asp:Label></div>
        <div style="text-align:right">
            <asp:CheckBox ID="chkStatus" runat="server" Text="View Resigned Employees" AutoPostBack="True" OnCheckedChanged="chkStatus_CheckedChanged" />
            <asp:Button ID="btnSave" runat="server" CssClass="buttonBlue" Text="Add Employee" style="width:100px" OnClick="btnSave_Click" /></div>
        <asp:GridView ID="gvMaster" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Solid" BorderColor="#000000" Width="100%" OnRowCommand="gvMaster_RowCommand" OnRowDataBound="gvMaster_RowDataBound" OnRowDeleting="gvMaster_RowDeleting" AllowPaging="True" OnPageIndexChanging="gvMaster_PageIndexChanging" PageSize="15">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lblEmpID" runat="server" Text='<%# "EMP" + Eval("EmployeeId").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="40px"  />
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Employee Name">
                <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Trainings">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbOnJob" Text="In Job" CommandName="OnJob" CommandArgument='<%# Eval("EmployeeId") %>'></asp:LinkButton>
                        | <asp:LinkButton runat="server" ID="lbOffJob" Text="Off Job" CommandName="OffJob" CommandArgument='<%# Eval("EmployeeId") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="110px" HorizontalAlign="Center"  />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbEdit" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("EmployeeId") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="50px" HorizontalAlign="Center"  />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbDelete" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("EmployeeId") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="50px" HorizontalAlign="Center"  />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" CssClass="pager" />
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
