<%@ Page Title="" Language="C#" MasterPageFile="MasterStrana.Master" AutoEventWireup="true" CodeBehind="RegistrujPrijavi.aspx.cs" Inherits="LotoRotoProjekat.RegistrujPrijavi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <div class="container" style="padding:15px";>
            <!-- Codrops top bar -->
            <div class="codrops-top">

                <span class="right">

                </span>
                <div class="clr"></div>
            </div><!--/ Codrops top bar -->

            <section>				
                <div id="container_demo" style="line-height:1;">
                    
                    <a class="hiddenanchor" id="toregister"></a>
                    <a class="hiddenanchor" id="tologin"></a>
                    <div id="wrapper">
                        <div id="login" class="animate form">
                           <!-- <form autocomplete="on" >  -->
                                <h1>Prijavi se</h1> 
                                <p> 
                                        <asp:Label ID="login_uname" runat="server" Text="Korisničko ime"></asp:Label>
                                        <asp:TextBox id="PlaceHolder_login" required="required" runat="server" placeholder="obavezno polje!"></asp:TextBox >

                                        <asp:Label ID="login_pass" runat="server" Text="Lozinka"></asp:Label>
                                        <asp:TextBox id="PlaceHolder_pass" required="required" runat="server" placeholder="obavezno polje!"></asp:TextBox>

                                
                                <p class="login button"> 
                                    <asp:button runat="server" type="submit" class="signinbtn" onclick="btnLogin_Click" EnableViewState = true UseSubmitBehavior="false" Text="Prijavi se"></asp:button>
                                    <!--<input type="submit" value="Prijavi se" />-->
								</p>
                                <p class="change_link">
									Još uvek niste registrovani ?
									<a href="#toregister" class="to_register">Registruj se</a>
								</p>

                        </div>

                        <div id="register" class="animate form">

                                <h1> Registruj se</h1> 

                                  <asp:Label ID="register_uname" runat="server" Text="Unesite korisničko ime"></asp:Label>
                                  <asp:TextBox id="PlaceHolder_register"  required="required" runat="server" ></asp:TextBox >
    
                                  <asp:Label ID="register_pass" runat="server" Text="Unesite lozinku"></asp:Label>
                                  <asp:TextBox id="PlaceHolder_password" required="required"  runat="server" ></asp:TextBox >
       
                                  <asp:Label ID="register_pass2" runat="server" Text="Ponovite lozinku"></asp:Label>
                                  <asp:TextBox id="PlaceHolder_pass2" required="required" runat="server" ></asp:TextBox >
  
                                  <asp:Label ID="register_ime" runat="server" Text="Unesite ime"></asp:Label>
                                  <asp:TextBox id="PlaceHolder_ime" required="required" runat="server" ></asp:TextBox >
   
                                  <asp:Label ID="register_prezime" runat="server" Text="Unesite prezime"></asp:Label>
                                  <asp:TextBox id="PlaceHolder_prezime" required="required" runat="server"></asp:TextBox>

                                  <asp:Label ID="register_datum_rodj" runat="server" Text="Datum rođenja"></asp:Label>
                                  <asp:TextBox type="date"  id="PlaceHolder_datum_rodj" required="required" runat="server"></asp:TextBox>
                             
                                  <asp:Label ID="register_adresa" runat="server" Text="Adresa"></asp:Label>
                                  <asp:TextBox id="PlaceHolder_adresa" required="required" runat="server"></asp:TextBox>

                                  <asp:Label ID="register_br_racuna" runat="server" Text="Broj računa"></asp:Label>
                                  <asp:TextBox id="PlaceHolder_racun" required="required" runat="server"></asp:TextBox>

                                  <asp:Label ID="register_tel" runat="server" Text="Broj telefona"></asp:Label>
                                  <asp:TextBox id="PlaceHolder_tel" placeholder="primer unosa:065555111" required="required" runat="server"></asp:TextBox>

                                  <asp:Label ID="register_email" runat="server" Text="Unesite E-mail"></asp:Label>
                                  <asp:TextBox id="PlaceHolder_email" required="required" runat="server"></asp:TextBox>
                            
                                <p class="signin button"> 
                                    <asp:button runat="server" type="submit"  onclick="btnRegister_Click" UseSubmitBehavior="false" Text="Registruj se" EnableViewState = true></asp:button>
									<!--<input type="submit" value="Registruj se"/>-->
								
                                <p class="change_link">  
									Već ste registrovani ?
									<a href="#tologin" class="to_register"> Idi na stranicu prijavi </a>
								</p>
                      
                            
                        </div>
                    </div>
                </div>  
            </section>
        </div>
</asp:Content>
