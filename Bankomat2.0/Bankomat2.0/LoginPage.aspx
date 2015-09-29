<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Bankomat2._0.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style2">

        <asp:Label ID="Label1" runat="server" Text="Ange din PIN-kod:"></asp:Label>
        <input id="PasswordButtonPIN" class="auto-style1" draggable="true" type="password" dir="ltr" /><asp:Button ID="ButtonConfirm" runat="server" Text="Bekräfta" />
        <asp:Button ID="ButtonCancel" runat="server" Text="Avbryt" />
    </div>
</asp:Content>
