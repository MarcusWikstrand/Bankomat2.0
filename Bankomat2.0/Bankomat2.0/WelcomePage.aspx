<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="WelcomePage.aspx.cs" Inherits="Bankomat2._0.WelcomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div>
        <br />
        <asp:Button ID="ToLogin" runat="server" Text="Börja fejkomat upplevelse" OnClick="ToLogin_Click" />
    </div>    
    
</asp:Content>
