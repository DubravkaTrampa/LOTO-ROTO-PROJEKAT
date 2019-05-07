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

