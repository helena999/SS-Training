<%@ Page Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="Manage-Department.aspx.cs" Inherits="Manage_Department" %>
<%@ Register Src="includes/ucRightMenu.ascx" TagName="ucRightMenu" TagPrefix="uc1" %>
<asp:Content ID="cMainContent" runat="server" ContentPlaceHolderID="cphMain">
    <div class="title">Manage Department Details<br /><br /></div>
        <div style="text-align:center"><asp:Label ID="lblMessage" runat="server"></asp:Label></div>
        <div style="text-align:right"><asp:Button ID="btnSave" runat="server" CssClass="buttonBlue" Text="Add Department" style="width:100px" OnClick="btnSave_Click" /></div>
        <asp:GridView ID="gvMaster" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Solid" BorderColor="#000000" Width="100%" OnRowCommand="gvMaster_RowCommand" OnRowDataBound="gvMaster_RowDataBound" OnRowDeleting="gvMaster_RowDeleting" AllowPaging="True" OnPageIndexChanging="gvMaster_PageIndexChanging">
            
            <Columns>
                <asp:BoundField DataField="DepartmentName" HeaderText="Department Name">
                <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbEdit" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("DepartmentId") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="50px" HorizontalAlign="Center"  />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbDelete" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("DepartmentId") %>'></asp:LinkButton>
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