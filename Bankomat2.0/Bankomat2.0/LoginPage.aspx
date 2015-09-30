<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Bankomat2._0.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 258px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="makeblock">

        <asp:Label ID="Label1" runat="server" Text="Ange din PIN-kod:" Visible="False"></asp:Label>
        <asp:TextBox ID="PIN" runat="server" OnTextChanged="TextBox1_TextChanged" Visible="False"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <asp:Button ID="Button3" runat="server" Text="Button" />
        <br />
        <asp:Button ID="ButtonConfirm" runat="server" Text="Bekräfta" OnClick="ButtonConfirm_Click" Visible="False" />
        <asp:Button ID="ButtonCancel" runat="server" Text="Avbryt" />
        
    </div>
    För in ditt kort:
    <asp:DropDownList ID="DropDownListCards" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>55555</asp:ListItem>
        <asp:ListItem>66666</asp:ListItem>
        <asp:ListItem>77777</asp:ListItem>
        <asp:ListItem>88888</asp:ListItem>
        </asp:DropDownList>
</asp:Content>
