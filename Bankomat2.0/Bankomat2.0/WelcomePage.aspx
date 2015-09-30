<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="WelcomePage.aspx.cs" Inherits="Bankomat2._0.WelcomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="centrera" >
       <h2> Välkommen till Bankomaten 2.0!</h2>
        <p>Inled din upplevelse genom att trycka på knappen "KÖR"!
    </div>
    <div class= "centrera">
        <asp:Button ID="ToLogin" runat="server" class="labelbuttons" Text="KÖR!" OnClick="ToLogin_Click" />
    </div>



</asp:Content>
