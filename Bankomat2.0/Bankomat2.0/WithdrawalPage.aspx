﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="WithdrawalPage.aspx.cs" Inherits="Bankomat2._0.WithdrawalPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:ImageButton ID="Reduce100" runat="server" ImageUrl="~/images/minus.jpg" OnClick="Reduce100_Click" Width="100px"/>
        <asp:Image ID="img100" runat="server" ImageUrl="~/images/100 kronor ny sedel 1.jpg" Width="200px"/>
        <asp:ImageButton ID="Add100" runat="server" ImageUrl="~/images/plus.jpg" OnClick="Add100_Click" Width="100px"/><br />


        <asp:ImageButton ID="Reduce500" runat="server" ImageUrl="~/images/minus.jpg" OnClick="Reduce500_Click" Width="100px"/>
        <asp:Image ID="img500" runat="server" ImageUrl="~/images/500 kronor ny sedel 1.jpg" Width="200px"/>
        <asp:ImageButton ID="Add500" runat="server" ImageUrl="~/images/plus.jpg" OnClick="Add500_Click" Width="100px"/>

        <br />

    </div>
    <div>
        Uttagssumma:
    <asp:Button ID="SaldoVisning" runat="server" Text="0" />
        <asp:Button ID="TagUtSumma" runat="server" OnClick="TagUtSumma_Click" Text="Tag ut summa" />
    <asp:Button ID="Saldo" runat="server" OnClick="Saldo_Click" Text="Saldo" />

    </div>
</asp:Content>
