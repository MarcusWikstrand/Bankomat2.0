<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="FinishedTransactionPage.aspx.cs" Inherits="Bankomat2._0.FinishedTransactionPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centrera">
        <p>
            Ta dina sedlar!<br /> <br />Vill du:
        </p>
        <p>

            <asp:Button ID="ButtonKvitto" runat="server" Text="Kvitto" />

        </p>
        <p>

            <asp:Button ID="ButtonSaldo" runat="server" Text="Saldo" OnClick="Saldo_Click"/>

        </p>
        <p>

            <asp:Button ID="ButtonUttag" runat="server" Text="Uttag" OnClick="Uttag_Click"/>

        </p>
        <p>

            <asp:Button ID="ButtonAvsluta" runat="server" Text="Avsluta" OnClick="Avbryt_Click" />

        </p>
    </div>
</asp:Content>
