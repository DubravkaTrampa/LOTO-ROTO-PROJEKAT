<%@ Page Title="" Language="C#" MasterPageFile="MasterStrana.Master" AutoEventWireup="true" CodeBehind="Onama.aspx.cs" Inherits="LotoRotoProjekat.Onama" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../stil/informacije_o_nama.css" rel="stylesheet" />
               
    <!--Main container-->
    <div class="container">
    <main>
    <section  class="text-center o_nama1">
      <h5 class="py-5 nas_tim">Naš tim</h5>
      <div class="row" style="width:650px">

              <!--Grid column-->
              <div class="col-md-6 mb-4">

                  <!--Card-->
                  <div class="card testimonial-card">

                      <!--Bacground color-->
                      <div class="card-up purple-gradient">
                      </div>

                      <!--Avatar-->
                      <div class="avatar mx-auto white">
                          <img src="/slike/DusicaKrstic.jpg" class="rounded-circle">
                      </div>

                      <div class="card-body" style="color:#275196;">
                          <!--Name-->
                          <h4 class="card-title">Dušica Krstić</h4>
                          <hr>
                          <!--Quotation-->
                          <p> DotNet Developer</p>
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
                      <div class="card-up purple-gradient">
                      </div>

                      <!--Avatar-->
                      <div class="avatar mx-auto white">
                          <img src="/slike/DubravkaTrampa.jpg" class="rounded-circle">
                      </div>

                      <div class="card-body" style="color:#275196;">
                          <!--Name-->
                          <h4 class="card-title">Dubravka Trampa</h4>
                          <hr>
                          <!--Quotation-->
                          <p>DotNet Developer</p>
                      </div>

                  </div>
                  <!--/.Card-->

              </div>
              <!--Grid column-->

          </div>
        </section>
  </main>
        </div>
  <!--Main layout-->

</asp:Content>
