<%@ Page Title="" Language="C#" MasterPageFile="MasterStrana.Master" AutoEventWireup="true" CodeBehind="AdminUklanjanje.aspx.cs" Inherits="LotoRotoProjekat.AdminUklanjanje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeholderAdminDropdown" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../stil/rezultati.css" rel="stylesheet" />

    <section class="details-card" style="padding: 100px 0;background:none !important;">
        <div class="container">
            <div class="row">
                <div class="col-md-4">
                    <div class="card-content">
                        <div class="card-img">
                            <img src="../slike/avatar.png" alt="">                  
                        </div>
                        <div class="card-desc">
                                <asp:Button ID="btnUkloniKorisnika" runat="server" OnClick="btnUkloniKorisnika_Click"  Text="Ukloni korisnika" class="btn btn-indigo" style="background-color:#910b70 !important;margin-left:60px;"/>
                            </div>
                        </div>
                    </div>

                <div class="col-md-4">
                    <div class="card-content">
                        <div class="card-img">
                            <div class="card-desc">
                               <asp:Button ID="btnUkloniNeaktivne" runat="server" OnClick="btnUkloniNeaktive_Click"  Text="Ukloni neaktivne korisnike" class="btn btn-indigo" style="background-color:#910b70 !important;margin-left:15px;"/>

                                <asp:DropDownList ID="neaktivni" runat="server">
                                </asp:DropDownList>
                            </div>
                       </div>
                   </div>
                </div>
                </div>
            </div>
        </section>
                            
</asp:Content>
