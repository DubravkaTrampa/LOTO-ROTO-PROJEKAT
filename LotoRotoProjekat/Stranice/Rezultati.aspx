<%@ Page Title="" Language="C#" MasterPageFile="MasterStrana.Master" AutoEventWireup="true" CodeBehind="Rezultati.aspx.cs" Inherits="LotoRotoProjekat.Rezultati" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
<style>

    #glavni{

        display:flex;
        justify-content:center;
        align-items:center;

    }

    #header{

        display:flex;
        justify-content:center;
        align-items:flex-start;
        flex-direction:column;
        width:50%;


    }

    #label{

        display:flex;
        justify-content:center;
        align-items:center;
        flex-direction:column;
        width:50%;



    }


</style>



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
    <asp:Button ID="BtnZavrsiKolo" runat="server" OnClick="BtnZavrsiKolo_Click" Text =" Zavrsi kolo"/>
        <asp:Button ID="BtnZapocniKolo" runat="server" OnClick="BtnZapocniKolo_Click" Text =" Zapocni kolo"/>
   <!--KARTICE-->
    <section class="details-card" style="padding: 100px 0;background:none !important;">
        <div class="container" style="margin-left:70px;">
            <div class="row">
                <!--/PRVA KARTICA-->
                <div class="col-md-4">
                    <div class="card-content" style="width:420px;margin-right:20px;">
                        <div class="card-img">
                            <img src="../slike/kartica_loptice.jpg" alt="">                  
                        </div>
                        <div class="card-desc">
                            <h3>FOND</h3>
                                <hr />

                            <div id="glavni">

                                <div id="header">

                                    <h4 class="horizontalno">Ukupno uplaćeno:</h4>
                                    <h4 class="horizontalno">Preneseni fond:</h4>
                                    <h4 class="horizontalno">Ukupan iznos fonda:</h4>
                                    <h4 class="horizontalno">Cena tiketa:</h4>
                                    <h4 class="horizontalno">Uplaćeno tiketa:</h4>
                                    <h4 class="horizontalno">Izvučeno dobitaka:</h4>



                                </div>
                                <div id="label">

                                      <h4 ID="rezultatiUkupnoUplaceno" class="horizontalno" runat="server" Text=""></h4>
                                      <h4 ID="rezultatiPreneseniFond" class="horizontalno" runat="server" Text=""></h4>
                                      <h4 ID="rezultatiUkupanIznosFonda" class="horizontalno" runat="server" Text=""></h4>
                                      <h4 ID="rezultatiCenaTiketa" class="horizontalno" runat="server" Text=""></h4>
                                      <h4 ID="rezultatiUplacenoTiketa" class="horizontalno" runat="server" Text=""></h4>
                                      <h4 ID="rezultatiIzvucenoDobitaka" class="horizontalno" runat="server" Text=""></h4>
                                <%--    <div id="moj" runat="server"></div>--%>
                                    



                                     <%--<asp:Label ID="LabelUkupnoUplaceno" class="dejavu" runat="server" Text="1.000.000.000 dinara"></asp:Label>--%>
                         <%--             <h4 style="padding:0px;"><asp:Label ID="Label1" class="dejavu" runat="server" Text="50.000 dinara"></asp:Label></h4>
                                    
                              
                                  
                             <h4 style="padding:0px;"><asp:Label ID="Label2" class="dejavu" runat="server" Text="1.050.000 dinara"></asp:Label></h4>      
                             
                                  
                             <h4 style="padding:0px;"><asp:Label ID="Label3" class="dejavu" runat="server" Text="100 dinara"></asp:Label></h4>      
                                 
                                  
                              <h4 style="padding:0px;"><asp:Label ID="Label4" class="dejavu" runat="server" Text="10.000"></asp:Label></h4>      
                              
                                 
                               <h4 style="padding:0px;"><asp:Label ID="Label5" class="dejavu" runat="server" Text="60"></asp:Label></h4> 
                                   


                                     <hr />--%>

                                </div>


                            </div>



                                
                                   
                           
                                  
                                    <asp:Label ID="LabelPreneseniFond" class="dejavu" runat="server" Text="50.000 dinara"></asp:Label>
                                <hr />
                                  
                                    <asp:Label ID="LabelUkupanIznosFonda" class="dejavu" runat="server" Text="1.050.000 dinara"></asp:Label>
                                <hr />
                                  
                                    <asp:Label ID="LabelCenaTiketa" class="dejavu" runat="server" Text="100 dinara"></asp:Label>
                                <hr />    
                                  
                                    <asp:Label ID="LabelUplacenoTiketa" class="dejavu" runat="server" Text="10.000"></asp:Label>
                                <hr />
                                 
                                    <asp:Label ID="LabelIzvucenoDobitaka" class="dejavu" runat="server" Text="60"></asp:Label>  
                         </div>
                        </div>
                    </div>
            <!--./PRVA KARTICA-->

                <!--DRUGA KARTICA-->
                <div class="col-md-4">
                    <div class="card-content" style="width:420px;height:610px;margin-left:70px;margin-right:50px;">
                        <div class="card-img">
                            <img src="../slike/kartica_loptice.jpg" alt="">                  
                        </div>
                        <div class="card-desc">
                            <h3>VRSTA DOBITAKA</h3>
                                <hr />
                                    <h4 class="horizontalno">Sedam pogodaka:</h4>
                                        <asp:Label ID="LabelSedmica" class="dejavu" runat="server" Text="1"></asp:Label>
                                <hr />
                                    <h4 class="horizontalno">Šest pogodaka:</h4>
                                        <asp:Label ID="LabelSestica" class="dejavu" runat="server" Text="2"></asp:Label>
                                <hr />
                                    <h4 class="horizontalno">Pet pogodaka:</h4>
                                        <asp:Label ID="LabelPetica" class="dejavu" runat="server" Text="7"></asp:Label>
                                <hr />     
                                     <h4 class="horizontalno">Četiri pogotka:</h4>
                                        <asp:Label ID="LabelCetvorka" class="dejavu" runat="server" Text="50"></asp:Label>  
                        </div>
                    </div>
                </div>
            <!--./DRUGA KARTICA-->
                 <!--TRECA KARTICA-->
                <div class="col-md-4">
                    <div class="card-content" style="width:420px;height:610px;margin-left:140px;">
                        <div class="card-img">
                            <img src="../slike/kartica_loptice.jpg" alt="">
                        </div>
                            <div class="card-desc">
                              <h3>ISPLAĆENO</h3>
                                <hr />
                                    <h4 class="horizontalno">Sedmice:</h4> 
                                        <asp:Label ID="LabelIsplataSedmice" class="dejavu" runat="server" Text="16151554654 dinara"></asp:Label>
                                <hr />
                                    <h4 class="horizontalno">Šestice:</h4> 
                                        <asp:Label ID="LabelIsplataSestice" class="dejavu" runat="server" Text="5000000 dinara"></asp:Label>
                                <hr />
                                    <h4 class="horizontalno">Petice:</h4> 
                                        <asp:Label ID="LabelIsplataPetice" class="dejavu" runat="server" Text="15000 dinara"></asp:Label>
                                <hr />
                                    <h4 class="horizontalno">Četvorke:</h4> 
                                        <asp:Label ID="LabelIsplataCetvorke" class="dejavu" runat="server" Text="5000 dinara"></asp:Label>
                           </div>
                    </div>
                </div>
                <!--./TRECA KARTICA-->
        </div>
    </div>
</section>

</asp:Content>
