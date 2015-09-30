<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SaldoPage.aspx.cs" Inherits="Bankomat2._0.SaldoPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Välj Konto att se Saldo för:</p>
    <p>
        <asp:ListBox ID="ListOfAccounts" runat="server" Width="215px"></asp:ListBox>
    </p>
</asp:Content>
