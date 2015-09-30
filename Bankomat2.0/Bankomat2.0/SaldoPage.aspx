<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SaldoPage.aspx.cs" Inherits="Bankomat2._0.SaldoPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Välj Konto att se Saldo för:</p>
    <p>
        &nbsp;</p>
        <asp:ListBox ID="ListOfAccounts" runat="server" Width="215px" OnSelectedIndexChanged="ListOfAccounts_SelectedIndexChanged"></asp:ListBox>
    <asp:Button ID="Back" runat="server" OnClick="Back_Click" Text="Tillbaka" />
    <br />
    <asp:Label ID="lblShowAccount" runat="server" Text="Ditt saldo är:" Visible="False"></asp:Label>
    <asp:Label ID="lblSummaSaldo" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblValuta" runat="server" Text="SEK" Visible="False"></asp:Label>
</asp:Content>
