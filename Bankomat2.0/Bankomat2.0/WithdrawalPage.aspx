<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="WithdrawalPage.aspx.cs" Inherits="Bankomat2._0.WithdrawalPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:ImageButton ID="Reduce100" runat="server" />
        <asp:Image ID="img100" runat="server" />
        <asp:ImageButton ID="Add100" runat="server" /><br />


        <asp:ImageButton ID="Reduce500" runat="server" />
        <asp:Image ID="img500" runat="server" />
        <asp:ImageButton ID="Add500" runat="server" />

    </div>
    <div>
    <asp:Button ID="SaldoVisning" runat="server" Text="SaldoVisning" />
    <asp:Button ID="Saldo" runat="server" OnClick="Saldo_Click" Text="Saldo" />

    </div>
</asp:Content>
