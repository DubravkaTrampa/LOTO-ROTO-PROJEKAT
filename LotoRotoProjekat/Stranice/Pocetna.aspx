<%@ Page Title="" Language="C#" MasterPageFile="MasterStrana.Master" AutoEventWireup="true" CodeBehind="Pocetna.aspx.cs" Inherits="LotoRotoProjekat.Pocetna" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../stil/pocetna_stil.css" rel="stylesheet" />

    <div class="btn-indigo" id="okvir">
                  
        <h5>Uplate se zatvaraju za:</h5> 
            <p id="demo"></p>
                 
        <script src="/javascript/brojac_do_izvlacenja.js"></script>
              <a href="https://www.unicef.org/" target="_blank" class="brojac_pozicija"><img src="/slike/unicef.gif" class="unicef_vel"/></a>
    </div>
     

      <!--Main layout-->
  <main class="mt-5">
      
    <!--Main container-->

      <!--Grid row-->
      <div class="row">

        <!--Grid column-->
        <div class="col-md-7 mb-4">

          <div class="view overlay z-depth-1-half">

              <img src="/slike/lopteBele.jpg"  class="card-img-top" alt="">
            <div class="mask rgba-white-light"></div>
          </div>

        </div>

        <!--Grid column-->
        <div class="col-md-3 mb-4" id="slogan">

          <h2>Donirajte, dok očekujete pogodak!<br />Svaka Vaša uplaćena kombinacija<br />je donacija humanitarnom fondu!</h2>
            <hr>
                <p>Vaša donacija će stvarno promeniti nečiji život.</p>
         
            <section id="social-buttons" class="social_dugmad">
         
            <a href="https://www.facebook.com/Loto-Roto-2261077554156862/" target="_blank" class="fa fa-facebook social_linkovi"></a>
            <a href="https://twitter.com/?lang=en" target="_blank" class="fa fa-twitter social_linkovi"></a>
            <a href="https://rs.linkedin.com/" target="_blank" class="fa fa-linkedin social_linkovi"></a>
          </section>
          
        </div>
        <!--Grid column-->

      </div>
        <br />
      <!--Grid row-->

    <!--Main container-->

  </main>
  <!--Main layout-->     

</asp:Content>
