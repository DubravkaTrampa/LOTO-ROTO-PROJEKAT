<%@ Page Title="" Language="C#" MasterPageFile="MasterStrana.Master" AutoEventWireup="true" CodeBehind="IgrajTiket.aspx.cs" Inherits="LotoRotoProjekat.IgrajTiket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../stil/igraj_tiket_stil.css" rel="stylesheet" />
    <link href="stil/cigle.css" rel="stylesheet" />
    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>

        <div class="card-body" "ciglica">
              <a href="Cigla.aspx" target="_blank" class="btn btn-indigo" style="margin-left:470px;">DOK ČEKATE NA IZVLAČENJE!</a>
            </div>

            <asp:UpdatePanel ID="panel1" class="labela_prikaz_komb_panel" runat="server">
          <ContentTemplate >
            <asp:Label ID="LabelPrikazKombinacijeTiketa" runat="server" Text="" class="labela_prikaz_komb" ></asp:Label>

              <div class="btn-indigo izaberi_komb_dugme_div" style="padding-bottom:20px;"> 
                  <asp:Button class="btn btn-indigo izaberi_komb_dugme" ID="ButtonOtvoriTiket" Text="Izaberi kombinaciju" runat="server" OnClick="ButtonOtvoriTiket_Click"/>
      
                    <asp:GridView ID="GridViewNov" class="grid_nov" runat="server" Visible="False"
                        OnRowCommand="GridViewNov_RowCommand"  ForeColor="#0a10b5" BackColor="#ffffff"  AutoGenerateColumns="False">
      
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

                     <asp:Button class="btn btn-indigo potvrdi_komb_dugme" ID="BtnPotvrdiTiket" runat="server" OnClick="BtnPotvrdiTiket_Click" Text="Potvrdi"/>
                     
                     <asp:Button class="btn btn-indigo dodaj_rand_tik" ID="BtnDodajRandomTiket" runat="server" OnClick="BtnDodajRandomTiket_Click" Text="Uplati 5 tiketa" />
      
                  <div>
                      <h1 style="text-align:center;">MOJI TIKETI</h1>
                  <asp:GridView class="grid_moji_tiketi" ID="GridViewMojiTiketi" ForeColor="#0a10b5" BackColor="#ffffff" runat="server" >
                      
                      <Columns>

                      </Columns>
                  </asp:GridView>
                  </div>
   </ContentTemplate></asp:UpdatePanel>      

         
</asp:Content>
