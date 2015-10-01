<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="WaitingPage.aspx.cs" Inherits="Bankomat2._0.WaitingPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centrera">
        <h2 class="litespace">Dina sedlar räknas!
        </h2>
        <p class="litespace">Detta kan ta några sekunder. Varför inte berika din dag med citatet nedan?</p>
        <p>

            <asp:TextBox ID="TextBoxQuote" class="litespace" runat="server" Enabled="False" TextMode="MultiLine" Width="100%" Wrap="False"></asp:TextBox>

        </p>


    </div>
</asp:Content>
