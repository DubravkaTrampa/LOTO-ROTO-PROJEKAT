<%@ Page Title="" Language="C#" MasterPageFile="MasterStrana.Master" AutoEventWireup="true" CodeBehind="Rezultati.aspx.cs" Inherits="LotoRotoProjekat.Rezultati" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../stil/rezultati_stil.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <link href="/stil/generator_stil.css" rel="stylesheet" />
    <link href="/stil/lopte_dobitna.css" rel="stylesheet" />
    <link href="../stil/rezultati.css" rel="stylesheet" />
    <script src="/javascript/generator_izvlacenja.js"></script>

    <div class="container-fluid">
        <div>
            <input class="btn btn-indigo konte_loptice" type=button value='Dobitna kombinacija' onClick="lotto(); StOp()">
               
            <div class="wrap" style="float:right; margin-right:100px;">
              <section class="stage">
                    <figure class="ball">
                      <span class="number" style="font-size:64px;color:#910b70;" id="loptica_1" data-number="">&nbsp;</span>
                    </figure>
              </section>
              <section class="stage">
                    <figure class="ball">
                      <span class="number" style="font-size:64px;color:#910b70;" id="loptica_2" data-number="">&nbsp;</span>
                    </figure>
              </section>
              <section class="stage">
                    <figure class="ball">
                      <span class="number" style="font-size:64px;color:#910b70;" id="loptica_3" data-number="">&nbsp;</span>
                    </figure>
              </section>
              <section class="stage">
                    <figure class="ball">
                      <span class="number" style="font-size:64px;color:#910b70;" id="loptica_4" data-number="">&nbsp;</span>
                    </figure>
              </section>
                <section class="stage">
                    <figure class="ball">
                      <span class="number" style="font-size:64px;color:#910b70;" id="loptica_5" data-number="">&nbsp;</span>
                    </figure>
              </section>
                <section class="stage">
                    <figure class="ball">
                      <span class="number" style="font-size:64px;color:#910b70;" id="loptica_6" data-number="">&nbsp;</span>
                    </figure>
              </section>
                <section class="stage">
                    <figure class="ball">
                      <span class="number" style="font-size:64px;color:#910b70;" id="loptica_7" data-number="">&nbsp;</span>
                    </figure>
              </section>
            </div>
            </div>
        </div>
            <!--IZVESTAJI-->       
    <asp:Button ID="BtnZapocniKolo" class="btn btn-indigo" style="margin-right:10px;margin-left:350px;background-color:#910b70 !important;" runat="server" OnClick="BtnZapocniKolo_Click" Text =" Započni kolo"/>
    <asp:Button ID="BtnZavrsiKolo" class="btn btn-indigo" style="margin-left:10px;background-color:#910b70 !important;" runat="server" OnClick="BtnZavrsiKolo_Click" Text =" Završi kolo"/>
   <!--KARTICE-->
    <section class="details-card" style="padding: 100px 0;background:none !important;">
        <div class="container" style="margin-left:70px;">
            <div class="row">
                <!--PRVA KARTICA-->
                <div class="col-md-4">
                    <div class="card-content" style="width:420px;margin-right:20px;">
                        <div class="card-img">
                            <img src="../slike/kartica_loptice.jpg" alt="">                  
                             </div>
                                 <div class="card-desc">
                                     <h3>FOND</h3>
                                        <hr />

                              <div class="glavni">

                                <div class="header">

                                    <h4 class="horizontalno">Preneseni fond:</h4>
                                    <h4 class="horizontalno">Ukupan iznos fonda:</h4>
                                    <h4 class="horizontalno">Cena tiketa:</h4>
                                    <h4 class="horizontalno">Uplaćeno tiketa:</h4>
                                    <h4 class="horizontalno">Izvučeno dobitaka:</h4>
                                </div>
                              <div class="label">

                                    <h4 ID="rezultatiPreneseniFond" class="horizontalno" runat="server" Text=""></h4>
                                    <h4 ID="rezultatiUkupanIznosFonda" class="horizontalno" runat="server" Text=""></h4>
                                    <h4 ID="rezultatiCenaTiketa" class="horizontalno" runat="server" Text=""></h4>
                                    <h4 ID="rezultatiUplacenoTiketa" class="horizontalno" runat="server" Text=""></h4>
                                    <h4 ID="rezultatiIzvucenoDobitaka" class="horizontalno" runat="server" Text=""></h4>
                              </div>
                          </div>
                        </div>
                      </div>
                    </div>
     <!--./PRVA KARTICA-->

                <!--DRUGA KARTICA-->
                <div class="col-md-4">
                    <div class="card-content" style="width:420px;height:457px;margin-left:70px;margin-right:50px;">
                        <div class="card-img">
                            <img src="../slike/kartica_loptice.jpg" alt="">                  
                        </div>
                            <div class="card-desc">
                                <h3>VRSTA DOBITAKA</h3>
                                    <hr />
                                     <div class="glavni">
                                        <div class="header">
                                                <h4 class="horizontalno">Sedam pogodaka:</h4>
                                                <h4 class="horizontalno">Šest pogodaka:</h4>
                                                <h4 class="horizontalno">Pet pogodaka:</h4>
                                                <h4 class="horizontalno">Četiri pogotka:</h4>
                                        </div>
                                           <div class="label">
                                                <h4 ID="rezultatiSedamPogodaka" class="horizontalno" runat="server" Text=""></h4>
                                                <h4 ID="rezultatiSestPogodaka" class="horizontalno" runat="server" Text=""></h4>
                                                <h4 ID="rezultatiPetPogotka" class="horizontalno" runat="server" Text=""></h4>
                                                <h4 ID="rezultatiCetiriPogotka" class="horizontalno" runat="server" Text=""></h4>
                                          </div>
                                       </div>
                                    </div>
                                </div>
                            </div>
     <!--./DRUGA KARTICA-->

                 <!--TRECA KARTICA-->
                <div class="col-md-4">
                    <div class="card-content" style="width:420px;height:457px;margin-left:140px;">
                        <div class="card-img">
                            <img src="../slike/kartica_loptice.jpg" alt="">                  
                                </div>
                            <div class="card-desc">
                                <h3>ISPLAĆENO</h3>
                                    <hr />
                                     <div class="glavni">
                                         <div class="header">
                                                <h4 class="horizontalno">Sedmice:</</h4>
                                                <h4 class="horizontalno">Šestice:</h4>
                                                <h4 class="horizontalno">Petice:</h4>
                                                <h4 class="horizontalno">Četvorke:</h4>

                                        </div>
                                           <div class="label">
                                                <h4 ID="rezultatIsplacenoSedmice" class="horizontalno" runat="server" Text=""></h4>
                                                <h4 ID="rezultatIsplacenoSestice" class="horizontalno" runat="server" Text=""></h4>
                                                <h4 ID="rezultatIsplacenoPetice" class="horizontalno" runat="server" Text=""></h4>
                                                <h4 ID="rezultatIsplacenoCetvorke" class="horizontalno" runat="server" Text=""></h4>
                                          </div>
                                     </div>
                                 </div>
                              </div>
                           </div>
      <!--./TRECA KARTICA-->
                </div>
            </div>
</section>

</asp:Content>
