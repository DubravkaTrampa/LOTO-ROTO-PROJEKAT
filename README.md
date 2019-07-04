 LOTO  ROTO  LOTTERY

                                                  CONCEPT OF THE PROJECT

The idea of this web application is to encourage users to donate for humanitarian purposes through the game LOTO ROTO. 
The slogan of the game is: "Donate, as you win! Every winning ticket is a donation to the humanitarian fund! Your donation will really change someone's life. "

The game relies on the rules of the LOTO State of Serbia Lottery, with a few changes. Each player has the option of paying at least one combination of 14 numbers, which is chosen on a ticket with 39 numbers. The premium is achieved in the case of the seven affected numbers, while:

• second prize - combination with six hits;

• third prize - combination with five hits;

• with four hits, a ticket is replaced.

With 14 combinations, there is more chance for win.

Why is that important?

Because, apart from the winner, the payout is divided in percentages on behalf of the humanitarian aid fund, while a smaller percentage goes to the organizer (2%), but only in the event of a win. Thus, more tickets -> bigger rewards -> more hits -> more money for charity funds!

                                                           PRIZES

We can not predict the number of winners with square footage (change of ticket), so that a weekly fund immediately separates the funds that will cover the cost of replacing the ticket, whose price is fixed. The rest of the money is for funding other three awards.

• Earnings from seven winning numbers - 60% of the total fund;

• Earnings from six winning numbers - 30% of the total fund;

• Earnings from five winning numbers - 10% of the total fund;

• Four-digit gain is a replacement ticket.

Each winner (with seven, six and five hits) divides part of their prize- 20% as a donation for humanitarian purposes, as well as 2% for the organizer of the game. Funds are automatically transferred to a humanitarian fund. The rest of the money is paid to the winner.

                                                    THE PAGES SHALL CONTAIN

