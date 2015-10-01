<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SaldoPage.aspx.cs" Inherits="Bankomat2._0.SaldoPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centrera litespace">
        <h2 class="litespace">Se saldo</h2>
        <p class="litespace">Välj konto att se saldo för:</p>
    </div>
    <div class="centrera">
        <asp:ListBox ID="ListOfAccounts" runat="server" CssClass="labelbuttons" OnSelectedIndexChanged="ListOfAccounts_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
        <asp:Button ID="Back" runat="server" CssClass="labelbuttons greybut" OnClick="Back_Click" Text="Tillbaka" />
        <div>
            <asp:Label ID="lblShowAccount" runat="server" Text="Ditt saldo är:" Visible="False"></asp:Label>
            <asp:Label ID="lblSummaSaldo" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblValuta" runat="server" Text="SEK" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="lblTransactions" runat="server" Text="De fem senaste transaktionerna" Visible="False"></asp:Label>
            <br />
            <asp:ListBox ID="ListTransactions" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Visible="False"></asp:ListBox>
        </div>
        </div>
</asp:Content>
