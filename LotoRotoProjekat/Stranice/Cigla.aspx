<%@ Page Title="" Language="C#" MasterPageFile="MasterStrana.Master" AutoEventWireup="true" CodeBehind="Cigla.aspx.cs" Inherits="LotoRotoProjekat.Cigla" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="panel1" Visible="false" runat="server"><ContentTemplate>
     <style>
    	canvas { background: #eee; }
    </style>
    
<canvas id="myCanvas" width="730" height="420" style="float:left;margin-left:400px;margin-top:50px;margin-bottom: 450px;"></canvas>

    <script src="/javascript/cigle.js"></script>
        </ContentTemplate></asp:UpdatePanel>
    <asp:Button ID="cigle_pokreni" runat="server" OnClic="btnCiglePokreni" Text="Start" OnClick="cigle_pokreni_Click"></asp:Button>
</asp:Content>