The user interface will include a logo, a slogan, a site-to-page navigation, a generator of winning numbers. Navigation options for: game rules (About game), user registration, user login, ticketing, withdrawal results, winning combination report as well as fund information (total paid, number of winners with the amount of winnings, , information about organizer and organization of humanitarian aid, contact. The SQL database will contain tables: winners, fund, city, humanitarian fund, round, combination, user, ticket, transaction, type of winner.

We will upload the database with about 20 users for presentation, while the registration pages of the site will be able to enter new user registration information. Project design will be executed using Microsoft Visual Studio 2017 software, as ASP.NET application, with the MVC project (master page) structure. For user interface design we will use CSS, javascript and Bootstrap library.

                                                  APPLICATION-DESIGN-NAVIGATION

Application was made using blank web form (asp with master page). It consists of multiple pages, the main master page - in which we created a header and footer that is common to all the other pages, as well as navigation via links to most pages. We used bootstrap for responsiveness, which means that the application is customize for all devices. Navigation consists of links to home, about the game, results, about us, contact, sign up and sign in, and play buttons.  Pages - about the game, about us and the contact contains only information about site and the organizers. Any site visitor has access to all pages other than the game itself, to access this page he must be a registered user. That is why the user registration page contains both forms, both the login and the registry, which we have edited using css. We have edited the logic so that if a user attempts to log in, and the password or name is incorrectly entered / does not exist, a message is displayed to indicate that the user did not enter the correct one. If the user knows that he has no registered order, he can go to  registration panel, where he will enter the information required for registration. If you do not enter a particular item, using the required command, we have specified warning message that not all fields (textboxes) are filled. Once the registrations have been entered, we confirm that by clicking registration button, a pop-up message about successful registration becomes visible and displays info about successful registration. After that we can login.

After the user gets logged in, the button with  the sign up / sign in text changes to "Log off" option. By clicking on this button we will now log out and return to the login page. As long as we are logged in we can play and pay for the ticket. By clicking on the "Play" button we are redirected on "Play ticket" page.

On the "Play" page there is a button with a grid view with the offered numbers for the ticket combination(one ticket). By clicking on each cell within the ticket, numbers are selected, chosen and separated in the label above showed as sorted numbers. We have determined that there is an option to reset one(or any) selected number. Each click by the user gets an overview of the selected number (or canceled) by changing the color of the cell.

Clicking on the button "OK" user confirms that he has chosen the maximum number of 14 combinations. After that, we call methods that insert the combination into the database. The inserted combination belongs to currently logged in user. Since we have successfully made a ticket, it is necessary to enter a 100 dollar transaction into our database, and it is also noted that the type of transaction is "ticket". After confirming the ticket  with the combinations, label above the ticket gets changed to "you have successfully paid the ticket" and the message "SELECT NEW COMBINATION" take place and the grid gets restored to the initial state.

Also within the page we have added an option that the user can have insights into all paid tickets that he made in the current weekly draw. For the user entertainment while waiting for a draw, we added a link to a page containing a simple "Bricks" game, which was made in javascript. 
Optionally, we can provide more links with similar game types. Those links could be potential sponsors of the lottery or a humanitarian fundraiser.

We added a button that would allow you to pay a combination of random numbers of 5 tickets at a time.

The results page shows the data on the completed weekly lottery result. How many tickets(sum), what is the amount of the fund, how many - four, six, prizes etc .... We also inserted the random number generator and by clicking on the button - winning combination, that way we can get 7 random numbers. This generator could serve to extract the winning combination of the current weekly draw. However, our idea is that a winning combination should be the one that is obtained in the official drawing of the state lottery of Serbia, because it would be impossible to abuse the results.

On the start page there is a timer / counter until beginning of the draw in which we are currently setting up the date of this exam / served as a reminder of how much time left. Why did we not link it to the game weekly drawing? Because testing this app can not work in real time. We simulate the game(whole process) using two buttons, one to start game and second  to finish(close). By clicking the start button, we replace the start of the timer. When we start the game we add a new round to the base, login user, by few tickets and (simulation) end three days after the start, with "Close(Finish)" button.

By clicking "end", we change the timer outbreak event. When the game is over, winners are counted, same as the fund with the charged bets. The fund is transferred if there wasn't any winnings, bonuses are awarded depending on the winnings, the fund is updated for the next weekly draw, and the results are displayed on the above mentioned page.

It should be noted that we have enabled the administrator to enter the site. Pages that are visible to the administrator in this case are not visible to other users (this is verified by the type of user in the database). We've created two pages for the Admin. Navigation to them is visible in the dropdown header. On these two pages, admin can  remove all inactive users (they have not been logged for more than three months) or add a new humanitarian fund to the database (name, description, and fund account number).

Our primary goal for us was that the game is working, and the admin side is added to show that the administrator can make changes and has special access rights.


                                                         PROBLEMS

- On the login page we had to use UseSubmitBehavior = "false"

It was necessary to set a specific button  not act as a submit button because it must be done regardless of any fields on the site that are "required".

-A buttonClickEvent page refreshes

This behavior did not always fit us, for example, with tickets on the "PlayTicket" page. This is solved by adding UpdatePanel with ContentTemplate and ScriptManager.

-Within page Register / Login  when redirecting to one options, the other remains hidden, but its fields remain active due to CSS.

- This rule is a big problem because the fields were required and they reported bugs from invisible locations when attempting to log in / register the user. We solved this by framing both forms with the Panel and then this panel appears visible or not depending on what form we are in.

----------------------------------------------------------------------------------------------------------------------------------------

# LOTO-ROTO-PROJEKAT

                                                        LOTO  ROTO  LUTRIJA
                                                         KONCEPT  PROJEKTA

  Ideja ove  web aplikacije je da se korisnici stimulišu za donacije u humanitarne svrhe kroz igru LOTO ROTO. 
Slogan igre je:  „Donirajte, dok očekujete pogodak! Svaka Vaša uplaćena kombinacija je donacija humanitarnom fondu! Vaša donacija će stvarno promeniti nečiji život.“

  Igra se oslanja na pravila igre LOTO Državne Lutrije Srbije, ali uz nekoliko izmena . Svaki  igrač ima mogućnost da uplati minimum jednu  kombinaciju od 14 brojeva , koje bira na tiketu sa 39 brojeva. Premija se ostvaruje  u slučaju pogođenih sedam  brojeva, dok su: 
  
                                            •	druga nagrada - kombinacija sa šest  pogodaka;
                                            •	treća nagrada - kombinacija sa pet  pogodaka;
                                            •	sa četiri  pogotka se dobija  zamena tiketa.
  Sa 14 kombinacija veće su šanse za dobitak.
  
Zašto je to važno?

  Zato što se isplata, osim dobitniku, procentualno odvaja na ime fonda za humanitarnu pomoć, dok  manji procenat ide organizatoru(2%), ali samo u slučaju ostvarenog dobitka. 
  Dakle, veći broj uplata -> veće nagrade -> više pogodaka -> više novca za humanitarni fond!

                                                              NAGRADE

  Broj dobitnika sa četvorkom ( zamenom tiketa) ne možemo predvideti , tako da se od ukupnog fonda jednog kola odmah odvajaju sredstva koja će pokriti  trošak zamene tiketa, čija cena je fiksna. Ostatak novca je fond za ostale tri nagrade.

                                         Pogodak od sedam brojeva - 60% od ukupnog fonda tekućeg kola;
                                         Pogodak od šest brojeva - 30% od ukupnog fonda tekućeg kola;
                                         Pogodak od pet brojeva - 10% od ukupnog fonda tekućeg kola;
                                         Pogodak od četiri broja je zamena tiketa.

  Svaki dobitnik (sa sedam, šest i pet pogodaka), odvaja deo svoje nagrade-20% kao donaciju u humanitarne svrhe, kao i 2% namenjenih organizatoru igre. Sredstva se automatski prebacuju u humanitarni fond. Ostatak novca se isplaćuje dobitniku.



                                                        STRANICE ĆE SADRŽATI

  Korisnički interfejs će sadržati logo, slogan, navigaciju sa linkovima ka stranicama , generator izvlačenja brojeva .
Opcije navigacije za: pravila igre (O igri), registraciju korisnika, prijavu korisnika, uplatu tiketa,   rezultate izvlačenja, izveštaj o dobitnim kombinacijama, kao i podatke o fondu (ukupno uplaćeno, broj dobitnika sa iznosom dobitaka, tj.izveštaj o tekućem kolu), informacije o organizatoru i organizaciji humanitarne pomoći, kontakt.
SQL baza će sadržati tabele: dobitnici, fond, grad, humanitarni fond, kolo, kombinacija, korisnik, tiket, transakcija, vrsta dobitnika.

  Bazu ćemo napuniti sa podacima dvadesetak korisnika, zbog prezentacije, dok će sa same stranice moći da se unesu novi podaci o korisniku registracijom.
  Izrada projekta će se izvršiti pomoću softvera Microsoft Visual Studio 2017., kao ASP.NET aplikacija, sa strukturom za MVC projekat (master page).
  Za dizajn korisničkog interfejsa ćemo koristiti CSS, javascript i  Bootstrap biblioteku.
  
                                                    APLIKACIJA-IZGLED-NAVIGACIJA

  Aplikaciju smo napravile pomoću empty web formi asp sa master page-om. Sastoji se od više stranica, glavna je master strana – na kojoj smo formirali header I footer koji je zajednički svim ostalim stranama, kao I navigacija, tj. Linkovi ka većini strana. Koristile smo bootstrap zbog responzivnosti, to znači da je aplikacija prilagodljiva svim uređajima. Navigacija se sastoji iz linkova ka početnoj, o igri, rezultati, o nama, kontakt, prijavi I registruj se, I igraj dugme. Stranice o igri, o nama i kontakt sadrže samo informacije o sajtu I organizatorima. Bilo koji posetilac sajta ima pristupsvim stranama osim samoj igri, za to mora biti ulogovan odnosno registrovan korisnik.  Samim tim stranica za registraciju korisnika sadrži obe forme, i login i registruj, koje smo uredile pomoću css-a. Logiku smo uredile tako da ukoliko korisnik pokuša da se prijavi, a lozinka ili ime nisu ispravno uneti / ne postoje , ispisuje se poruka, koja korisnika obaveštava da nije ispravno uneo. Ako korisnik zna da nema registrovan nalog, može otići na drugi panel za registraciju, u kojem unosi podatke neophodne za registraciju. Ukoliko ne unese određeni podatak, pomoću required naredbe, odredile smo da ga upozori da nije sve popunjeno. Nakon ipravno unesene registracije potvrđujemo je pomoću dugmeta registruj se, panel za registraciju prestaje da bude vidljiv, i prikazuje nam se poruka o uspešnoj registraciji. Nakon toga možemo da se ulogujemo. 

  U momentu kada se korisnik uloguje u headeru se dugme na kojem piše prijavi/registruj menja na “Odjavi se”. Klikom na to dugme ćemo se sada odjaviti I vratiti na login stranu. Sad kad smo ulogovani možemo da igramo tiket. Klikom na igraj dugme dolazimo na stranu IgrajTiket.  

  Na stranici igraj imamo dugme pomocu kojega se isčitava grid view sa ponuđenim brojevima za kombinaciju tiketa, odnosno jedan tiket za popunjavanje. Klikom na svaku ćeliju unutar tiketa prikazuje se u posebnoj labeli svaki broj koji smo dosad izabrali, sortiran. Namestile smo da postoji I opcija poništavanja nekog od odabranih brojeva. Korisnik svakim klikom ima pregled izabranog broja (ili poništenog) tako što menjamo boju ćelije.  

  Klikom na dugme potvrdi ako je dostignut maksimalan broj od 14 kombinacija, pozivamo metode koje izvršavaju upis kombinacije tj tiketa u bazu, stim što je sam tiket vezan za trenutno ulogovanog korisnika. Pošto smo uspešno napravili tiket, potrebno je upisati transakciju o uplati tiketa u vrednosti od 100 dinara u našu  bazu, pri čemu je takođe naglašeno da je tip te transakcije “tiket”. Nakon potvrde tiketa labela sa kombinacijama se menja na “uspešno ste uplatili tiket” I ispisana je poruka IZABERI NOVU KOMBINACIJU, I grid je vraćen na početno stanje.  

  Takođe u okviru stranice smo dodale da korisnik može imati uvid u sve uplaćene tikete koje je izvršio u tekućem kolu. Da korisniku ne bi bilo dosadno dodale smo link ka stranici koja sadrži igricu Cigle, koja je rađena u java scriptu. Opciono taj link može biti I ka nekoj igri na webu, jer je link ka igrici promenljiv. To bi bili eventualni sponzori lutrije, ili igrica nekog humanitarnog fonda. 

Dodale smo dugme pomoću kojeg bi se mogla uplatiti kombinacija nasumičnih brojeva tj 5 tiketa odjednom. 

  Na stranici rezultati prikazujemo podatke o završenom kolu. Koliko je uplaćeno tiketa, koliki je iznos fonda, koliko ima četvorka, šestica itd.... Ubacile smo I generator nasumičnih brojeva gde klikom na dugme dobitna kombinacija, imamo prikaz sa desne strane nasumičnih 7 brojeva. Ovaj generator bi mogao služiti za izvlačenje dobitne kombinacije trenutnog kola. Međutim naša ideja je da bi dobitna kombinacija trebala biti ona koja se dobija u zvaničnom izvlačenju državne lutrije Srbije, jer bi na taj način bila oneomogućena mogucnost zloupotrebe, tj. Nameštanja rezultata.  

  Na početnoj strani nam se nalazi tajmer/brojač do početka izvlačenja u kome smo trenutno formirale istek vremena datum ovog ispita / služio nam je kao podsetnik koliko nam je preostalo vremena. Zašto ga nismo vezale za istek kola? Zato što testiranje apliakcije ne možemo raditi u realnom vremenu. Simulaciju tajmera vršimo pomoću dva dugmeta, jedno za započinjanje kola drugo za završetak kola. Klikom na započni kolo zamenjujemo početak tajmera. Kada započinjemo kolo dodajemo novo kolo u bazu, koje se završava tri dana nakon početka.  

  Klikom na završi kolo smenjujemo događaj isteka tajmera. Kada se završi kolo prebrojavaju se dobitnici, dopunjuje se fond sa naplaćenim tiketima I prenesenim fondom ako ga ima, dodeljuju se nagrade zavisno od dobitaka, fond se ažurira za sledeće kolo, I prikazuje prethodno pomenute rezultate na samoj stranici. 

 
  Treba napomenuti da smo omgućile da se administrator uloguje na sajt. Stranice koje su vidljive administratoru u tom slučaju nisu vidljive drugim korisnicima (ovo proveravamo pomoću tipa korisnika u bazi). Formirale smo dve stranice za admina. Navigacija ka njima je vidljivda u headeru u vidu dropdown-a. Na ove dve stranice admin može da ili ukloni sve neaktivne korisnike (nisu bili u logovani duže od tri meseca), ili da doda nov humanitarni fond u bazu (naziv, opis I broj računa fonda). 

  Nama je primarno bilo da igra funkcioniše, a admin strane su dodate kako bi se prikazalo da administrator može da vrši promene I ima posebna prava pristupa. 


                                                   PROBLEMI

-Na stranici registruj prijavi morali smo da koristimo UseSubmitBehavior = “false” 

Potrebno je da određeno dugme postavimo da se ne ponaša kao submit dugme, jer ono mora da se izvrši bez obzira na neka polja na sajtu koja su “required” 

-Na buttonClickEvent stranica se refrešuje 

Ovo ponasanje nam nije uvek odgovaralo, na primer kod tiketa na stranici igrajTiket. Ovo smo rešile dodavanjem UpdatePanel-a sa ContentTemplate-om I ScriptManager-om. 

-Stranica Registruj/Prijavi kada se radi redirect na jednu od njih, druga ostaje skrivena, ali njena polja ostaju aktivna zbog css-a. 

-Ovo je pravilo veliki problem jer su polja bila required I prijavljivalo je greške sa nevidljivih mesta pri pokušaju da se loginuje/registruje korisnik. Rešile smo tako što smo uokvirile obe forme sa Panelom I onda taj panel činile vidljivim ili ne zavisno od toga u kojoj formi se nalazimo. 

--Ovo su bile glavne greške na koje smo nailazile I morale da ispravljamo. Ostale greške su u glavnom bile vezane za sam kod a ne za naše znanje iz asp-a pa ih nismo zato navele, jer bi ih bilo poprilicno. 

