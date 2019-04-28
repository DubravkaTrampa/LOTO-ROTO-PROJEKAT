<%@ Page Title="" Language="C#" MasterPageFile="MasterStrana.Master" AutoEventWireup="true" CodeBehind="TestStranica.aspx.cs" Inherits="LotoRotoProjekat.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

           <!--TESTOVI ZA KOLO-->
    <div>
        <asp:Button class="btn btn-indigo" ID="buttonZapocniKolo" Text="Zapocni kolo" runat="server" Width="160px" OnClick="buttonZapocniKolo_Click"/>
            <asp:Label ID="unos_trenutnog_datuma" runat="server" Text="Unesite trenutni datum"></asp:Label>
            <asp:TextBox id="PlaceHolder_trenutni_datum"  required="required" runat="server" ></asp:TextBox >

         <asp:Button class="btn btn-indigo" ID="buttonZavrsiKolo" EnableViewState = true Text="Zavrsi kolo" runat="server" Width="160px" OnClick="buttonZavrsiKolo_Click"/>

    </div>

</asp:Content>
