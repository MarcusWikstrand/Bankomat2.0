<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Bankomat2._0.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="makeblock">

        <asp:Label ID="Label1" runat="server" Text="Ange din PIN-kod:"></asp:Label>
        <input id="PasswordButtonPIN" class="labelbuttons" draggable="true" type="password" dir="ltr" />
        <asp:Button ID="ButtonConfirm" runat="server" class="labelbuttons", "greenbut" Text="OK" />
        <asp:Button ID="ButtonCancel" runat="server" Text="Avbryt" class="labelbuttons", "redbut"/>

    </div>
</asp:Content>
