<%@ Page Title="" Language="C#" MasterPageFile="~/MasterStrana.Master" AutoEventWireup="true" CodeBehind="IgrajTiket.aspx.cs" Inherits="LotoRotoProjekat.IgrajTiket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="stil/cigle.css" rel="stylesheet" />
    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="panel1" runat="server"><ContentTemplate>
    <asp:Label ID="prikazKombinacijeTiketa" runat="server" Text="" style="border-collapse:collapse;width: 280px;height:50px;font-size:24px;margin-left:15px;background-color:#FFFFFF;color:blue;" ></asp:Label>

      <div class="btn-indigo" style="width:350px;margin-left:30px;margin-top:20px;"> 
          <asp:Button class="btn btn-indigo" ID="buttonClick1" Text="click function" runat="server" OnClick="buttonClick_Click1" Width="340px"/>
      
          <asp:GridView ID="GridViewNov" style="width: 320px;height:100px;margin-left:16px;background-color:#ffffff;text-align:center;font-size:14px;color:#b200ff;" runat="server" Visible="False"
      OnRowCommand="GridViewNov_RowCommand"  ForeColor="#0a10b5" BackColor="#66ffff"  AutoGenerateColumns="False">
      
      <Columns>
        
        <asp:ButtonField HeaderText = "" DataTextField="Prvo" CommandName="Prvo"/>
        <asp:ButtonField HeaderText = "" DataTextField="Drugo" CommandName="Drugo"/>
        <asp:ButtonField HeaderText = "" DataTextField="Trece" CommandName="Trece"/>
        <asp:ButtonField HeaderText = "" DataTextField="Cetvrto" CommandName="Cetvrto"/>
        <asp:ButtonField HeaderText = "" DataTextField="Peto" CommandName="Peto"/>
        <asp:ButtonField HeaderText = "" DataTextField="Sesto" CommandName="Sesto"/>
        <asp:ButtonField HeaderText = "" DataTextField="Sedmo" CommandName="Sedmo"/>
        <asp:ButtonField HeaderText = "" DataTextField="Osmo" CommandName="Osmo"/>
        <asp:ButtonField HeaderText = "" DataTextField="Deveto" CommandName="Deveto"/>
        <asp:ButtonField HeaderText = "" DataTextField="Deseto" CommandName="Deseto"/>
        <asp:ButtonField HeaderText = "" DataTextField="Jedanaesto" CommandName="Jedanaesto"/>
        <asp:ButtonField HeaderText = "" DataTextField="Dvanaesto" CommandName="Dvanaesto"/>
        <asp:ButtonField HeaderText = "" DataTextField="Trinaesto" CommandName="Trinaesto"/>

      </Columns>
            
        </asp:GridView>

    <asp:Button class="btn btn-indigo" ID="Button10" runat="server" OnClick="Button10_Click" Text="Potvrdi" Width="340px" />

      </div></ContentTemplate></asp:UpdatePanel>      

          <div class="card-body" "ciglica">
              <a href="Cigla.aspx" target="_blank" class="btn btn-indigo">DOK ČEKATE NA IZVLAČENJE!</a>
            </div>
</asp:Content>
