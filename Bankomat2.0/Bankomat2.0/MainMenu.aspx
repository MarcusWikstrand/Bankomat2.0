<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="Bankomat2._0.MainMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:Button ID="Saldo" runat="server" Text="Saldo" OnClick="Saldo_Click" /> 
    <asp:Button ID="Uttag" runat="server" Text="Uttag" OnClick="Uttag_Click" /> 
    <asp:Button ID="Avbryt" runat="server" Text="Avbryt" OnClick="Avbryt_Click" />
    </div>
</asp:Content>
