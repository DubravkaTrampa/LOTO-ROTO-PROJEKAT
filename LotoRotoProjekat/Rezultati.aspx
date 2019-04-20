<%@ Page Title="" Language="C#" MasterPageFile="~/MasterStrana.Master" AutoEventWireup="true" CodeBehind="Rezultati.aspx.cs" Inherits="LotoRotoProjekat.Rezultati" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="stil/generator_stil.css" rel="stylesheet" />
    <script src="javascript/generator_izvlacenja.js"></script>

        <div>
            <input class="btn btn-indigo"style="width:188px;margin-left:130px;" type=button value='Dobitna kombinacija' onClick="lotto(); StOp()">
        </div>
             <span id=layer1 class=generator style="width:188px;margin-left:110px;color:blue;">Rezultat</span>

    <link href="stil/lopte_dobitna.css" rel="stylesheet" />
    
    <div class="wrap">
      <section class="stage">
            <figure class="ball">
              <span class="number" data-number="8">&nbsp;</span>
            </figure>
      </section>
      <section class="stage">
            <figure class="ball">
              <span class="number" data-number="2">&nbsp;</span>
            </figure>
      </section>
      <section class="stage">
            <figure class="ball">
              <span class="number" data-number="4">&nbsp;</span>
            </figure>
      </section>
      <section class="stage">
            <figure class="ball">
              <span class="number" data-number="9">&nbsp;</span>
            </figure>
      </section>
        <section class="stage">
            <figure class="ball">
              <span class="number" data-number="7">&nbsp;</span>
            </figure>
      </section>
        <section class="stage">
            <figure class="ball">
              <span class="number" data-number="1">&nbsp;</span>
            </figure>
      </section>
        <section class="stage">
            <figure class="ball">
              <span class="number" data-number="3">&nbsp;</span>
            </figure>
      </section>
    </div>

    <asp:Table ID="Table1" runat="server">
    </asp:Table>

</asp:Content>
