<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="Bankomat2._0.MainMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centrera">
        <div class ="litespace">
            <h2 class="litespace">Välkommen in!</h2>
            <p class="litespace">Välj vad du vill göra genom att trycka på knapparna nedan! </p> 
        </div>
        <div>
    <asp:Button ID="Saldo" runat="server" class="superknapp" Text="Saldo" OnClick="Saldo_Click" /> 
            </div>
        <div>
    <asp:Button ID="Uttag" runat="server" class="superknapp"  Text="Uttag" OnClick="Uttag_Click" /> 
            </div>
        <div>
    <asp:Button ID="Avbryt" runat="server" class="superknapp"  Text="Avbryt" OnClick="Avbryt_Click" />
    </div>
    </div>
</asp:Content>
