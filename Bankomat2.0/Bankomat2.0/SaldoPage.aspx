<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SaldoPage.aspx.cs" Inherits="Bankomat2._0.SaldoPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centrera litespace">
        <p>Välj konto att se saldo för:</p>
    </div>
    <div class="centrera">
        <asp:ListBox ID="ListOfAccounts" runat="server" CssClass="labelbuttons" OnSelectedIndexChanged="ListOfAccounts_SelectedIndexChanged"></asp:ListBox>
        <asp:Button ID="Back" runat="server" CssClass="labelbuttons yellowbut" OnClick="Back_Click" Text="Tillbaka" />
        <div>
            <asp:Label ID="lblShowAccount" runat="server" Text="Ditt saldo är:" Visible="False"></asp:Label>
            <asp:Label ID="lblSummaSaldo" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblValuta" runat="server" Text="SEK" Visible="False"></asp:Label>
        </div>
</asp:Content>
