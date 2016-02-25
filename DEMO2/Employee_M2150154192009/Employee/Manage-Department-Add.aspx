<%@ Page Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="Manage-Department-Add.aspx.cs" Inherits="Manage_Department_Add" %>
<%@ Register Src="includes/ucRightMenu.ascx" TagName="ucRightMenu" TagPrefix="uc1" %>
<asp:Content ID="cMainContent" runat="server" ContentPlaceHolderID="cphMain">
    <div class="title">Add/Edit Department Details<br /><br /></div>
        <table cellpadding="5" cellspacing="5" border="0" width="450" align="center">
        <tr>
        <td colspan="2" align="center"><asp:label ID="lblMessage" runat="server" /></td>
        </tr>
        <tr>
        <td>Department</td>
        <td><asp:TextBox ID="txtName" runat="server" CssClass="input300"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                ErrorMessage="*" Font-Bold="True" Font-Size="Small">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
        <td colspan="2" align="center">
        <asp:Button ID="btnSave" runat="server" CssClass="buttonBlue" Text="Save" OnClick="btnSave_Click" />
        <asp:Button ID="btnUpdate" runat="server" CssClass="buttonBlue" Text="Update" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnCancel" runat="server" CssClass="buttonBlue" Text="Cancel" CausesValidation="False" OnClick="btnCancel_Click" />
        </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="cRightMenu" runat="server" ContentPlaceHolderID="cphRight">
    <uc1:ucRightMenu ID="UcRightMenu1" runat="server" />
</asp:Content>