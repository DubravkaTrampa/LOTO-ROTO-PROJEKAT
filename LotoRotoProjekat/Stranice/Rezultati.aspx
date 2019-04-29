<%@ Page Title="" Language="C#" MasterPageFile="MasterStrana.Master" AutoEventWireup="true" CodeBehind="Rezultati.aspx.cs" Inherits="LotoRotoProjekat.Rezultati" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="/stil/generator_stil.css" rel="stylesheet" />
    <link href="/stil/lopte_dobitna.css" rel="stylesheet" />
    <link href="../stil/rezultati.css" rel="stylesheet" />
    <script src="/javascript/generator_izvlacenja.js"></script>
    <div class="container-fluid">
        <div>
            <input class="btn btn-indigo"style="width:188px;margin-left:70px;background-color:#910b70 !important;" type=button value='Dobitna kombinacija' onClick="lotto(); StOp()">
               
            <div class="wrap" style="float:right; margin-right:100px;">
              <section class="stage">
                    <figure class="ball">
                      <span class="number" style="font-size:64px;" id="loptica_1" data-number="">&nbsp;</span>
                    </figure>
              </section>
              <section class="stage">
                    <figure class="ball">
                      <span class="number" style="font-size:64px;" id="loptica_2" data-number="">&nbsp;</span>
                    </figure>
              </section>
              <section class="stage">
                    <figure class="ball">
                      <span class="number" style="font-size:64px;" id="loptica_3" data-number="">&nbsp;</span>
                    </figure>
              </section>
              <section class="stage">
                    <figure class="ball">
                      <span class="number" style="font-size:64px;" id="loptica_4" data-number="">&nbsp;</span>
                    </figure>
              </section>
                <section class="stage">
                    <figure class="ball">
                      <span class="number" style="font-size:64px;" id="loptica_5" data-number="">&nbsp;</span>
                    </figure>
              </section>
                <section class="stage">
                    <figure class="ball">
                      <span class="number" style="font-size:64px;" id="loptica_6" data-number="">&nbsp;</span>
                    </figure>
              </section>
                <section class="stage">
                    <figure class="ball">
                      <span class="number" style="font-size:64px;" id="loptica_7" data-number="">&nbsp;</span>
                    </figure>
              </section>
            </div>
            <!--IZVESTAJI-->

                <!--Main container-->
    <main>
    <section  class="text-center"style="margin-left:0px;margin-right:280px;">
      
      <div class="row" style="width:1200px;height:auto">

              <!--Grid column-->
              <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">

                  <!--Card-->
                  <div class="card testimonial-card" style="float:left;">

                      <!--Bacground color-->
                      <div class="card-up purple-gradient" style="height:60px;">
                      </div>

                      <div class="card-body"  style="color:#275196;">
            <h4 style="text-align:center;"><strong>FOND</strong></h4>
        <hr />
            <h4 class="horizontalno">Ukupno uplaćeno:</h4>
                <asp:Label ID="LabelUkupnoUplaceno" class="dejavu" runat="server" Text="1.000.000.000 dinara"></asp:Label>
        <hr />
            <h4 class="horizontalno">Preneseni fond:</h4>
                <asp:Label ID="LabelPreneseniFond" class="dejavu" runat="server" Text="50.000 dinara"></asp:Label>
        <hr />
            <h4 class="horizontalno">Ukupan iznos fonda:</h4>
                <asp:Label ID="LabelUkupanIznosFonda" class="dejavu" runat="server" Text="1.050.000 dinara"></asp:Label>
        <hr />
            <h4 class="horizontalno">Cena tiketa:</h4>
                <asp:Label ID="LabelCenaTiketa" class="dejavu" runat="server" Text="100 dinara"></asp:Label>
        <hr />    
            <h4 class="horizontalno">Uplaćeno tiketa:</h4>
                <asp:Label ID="LabelUplacenoTiketa" class="dejavu" runat="server" Text="10.000"></asp:Label>
        <hr />
           <h4 class="horizontalno">Izvučeno dobitaka:</h4>
                <asp:Label ID="LabelIzvucenoDobitaka" class="dejavu" runat="server" Text="60"></asp:Label>


                      </div>
                       <div class="card-up purple-gradient" style="height:60px;" >
                      </div>
                  </div>
                  <!--/.Card-->

              </div>
              <!--Grid column-->

          </div>
              <!--Grid column-->
        </section>
         <section  class="text-center"style="margin-left:280px;margin-right:280px;">
      
      <div class="row" style="width:1200px;height:auto">

              <!--Grid column-->
              <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">

                  <!--Card-->
                  <div class="card testimonial-card">

                      <!--Bacground color-->
                      <div class="card-up purple-gradient" style="height:60px;">
                      </div>

                      <div class="card-body"  style="color:#275196;">
           
            <h4 style="text-align:center;"><strong>VRSTA DOBITAKA:</strong></h4>
        <hr />
            <h4 class="horizontalno">Sedam pogodaka:</h4>
                <asp:Label ID="LabelSedmica" class="dejavu" runat="server" Text="1"></asp:Label>
        <hr />
            <h4 class="horizontalno">Iznos:</h4>
                <asp:Label ID="LabelSedmicaIznos" class="dejavu" runat="server" Text="1.000.000"></asp:Label>
        <hr />
            <h4 class="horizontalno">Šest pogodaka:</h4>
                <asp:Label ID="LabelSestica" class="dejavu" runat="server" Text="2"></asp:Label>
                <asp:Label ID="LabelSesticaIznos" class="dejavu" runat="server" Text="80.000"></asp:Label>
        <hr />
            <h4 class="horizontalno">Pet pogodaka:</h4>
                <asp:Label ID="LabelPetica" class="dejavu" runat="server" Text="7"></asp:Label>
                <asp:Label ID="LabelPeicaIznos" class="dejavu" runat="server" Text="5.000"></asp:Label>
        <hr />     
             <h4 class="horizontalno">Četiri pogotka:</h4>
                <asp:Label ID="LabelCetvorka" class="dejavu" runat="server" Text="50"></asp:Label>
                <asp:Label ID="LabelCetvorkaIznos" class="dejavu" runat="server" Text="500"></asp:Label>

                      </div>
                       <div class="card-up purple-gradient" style="height:60px;" >
                      </div>
                  </div>
                  <!--/.Card-->

              </div>
              <!--Grid column-->

          </div>
              <!--Grid column-->
        </section>
  </main>
  <!--Main layout-->

  </div>
  </div>

    <!--DOVDE-->
   
</asp:Content>
