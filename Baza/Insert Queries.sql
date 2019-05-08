  
  /*
  
  INSERT INTO Racuni (broj_racuna) VALUES ('111222333444555666');
  INSERT INTO Racuni (broj_racuna) VALUES ('666555444333222111');
  INSERT INTO Racuni (broj_racuna) VALUES ('555666444333222111');
  INSERT INTO Racuni (broj_racuna) VALUES ('444555666333222111');
  INSERT INTO Racuni (broj_racuna) VALUES ('333444555666222111');
  INSERT INTO Racuni (broj_racuna) VALUES ('222333444555666111');
  INSERT INTO Racuni (broj_racuna) VALUES ('111333555666444222');
  INSERT INTO Racuni (broj_racuna) VALUES ('111333555222444666');
  INSERT INTO Racuni (broj_racuna) VALUES ('222444666111333555');
  INSERT INTO Racuni (broj_racuna) VALUES ('222444666555333111');
  INSERT INTO Racuni (broj_racuna) VALUES ('123456123456123456');
  INSERT INTO Racuni (broj_racuna) VALUES ('112233445566123456');



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

	--Ciscenje svih tabela nakon raznih testiranja
	DELETE FROM dbo.Fondovi
	DELETE FROM dbo.Dobitnici
	DELETE FROM dbo.Humanitarni_Fondovi
	DELETE FROM dbo.Kola
	DELETE FROM dbo.Kombinacije
	DELETE FROM dbo.Korisnici
	DELETE FROM dbo.Racuni
	DELETE FROM dbo.Tiketi
	DELETE FROM dbo.Transakcije

	INSERT INTO Humanitarni_Fondovi (naziv, fk_racuni_id) VALUES ('Crveni Krst' , 3)

	INSERT INTO Dobitnici (vrsta_pogotka,fk_tiketi_id,fk_racuni_id) VALUES 
	('7',21,8),
	('6',20,9),
	('6',19,10),
	('5',18,11),
	('5',17,7),
	('5',16,7),
	('4',15,8),
	('4',14,8),
	('4',13,13),
	('4',12,6)

   INSERT INTO Kombinacije (broj, kombinacija_id)
   VALUES (1,24),(4,24), (7,24),(10,24), (13,24), (16,24),
   (17,24);

	SELECT COUNT(*) FROM Tiketi WHERE fk_kola_id = 10;
	SELECT COUNT(*) FROM Dobitnici;

	UPDATE Korisnici
	SET log_in_date = '2019-01-25'
	WHERE ime = 'Neaktivan'

	DELETE FROM Korisnici  WHERE log_in_date < '2019-01-30'

	ALTER TABLE Humanitarni_Fondovi
	ADD opis_humanitarnog_fonda varchar(400);

	INSERT INTO Humanitarni_Fondovi(naziv,opis_humanitarnog_fonda,fk_racuni_id)
	 VALUES('Humanitarni fond 1', 'Ovaj fond potpomaze ljudima kojima je novac najpotrebniji',3);

	SELECT [tiket_kombinacija_id] FROM Tiketi WHERE fk_korisnici_id = 3 AND fk_kola_id = 10

	SELECT [broj] FROM Kombinacije WHERE kombinacija_id = 12
									  OR kombinacija_id = 13
									  OR kombinacija_id = 19
	
	SELECT MAX(redni_broj) FROM Kola 

	INSERT INTO Kola (datum,redni_broj,dobitna_kombinacija_id) VALUES 
	('2019-05-05', (SELECT MAX(redni_broj)+1 FROM Kola), 24)

	SELECT datum FROM Kola WHERE [pk_kola_id] = (SELECT MAX(pk_kola_id) FROM Kola)

	SELECT pk_kola_id FROM Kola WHERE pk_kola_id = (SELECT MAX(pk_kola_id) FROM Kola)

	SELECT datum FROM Kola WHERE pk_kola_id = (SELECT MAX(pk_kola_id) FROM Kola)-1

	INSERT INTO [PostojiAktuelnoKolo] ([kolo_aktivno]) VALUES ('false')

	UPDATE PostojiAktuelnoKolo SET kolo_aktivno = 'true'

	SELECT kolo_aktivno FROM PostojiAktuelnoKolo */

	SELECT COUNT(*) AS broj FROM Dobitnici WHERE vrsta_pogotka = '5'
	 AND fk_kola_id  =( SELECT MAX(pk_kola_id) FROM Kola) ; 

	 SELECT MAX(pk_kola_id) FROM Kola
