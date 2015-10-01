<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="FinishedTransactionPage.aspx.cs" Inherits="Bankomat2._0.FinishedTransactionPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centrera">
        <h2 class="litespace">Vänligen ta dina sedlar!</h2>
        <p class="litespace">Vill du nu:</p>
        <div>
            <asp:Button ID="ButtonKvitto" runat="server" class="superknapp" Text="Få Kvitto?" OnClick="ButtonKvitto_Click" />
        </div>
        <div>
            <asp:Button ID="ButtonSaldo" runat="server" class="superknapp" Text=" Se Saldo" OnClick="Saldo_Click" />
        </div>
        <div>
            <asp:Button ID="ButtonUttag" runat="server" class="superknapp" Text="Nytt Uttag" OnClick="Uttag_Click" />
        </div>
        <div>
            <asp:Button ID="ButtonAvsluta" runat="server" class="superknapp" Text="Avsluta" OnClick="Avbryt_Click" />
        </div>
    </div>
</asp:Content>
