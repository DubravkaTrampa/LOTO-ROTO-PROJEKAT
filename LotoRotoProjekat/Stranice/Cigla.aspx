<%@ Page Title="" Language="C#" MasterPageFile="MasterStrana.Master" AutoEventWireup="true" CodeBehind="Cigla.aspx.cs" Inherits="LotoRotoProjekat.Cigla" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="panel1" Visible="false" runat="server"><ContentTemplate>
     <style>
    	canvas { background: #eee; }
    </style>
    
<canvas id="myCanvas" width="730" height="420" style="float:left;margin-left:250px;margin-top:50px;margin-bottom: 450px;"></canvas>

    <script src="/javascript/cigle.js"></script>
        </ContentTemplate></asp:UpdatePanel>
    <asp:Panel ID="panelSaSlikomIdugmetom" runat="server" Visible="true">
     <div class="container-fluid">
        <div>
         <section class="details-card" style="padding: 100px 0;background:none !important;">
        <div class="container" style="margin-left:240px;">
            <div class="row">
                <div class="col-md-4">
                    <div class="card-content">
                        <div class="card-img">
                            <img src="../slike/slika_cigla.jpg" alt="" style="width:450px; height:250px">                  
                        </div>
                        <div class="card-desc">
                           <asp:Button ID="cigle_pokreni" style="width:450px;height:50px;background-color:#910b70;color:#FFFFFF;" runat="server" OnClic="btnCiglePokreni" Text="Start" OnClick="cigle_pokreni_Click"></asp:Button>
                                </div>
                             </div>
                           </div>
                        </div>
                    </div>
                 </section>
             </div>
        </div>

    </asp:Panel>
</asp:Content>
