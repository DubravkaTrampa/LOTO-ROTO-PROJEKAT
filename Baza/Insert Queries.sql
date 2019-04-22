  
  --Insert pocetnih kola , lazni podaci za testiranje, pravo kolo ce se kreirati u c#-u

  INSERT INTO Kola (datum,dobitna_kombinacija_id,redni_broj)
   VALUES
   ('2019-04-25',-1,1),
   ('2019-04-28',-1,2);

   -- Za Automatsko inkrementovanje novog id-a kombinacije tiketa
CREATE SEQUENCE dbo.SORT_ID_seq
    START WITH 1
    INCREMENT BY 1 ;
GO

	-- dodavanje inkrementovanja u tabelu
   ALTER TABLE dbo.Tiketi
	ADD [tiket_kombinacija_id] int not null  DEFAULT (NEXT VALUE FOR dbo.SORT_ID_seq);


	--Napraviti novi tiket za testiranje ubacivanja kombinacije. Realna implementacija u c#-u , ovo je za potrebe testa
   INSERT INTO Tiketi (fk_korisnici_id,fk_kola_id)
   VALUES (1,2);

   --dodavanje nove kombinacije sa id-em koji je tiket generisao u testu. U c#-u se ta vrednost id-a dodaje preko koda
   INSERT INTO Kombinacije (broj, kombinacija_id)
   VALUES (3,2),(6,2), (10,2),(13,2), (15,2), (20,2),
   (23,2), (27,2), (28,2), (30,2),(33,2),(35,2),(37,2),(39,2);

   -- Nakon uspesno unetog tiketa, zapisati transakciju u bazi vezanu za racun trenutnog korisnika.
   INSERT INTO Transakcije (iznos,datum,fk_racuni_id,tip_transakcije) VALUES 
   (100,'2019-04-21',2,'tiket');

   -- Napraviti pocetni unos u fondu u vrednosti od 0 dinara, jer fond mora da postoji.
   INSERT INTO Fondovi (stanje_na_fondu) VALUES
   (0);

   --ubacivanje transakcija zarad potreba testa. Nisu vezane za tiket, vec sluze za proveru punjenja fonda nakon zatvorenog kola
      INSERT INTO Transakcije (iznos,datum,fk_racuni_id) VALUES 
   (100,'2019-04-22',2);
      INSERT INTO Transakcije (iznos,datum,fk_racuni_id) VALUES 
   (100,'2019-04-23',2);
      INSERT INTO Transakcije (iznos,datum,fk_racuni_id) VALUES 
   (100,'2019-04-24',2);
      INSERT INTO Transakcije (iznos,datum,fk_racuni_id) VALUES 
   (100,'2019-04-25',2);

   -- bira sve transakcije izmedju dva datuma
   select iznos 
	from Transakcije
	where datum between '2019-04-20' AND '2019-04-23'
	
	--tip_transakcije ce biti definisan vrednostima(tiket,nagradna,organizatoru,humanitarna,drugo)
	
	ALTER TABLE dbo.Transakcije ADD [tip_transakcije] varchar (20) not null;
	DELETE FROM Transakcije;

	-- sabiranje vrednosti svih tiketa i dodavanje u fond kao dodatak na prethodni iznos fonda
	INSERT INTO Fondovi
	SELECT SUM(iznos)
	FROM Transakcije
	WHERE tip_transakcije = 'tiket' AND datum between '2019-04-20' AND '2019-04-23';

	--sabiranje pomocne tabele koja sadrzi vrednost koju dodajemo na prethodni fond
	INSERT INTO Fondovi
	SELECT SUM(stanje_na_fondu)
	FROM Fondovi
	WHERE [pk_fondovi_id] = (SELECT MAX(pk_fondovi_id) FROM Fondovi) OR   [pk_fondovi_id] = (SELECT MAX(pk_fondovi_id) FROM Fondovi)-1

	--nakon racunanja fonda potrebno je izbrisati pomocnu tabelu

	DELETE FROM Fondovi WHERE  [pk_fondovi_id] = (SELECT MAX(pk_fondovi_id) FROM Fondovi)-1




  
