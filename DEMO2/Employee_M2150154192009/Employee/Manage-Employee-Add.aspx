<%@ Page Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="Manage-Employee-Add.aspx.cs" Inherits="Manage_Employee_Add" %>
<%@ Register Src="includes/ucRightMenu.ascx" TagName="ucRightMenu" TagPrefix="uc1" %>
<asp:Content ID="cMainContent" runat="server" ContentPlaceHolderID="cphMain">

    <div class="title">Add/Edit Employee Details<br /><br /></div>
        <table cellpadding="5" cellspacing="5" border="0" width="450" align="center">
        <tr>
        <td colspan="2" align="center">
            <asp:Image ID="imgPhoto" runat="server" Height="100px" Width="100px" /></td>
        </tr>
        <tr>
        <td>Name</td>
        <td><asp:TextBox ID="txtName" runat="server" CssClass="input300"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                ErrorMessage="*" Font-Bold="True" Font-Size="Small">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
        <td>
            Designation</td>
        <td><asp:TextBox ID="txtDesignation" runat="server" CssClass="input300"></asp:TextBox></td>
        </tr>
        <tr>
        <td>Degree</td>
        <td><asp:TextBox ID="txtDegree" runat="server" CssClass="input300"></asp:TextBox></td>
        </tr>
        <tr>
        <td>
            Department</td>
        <td>
            <asp:DropDownList ID="ddlDepartment" runat="server" Style="width: 300px">
            </asp:DropDownList></td>
        </tr>
            <tr>
                <td>
                    Joined Date</td>
                <td>
                    <asp:TextBox ID="txtDOJ" runat="server" CssClass="input300"></asp:TextBox>&nbsp;<a href="javascript:NewCal('<%=txtDOJ.ClientID %>','mmddyyyy')"><img src="images/cal.gif" width="16" height="16" border="0" alt="Pick a date"></a></td>
            </tr>
            <tr>
                <td>
                    Confirmed</td>
                <td>
                    <asp:TextBox ID="txtDOC" runat="server" CssClass="input300"></asp:TextBox>&nbsp;<a href="javascript:NewCal('<%=txtDOC.ClientID %>','mmddyyyy')"><img src="images/cal.gif" width="16" height="16" border="0" alt="Pick a date"></a></td>
            </tr>
            
            <tr>
                <td>
                    Status</td>
                <td><asp:DropDownList ID="ddlStatus" runat="server" Style="width: 300px">
                    <asp:ListItem Value="1">Employed</asp:ListItem>
                    <asp:ListItem Value="0">Resigned or Retired</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <strong>Personal Details</strong></td>
            </tr>
        <tr>
        <td>
            Date of Birth</td>
        <td><asp:TextBox ID="txtDOB" runat="server" CssClass="input300"></asp:TextBox>&nbsp;<a href="javascript:NewCal('<%=txtDOB.ClientID %>','mmddyyyy')"><img src="images/cal.gif" width="16" height="16" border="0" alt="Pick a date"></a></td>
        </tr>
        <tr>
        <td>
            Address</td>
        <td><asp:TextBox ID="txtAddress" runat="server" CssClass="input300"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td>
            City</td>
        <td><asp:TextBox ID="txtCity" runat="server" CssClass="input300"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td>
            State</td>
        <td><asp:TextBox ID="txtState" runat="server" CssClass="input300"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td>
            Zipcode</td>
        <td><asp:TextBox ID="txtZipcode" runat="server" CssClass="input300"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td>
            Phone</td>
        <td><asp:TextBox ID="txtPhone" runat="server" CssClass="input300"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td>
            Mobile</td>
        <td><asp:TextBox ID="txtMobile" runat="server" CssClass="input300"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td>
            Email</td>
        <td><asp:TextBox ID="txtEmail" runat="server" CssClass="input300"></asp:TextBox>
            </td>
        </tr>
            <tr>
                <td>
                    Photo</td>
                <td>
                    <asp:FileUpload ID="filePhoto" runat="server" CssClass="input300" /></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <strong>Comments or Remarks<asp:TextBox ID="txtPhoto" runat="server" Visible="false"></asp:TextBox></strong></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="txtBio" runat="server" style="height:70px; width:450px" TextMode="MultiLine"></asp:TextBox></td>
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