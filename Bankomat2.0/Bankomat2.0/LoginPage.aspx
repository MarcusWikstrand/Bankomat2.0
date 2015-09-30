<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Bankomat2._0.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="makeblock">

        <asp:Label ID="lblHeader" runat="server" Text="Ange din PIN-kod" Visible="False"></asp:Label>
        <br />
        <asp:TextBox ID="PIN" runat="server" OnTextChanged="TextBox1_TextChanged" Visible="False" Width="80px"></asp:TextBox>
        <asp:Label ID="lblWrongPIN" runat="server" ForeColor="#FF1919" Text="Felaktig PIN kod" Visible="False"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" Text="1" Width="30px" Visible="False" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="2" Width="30px" TabIndex="2" Visible="False" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="3" Width="30px" Visible="False" OnClick="Button3_Click" />
        <br />
        <asp:Button ID="Button4" runat="server" Text="4" Width="30px" Visible="False" OnClick="Button4_Click" />
        <asp:Button ID="Button5" runat="server" Text="5" Width="30px" Visible="False" OnClick="Button5_Click" />
        <asp:Button ID="Button6" runat="server" Text="6" Width="30px" Visible="False" OnClick="Button6_Click" />
        <br />
        <asp:Button ID="Button7" runat="server" Text="7" Width="30px" Visible="False" OnClick="Button7_Click" />
        <asp:Button ID="Button8" runat="server" Text="8" Width="30px" Visible="False" OnClick="Button8_Click" />
        <asp:Button ID="Button9" runat="server" Text="9" Width="30px" Visible="False" OnClick="Button9_Click" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button10" runat="server" Text="0" Width="30px" Visible="False" OnClick="Button10_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Backspace" runat="server" Text="&lt;-" Width="30px" Visible="False" OnClick="Backspace_Click" />
        <br />
        <asp:Button ID="ButtonConfirm" runat="server" Text="Bekräfta" OnClick="ButtonConfirm_Click" Visible="False" Width="90px"/>
        <br />
        <asp:Button ID="ButtonCancel" runat="server" Text="Avbryt" Width="90px" OnClick="ButtonCancel_Click" Visible="False"/>
        
    </div>
    <asp:Label ID="lblInsertCard" runat="server" Text="För in ditt kort:"></asp:Label>
&nbsp;<asp:DropDownList ID="DropDownListCards" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>55555</asp:ListItem>
        <asp:ListItem>66666</asp:ListItem>
        <asp:ListItem>77777</asp:ListItem>
        <asp:ListItem>88888</asp:ListItem>
        </asp:DropDownList>
    <asp:Button ID="MakeItSo" runat="server" OnClick="MakeItSo_Click" Text="Engage!" />
</asp:Content>
