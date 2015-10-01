<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ReceiptPage.aspx.cs" Inherits="Bankomat2._0.ReceiptPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centrera">
        <p>

            <asp:Label ID="LabelSorry" class="litespace" runat="server" Text="Tyvärr har vi slut på papper!"></asp:Label>

        </p>
        <p>

            <asp:Button ID="ButtonMenu" class="labelbuttons greybut" runat="server" OnClick="Menu_Click" Text="Tillbaka till menyn" />

        </p>
    </div>
</asp:Content>
