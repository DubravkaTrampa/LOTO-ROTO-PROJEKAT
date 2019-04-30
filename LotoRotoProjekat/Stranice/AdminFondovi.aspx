<%@ Page Title="" Language="C#" MasterPageFile="MasterStrana.Master" AutoEventWireup="true" CodeBehind="AdminFondovi.aspx.cs" Inherits="LotoRotoProjekat.AdminFondovi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeholderAdminDropdown" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
          <asp:DropDownList ID="fondIzvestaj" runat="server">
            </asp:DropDownList>
     <asp:TextBox ID="TextBoxNazivFonda" runat="server" ToolTip="Naziv fonda">Naziv</asp:TextBox>
     <asp:TextBox ID="TextBoxOpisFonda" runat="server" ToolTip="Opis Fonda">Opis</asp:TextBox>
    <asp:TextBox ID="TextBoxBrojRacunaFonda" runat="server" ToolTip="Broj racuna fonda">Br. racuna</asp:TextBox>
    <asp:Button ID="BtnPotvrdi" runat="server" Text="Potvrdi" OnClick="BtnPotvrdi_Click" />
</asp:Content>
