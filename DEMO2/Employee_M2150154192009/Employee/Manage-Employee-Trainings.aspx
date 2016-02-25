<%@ Page Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="Manage-Employee-Trainings.aspx.cs" Inherits="Manage_Employee_Trainings" %>
<%@ Register Src="includes/ucRightMenu.ascx" TagName="ucRightMenu" TagPrefix="uc1" %>
<asp:Content ID="cMainContent" runat="server" ContentPlaceHolderID="cphMain">
    <div class="title" style="text-align:center"><asp:Label ID="lblTraining" runat="server"></asp:Label></div>
    <div class="title">Name : <asp:Label ID="lblEmployeeName" runat="server"></asp:Label></div>
    <hr style="border-style:dotted; border-color:#CDCDCD" />
        <table cellpadding="0" cellspacing="0" width="100%" border="0">
        <tr>
        <td align="left"><asp:Label ID="lblMessage" runat="server"></asp:Label></td>
        <td align="right">
            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CssClass="buttonBlue"
                OnClick="btnCancel_Click" Text="Back" />
            <asp:Button ID="btnSave" runat="server" CssClass="buttonBlue" Text="Add Trainings" style="width:100px" OnClick="btnSave_Click" /></td>
        </tr>
        </table>
        <asp:GridView ID="gvMaster" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Solid" BorderColor="#000000" Width="100%" OnRowCommand="gvMaster_RowCommand" OnRowDataBound="gvMaster_RowDataBound" OnRowDeleting="gvMaster_RowDeleting" AllowPaging="True" OnPageIndexChanging="gvMaster_PageIndexChanging" PageSize="15">
            <Columns>
                <asp:TemplateField HeaderText="Trainings">
                    <ItemTemplate>
                        <b>Date : </b><%# getDurationDate(Convert.ToDateTime(Eval("StartDate")), Convert.ToDateTime(Eval("EndDate")))%><br />
                        <asp:Label ID="lblTraining" runat="server" Text='<%# Eval("TrainingDetails") %>'></asp:Label>      
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbEdit" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("TrainingId") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="50px" HorizontalAlign="Center"  />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbDelete" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("TrainingId") %>'></asp:LinkButton>
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
