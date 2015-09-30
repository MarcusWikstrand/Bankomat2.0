<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Bankomat2._0.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="makeblock">
        <div class="centrera">
            <asp:Label ID="lblHeader" runat="server" Text="Ange din PIN-kod" Visible="False"></asp:Label>
        </div>
        <div class="centrera">
        <asp:TextBox ID="PIN" runat="server" OnTextChanged="TextBox1_TextChanged" Visible="False" class="labelbuttons"></asp:TextBox>
        <br />
        <asp:Label ID="lblWrongPIN" runat="server" ForeColor="#FF1919" Text="Felaktig PIN kod" Visible="False"></asp:Label>
        </div>
        <div class="centrera">
            <asp:Button ID="Button1" runat="server" class="labelbuttons greybut" Text="1" Visible="False" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" class="labelbuttons greybut" Text="2" TabIndex="2" Visible="False" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" class="labelbuttons greybut" Text="3" Visible="False" OnClick="Button3_Click" />
        </div>
        <div class="centrera">
            <asp:Button ID="Button4" runat="server" class="labelbuttons greybut" Text="4" Visible="False" OnClick="Button4_Click" />
            <asp:Button ID="Button5" runat="server" class="labelbuttons greybut" Text="5" Visible="False" OnClick="Button5_Click" />
            <asp:Button ID="Button6" runat="server" class="labelbuttons greybut" Text="6" Visible="False" OnClick="Button6_Click" />
        </div>
        <div class="centrera">
            <asp:Button ID="Button7" runat="server" class="labelbuttons greybut" Text="7" Visible="False" OnClick="Button7_Click" />
            <asp:Button ID="Button8" runat="server" class="labelbuttons greybut" Text="8" Visible="False" OnClick="Button8_Click" />
            <asp:Button ID="Button9" runat="server" class="labelbuttons greybut" Text="9" Visible="False" OnClick="Button9_Click" />
        </div>
        <div class="literight">
            <asp:Button ID="Button11" runat="server" class="labelbuttons greybut" Text="#" Visible="True" />
        <asp:Button ID="Button10" runat="server" class="labelbuttons greybut" Text="0" Visible="False" OnClick="Button10_Click" />
        <asp:Button ID="Backspace" runat="server" class="labelbuttons yellowbut" Text="&lt;-" Visible="False" OnClick="Backspace_Click" />

        <asp:Button ID="ButtonConfirm" runat="server" class="labelbuttons greenbut" Text="OK" OnClick="ButtonConfirm_Click" Visible="False" />
        <asp:Button ID="ButtonCancel" runat="server" class="labelbuttons redbut" Text="Avbryt" OnClick="ButtonCancel_Click" Visible="False" />
        </div>
    </div>
    <div class="centrera">
        <asp:Label ID="lblInsertCard" runat="server" Text="Stoppa in ditt kort:"></asp:Label>
    </div>
    <div class="centrera radpaddy">
        v
    </div>
    <div class="centrera radpaddy">
        v
    </div>
    <div class="centrera radpaddy">
        v
    </div>
    <div class="centrera radpaddy">
        v
    </div>
    <div class="centrera">
        <asp:DropDownList ID="DropDownListCards" class="kortin" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Selected="True">Välj ett Kort!</asp:ListItem>
            <asp:ListItem>55555</asp:ListItem>
            <asp:ListItem>66666</asp:ListItem>
            <asp:ListItem>77777</asp:ListItem>
            <asp:ListItem>88888</asp:ListItem>

        </asp:DropDownList>
</asp:Content>
