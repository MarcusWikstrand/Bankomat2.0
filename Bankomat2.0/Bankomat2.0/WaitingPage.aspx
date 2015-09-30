<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="WaitingPage.aspx.cs" Inherits="Bankomat2._0.WaitingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centrera">
        <p>
            Dina sedlar räknas!
        </p>
        <p>
            
            <asp:TextBox ID="TextBoxQuote" runat="server" Enabled="False" TextMode="MultiLine" Width="100%" Wrap="False"></asp:TextBox>
            
        </p>


    </div>
</asp:Content>
