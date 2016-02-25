<%@ Page Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="Manage-Employee-Trainings-Add.aspx.cs" Inherits="Manage_Employee_Trainings_Add" %>
<%@ Register Src="includes/ucRightMenu.ascx" TagName="ucRightMenu" TagPrefix="uc1" %>
<asp:Content ID="cMainContent" runat="server" ContentPlaceHolderID="cphMain">
    <div class="title" style="text-align:center"><asp:Label ID="lblTraining" runat="server"></asp:Label></div>
    <div class="title">Name : <asp:Label ID="lblEmployeeName" runat="server"></asp:Label></div>
    <hr style="border-style:dotted; border-color:#CDCDCD" />
        <table cellpadding="5" cellspacing="5" border="0" width="450" align="center">
        <tr>
        <td colspan="2" align="center"><asp:label ID="lblMessage" runat="server" /></td>
        </tr>
        <tr>
        <td>
            Start Date</td>
        <td><asp:TextBox ID="txtStartDate" runat="server" CssClass="input300"></asp:TextBox>&nbsp;<a href="javascript:NewCal('<%=txtStartDate.ClientID %>','mmddyyyy')"><img src="images/cal.gif" width="16" height="16" border="0" alt="Pick a date"></a>
            </td>
        </tr>
            <tr>
                <td>
                    End Date</td>
                <td>
                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="input300"></asp:TextBox>&nbsp;<a href="javascript:NewCal('<%=txtEndDate.ClientID %>','mmddyyyy')"><img src="images/cal.gif" width="16" height="16" border="0" alt="Pick a date"></a></td>
            </tr>
            <tr>
                <td valign="top">
                    Training</td>
                <td>
                    <asp:TextBox ID="txtTrainings" runat="server" CssClass="input300" Height="100px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top">
                    Effectiveness</td>
                <td>
                    <asp:TextBox ID="txtEffectiveness" runat="server" CssClass="input300" Height="100px" TextMode="MultiLine"></asp:TextBox></td>
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