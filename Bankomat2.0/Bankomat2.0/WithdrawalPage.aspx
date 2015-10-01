<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="WithdrawalPage.aspx.cs" Inherits="Bankomat2._0.WithdrawalPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="litespace centrera">
        <h2 class="litespace">Ta ut pengar</h2>
        <p class="litespace">Tryck på knapparna för +  &  -  för respektive valör för att justera belopp att ta ut!</p>
    </div>
    <div class="centrera">
        <div>
            <asp:Button ID="Reduce100" runat="server" class="sedelpadd roundbuttminus" Text="-" OnClick="Reduce100_Click1" />
            <asp:Image ID="img100" runat="server" class="sedelpadd" ImageUrl="~/images/100 kronor ny sedel 1.jpg" Width="200px" />
            <asp:Button ID="Add100" runat="server" class="sedelpadd roundbuttplus" OnClick="Add100_Click" Text="+" />
        </div>
        <div>
            <asp:Button ID="Reduce500" runat="server" CssClass="sedelpadd roundbuttminus" OnClick="Reduce500_Click" Text="-" />
            <asp:Image ID="img500" runat="server" CssClass="sedelpadd" ImageUrl="~/images/500 kronor ny sedel 1.jpg" Width="200px" />
            <asp:Button ID="Add500" runat="server" CssClass="sedelpadd roundbuttplus" OnClick="Add500_Click" Text="+" />
        </div>
        <br />
        <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
        <br />

    </div>
    <div class="centrera">
        Uttagssumma:
    <asp:Button ID="SaldoVisning" class="labelbuttons greybut" runat="server" Text="0" />
    </div>
    <div class="centrera">
       <asp:Button ID="Avbryt" runat="server" class="labelbuttons greybut"  Text="Avbryt" OnClick="Avbryt_Click" />
         <asp:Button ID="Saldo" runat="server" class="labelbuttons greybut" OnClick="Saldo_Click" Text="SnabbSaldo" />        
         <asp:Button ID="TagUtSumma" class="labelbuttons greybut" runat="server" OnClick="TagUtSumma_Click" Text="TA UT" />
    </div>
    
</asp:Content>
