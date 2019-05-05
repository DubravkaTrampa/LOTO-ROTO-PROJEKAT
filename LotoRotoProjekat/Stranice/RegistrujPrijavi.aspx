<%@ Page Title="" Language="C#" MasterPageFile="MasterStrana.Master" AutoEventWireup="true" CodeBehind="RegistrujPrijavi.aspx.cs" Inherits="LotoRotoProjekat.RegistrujPrijavi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="panel1" runat="server"><ContentTemplate>
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
                        <asp:Panel ID="panel_login" runat="server">
                        <div id="login" class="animate form">
                           <!-- <form autocomplete="on" >  -->
                                <h1>Prijavi se</h1> 
                                <p> 
                                        <asp:Label ID="login_uname" runat="server" Text="Korisničko ime"></asp:Label>
                                        <asp:TextBox id="PlaceHolder_login" required="required" runat="server" placeholder="obavezno polje!"></asp:TextBox >

                                        <asp:Label ID="login_pass" runat="server" Text="Lozinka"></asp:Label>
                                        <asp:TextBox id="PlaceHolder_pass" required="required" TextMode="Password" runat="server" placeholder="obavezno polje!"></asp:TextBox>

                                
                                <p class="login button"> 
                                    <asp:button runat="server" type="submit" class="signinbtn" onclick="btnLogin_Click" EnableViewState = true  Text="Prijavi se"></asp:button>
                                    <!--<input type="submit" value="Prijavi se" />-->
								</p>
                                <p class="change_link">
									Još uvek niste registrovani ?
									<asp:Button ID="register_redirect" runat="server" OnClick="btnRedirectToRegisterClick" Text="Registruj se" UseSubmitBehavior="false" class="to_register"></asp:Button>
                                    <!--href="#toregister"-->
								</p>

                        </div>
                            </asp:Panel>
                            <asp:Panel ID="panel_register" runat="server" Visible="false">
                        <div class="animate form">

                                <h1> Registruj se</h1> 

                                  <asp:Label ID="register_uname" runat="server" Text="Unesite korisničko ime"></asp:Label>
                                  <asp:TextBox id="PlaceHolder_register"  required="required" runat="server" ></asp:TextBox >
    
                                  <asp:Label ID="register_pass" runat="server" Text="Unesite lozinku"></asp:Label>
                                  <asp:TextBox id="PlaceHolder_password" TextMode="Password" required="required"  runat="server" ></asp:TextBox >
       
                                  <asp:Label ID="register_pass2" runat="server" Text="Ponovite lozinku"></asp:Label>
                                  <asp:TextBox id="PlaceHolder_pass2" TextMode="Password" required="required" runat="server" ></asp:TextBox >
  
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
                                    <asp:button runat="server" type="submit"  onclick="btnRegister_Click" Text="Registruj se" EnableViewState = true></asp:button>
									<!--<input type="submit" value="Registruj se"/>-->
								
                                <p class="change_link">  
									Već ste registrovani ?
									<asp:Button ID="login_redirect" runat="server" OnClick="btnRedirectToLoginClick" UseSubmitBehavior="false" Text=" Idi na stranicu prijavi" class="to_register" ></asp:Button>
								</p>
                      
                            
                        </div>
                                </asp:Panel>
                    </div>
                </div> 
                <asp:Panel ID="panel_uspesan_redirect_msg" runat="server" Visible ="false">
                    <asp:Label ID="Label_uspesan_redirect" runat="server" Text="Uspešno ste se registrovali!"></asp:Label>
                    <asp:Button ID="btn_uspesan_redirect" runat="server" OnClick="btnUspesanRedirectClick" UseSubmitBehavior="false" Text="U redu"></asp:Button >
                </asp:Panel>
            </section>
        </div></ContentTemplate></asp:UpdatePanel>  
</asp:Content>
