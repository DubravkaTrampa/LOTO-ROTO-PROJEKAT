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
