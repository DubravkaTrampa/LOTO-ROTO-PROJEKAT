<%@ Page Title="" Language="C#" MasterPageFile="~/MasterStrana.Master" AutoEventWireup="true" CodeBehind="Cigla.aspx.cs" Inherits="LotoRotoProjekat.Cigla" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
    	canvas { background: #eee; }
    </style>

<canvas id="myCanvas" width="730" height="420" style="float:left;margin-left:400px;margin-top:50px;margin-bottom: 450px;"></canvas>

    <script src="javascript/cigle.js"></script>
</asp:Content>
