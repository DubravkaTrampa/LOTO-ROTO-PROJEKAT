<%@ Page Title="" Language="C#" MasterPageFile="MasterStrana.Master" AutoEventWireup="true" CodeBehind="Pocetna.aspx.cs" Inherits="LotoRotoProjekat.Pocetna" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="btn-indigo" style="float:left;margin-left:20px; margin-top:50px; width:220px;height:62px;text-align:center;background-color:#910b70 !important;">
                  
        <h5>Uplate se zatvaraju za:</h5> 
            <p id="demo"></p>
                 
        <script src="/javascript/brojac_do_izvlacenja.js"></script>
              <a href="https://www.un.org/en/universal-declaration-human-rights/" target="_blank" style="float:left;margin-left:40px;margin-top:100px;"><img src="/slike/human_rights.gif"/></a>
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
        <div class="col-md-5 mb-4" style="text-align: justify;  text-align: center;padding:30px; color:#275196; text-transform: uppercase";>

          <h2>Donirajte, dok očekujete pogodak!<br />Svaka Vaša uplaćena kombinacija<br />je donacija humanitarnom fondu!</h2>
            <hr>
                <p>Vaša donacija će stvarno promeniti nečiji život.</p>
         
            <section id="social-buttons" class="text-center"; style="display:inline; padding: 10px; font-size: 30px;width: 50px;text-align: center;text-decoration: none;margin: 5px 2px;">
         
            <a href="https://www.facebook.com/Loto-Roto-2261077554156862/" target="_blank" class="fa fa-facebook"style="margin:auto;width: 20%;padding: 10px;"></a>
            <a href="https://twitter.com/?lang=en" target="_blank" class="fa fa-twitter"style="margin:auto;width: 20%;padding: 10px;"></a>
            <a href="https://rs.linkedin.com/" target="_blank" class="fa fa-linkedin"style="margin:auto;width: 20%;padding: 10px;"></a>
          </section>
          <a href="https://www.unicef.org/" target="_blank" style="float:right;margin-right:180px;margin-top:40px;"><img src="/slike/unicef.gif"/></a> 
          
        </div>
        <!--Grid column-->

      </div>
        <br />
      <!--Grid row-->

    <!--Main container-->

  </main>
  <!--Main layout-->     

</asp:Content>
