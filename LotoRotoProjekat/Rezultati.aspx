<%@ Page Title="" Language="C#" MasterPageFile="~/MasterStrana.Master" AutoEventWireup="true" CodeBehind="Rezultati.aspx.cs" Inherits="LotoRotoProjekat.Rezultati" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="stil/generator_stil.css" rel="stylesheet" />
    <link href="stil/lopte_dobitna.css" rel="stylesheet" />
    <script src="javascript/generator_izvlacenja.js"></script>

        <div>
            <input class="btn btn-indigo"style="width:188px;margin-left:130px;background-color:#910b70 !important;" type=button value='Dobitna kombinacija' onClick="lotto(); StOp()">
               
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
    <section  class="text-center"style="margin-left:450px;margin-right:450px;">
      
      <div class="row">

              <!--Grid column-->
              <div class="col-md-6 mb-4">

                  <!--Card-->
                  <div class="card testimonial-card">

                      <!--Bacground color-->
                      <div class="card-up purple-gradient" style="height:60px;">
                      </div>

                      <!--Avatar-->
                      <div>
                                     
                      </div>

                      <div class="card-body" style="color:#275196;">
                         <h4>Ukupno uplaćeno:</h4>
                <asp:Label ID="LabelUkupnoUplaceno" runat="server" Text="1.000.000 dinara" style="font-size: 24px;line-height: 12px;font-family: DejaVu Sans, Arial, Helvetica, Geneva;font-weight: bold;text-align: left" ></asp:Label>
        
            <h4>Preneseni fond:</h4>
                <asp:Label ID="LabelPreneseniFond" runat="server" Text="" style="font-size: 12px;line-height: 12px;font-family: DejaVu Sans, Arial, Helvetica, Geneva;font-weight: bold;text-align: left" ></asp:Label>

            <h4>Ukupan iznos fonda:</h4>
                <asp:Label ID="LabelUkupanIznosFonda" runat="server" Text="" style="font-size: 12px;line-height: 12px;font-family: DejaVu Sans, Arial, Helvetica, Geneva;font-weight: bold;text-align: left" ></asp:Label>

            <h4>Cena tiketa:</h4>
                <asp:Label ID="LabelCenaTiketa" runat="server" Text="" style="font-size: 12px;line-height: 12px;font-family: DejaVu Sans, Arial, Helvetica, Geneva;font-weight: bold;text-align: left" ></asp:Label>
              
            <h4>Uplaćeno tiketa:</h4>
                <asp:Label ID="LabelUplacenoTiketa" runat="server" Text="" style="font-size: 12px;line-height: 12px;font-family: DejaVu Sans, Arial, Helvetica, Geneva;font-weight: bold;text-align: left" ></asp:Label>

                      </div>
                       <div class="card-up purple-gradient" style="height:60px;" >
                      </div>
                  </div>
                  <!--/.Card-->

              </div>
              <!--Grid column-->

              <!--Grid column-->
              <div class="col-md-6 mb-4">

                  <!--Card-->
                  <div class="card testimonial-card">

                      <!--Bacground color-->
                      <div class="card-up purple-gradient" style="height:60px;">
                      </div>

                      <!--Avatar-->
 

                      <div class="card-body" style="color:#275196;">
                         <h4>Izvučeno dobitaka:</h4>
                            <asp:Label ID="LabelIzvucenoDobitaka" runat="server" Text="1.000.000 dinara" style="font-size: 24px;line-height: 12px;font-family: DejaVu Sans, Arial, Helvetica, Geneva;font-weight: bold;text-align: left" ></asp:Label>
        <h4><strong>VRSTA DOBITAKA:</strong></h4><hr />
                         <h4>Sedam pogodaka:</h4>
                            <asp:Label ID="LabelSedamPogodaka" runat="server" Text="" style="font-size: 12px;line-height: 12px;font-family: DejaVu Sans, Arial, Helvetica, Geneva;font-weight: bold;text-align: left" ></asp:Label>

                         <h4>Šest pogodaka:</h4>
                            <asp:Label ID="LabelSestPogodaka" runat="server" Text="" style="font-size: 12px;line-height: 12px;font-family: DejaVu Sans, Arial, Helvetica, Geneva;font-weight: bold;text-align: left" ></asp:Label>

                         <h4>Pet pogodaka:</h4>
                            <asp:Label ID="LabePetPogodaka" runat="server" Text="" style="font-size: 12px;line-height: 12px;font-family: DejaVu Sans, Arial, Helvetica, Geneva;font-weight: bold;text-align: left" ></asp:Label>
              
                         <h4>Četiri pogotka:</h4>
                            <asp:Label ID="LabelCetiriPogotka" runat="server" Text="" style="font-size: 12px;line-height: 12px;font-family: DejaVu Sans, Arial, Helvetica, Geneva;font-weight: bold;text-align: left" ></asp:Label>

                      </div>
                    <div class="card-up purple-gradient" style="height:60px;" >
                </div>
             </div>
                  <!--/.Card-->

          </div></div>
              <!--Grid column-->
        </section>
  </main>
  <!--Main layout-->

  </div>
  
</asp:Content>
