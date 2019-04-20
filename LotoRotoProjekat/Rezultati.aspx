<%@ Page Title="" Language="C#" MasterPageFile="~/MasterStrana.Master" AutoEventWireup="true" CodeBehind="Rezultati.aspx.cs" Inherits="LotoRotoProjekat.Rezultati" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="stil/generator_stil.css" rel="stylesheet" />
    <script src="javascript/generator_izvlacenja.js"></script>

        <div>
            <input class="btn btn-indigo"style="width:188px;margin-left:130px;" type=button value='Dobitna kombinacija' onClick="lotto(); StOp()">
        </div>


    <link href="stil/lopte_dobitna.css" rel="stylesheet" />
    
    <div class="wrap">
      <section class="stage">
            <figure class="ball">
              <span class="number" id="loptica_1" data-number="">&nbsp;</span>
            </figure>
      </section>
      <section class="stage">
            <figure class="ball">
              <span class="number" id="loptica_2" data-number="">&nbsp;</span>
            </figure>
      </section>
      <section class="stage">
            <figure class="ball">
              <span class="number" id="loptica_3" data-number="">&nbsp;</span>
            </figure>
      </section>
      <section class="stage">
            <figure class="ball">
              <span class="number" id="loptica_4" data-number="">&nbsp;</span>
            </figure>
      </section>
        <section class="stage">
            <figure class="ball">
              <span class="number" id="loptica_5" data-number="">&nbsp;</span>
            </figure>
      </section>
        <section class="stage">
            <figure class="ball">
              <span class="number" id="loptica_6" data-number="">&nbsp;</span>
            </figure>
      </section>
        <section class="stage">
            <figure class="ball">
              <span class="number" id="loptica_7" data-number="">&nbsp;</span>
            </figure>
      </section>
    </div>

    <asp:Table ID="Table1" runat="server">
    </asp:Table>

</asp:Content>
