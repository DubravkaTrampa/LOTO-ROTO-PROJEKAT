--EXEC sp_changedbowner 'sa' 

--Inicijalno testiranje podataka:

--SELECT * FROM LotoRotoNovo.dbo.Korisnici;
--SELECT * FROM LotoRotoNovo.dbo.Racuni;
--SELECT * FROM LotoRotoNovo.dbo.Kola;
--SELECT * FROM LotoRotoNovo.dbo.Tiketi ORDER BY fk_korisnici_id;
--SELECT * FROM LotoRotoNovo.dbo.Kombinacije;
--SELECT * FROM LotoRotoNovo.dbo.Dobitnici ORDER BY fk_tiketi_id;
--SELECT * FROM LotoRotoNovo.dbo.Transakcije;
--SELECT * FROM LotoRotoNovo.dbo.Fondovi;
--SELECT * FROM LotoRotoNovo.dbo.Humanitarni_Fondovi;


----koliko brojeva ima svaka kombinacija?
--SELECT kombinacija_id, COUNT(*) AS cnt 
--FROM LotoRotoNovo.dbo.Kombinacije
--GROUP BY kombinacija_id;



--lista dobitnika poslednjeg kola:

CREATE PROCEDURE NadjiDobitnike
AS
WITH 
poslednje_kolo AS 
	(SELECT pk_kola_id, datum, dobitna_kombinacija_id
	FROM LotoRotoNovo.dbo.Kola
	WHERE LotoRotoNovo.dbo.Kola.pk_kola_id = 
		(SELECT MAX(LotoRotoNovo.dbo.Kola.pk_kola_id) 
			FROM LotoRotoNovo.dbo.Kola)
	),

dobitna_kombinacija AS 
	(SELECT *
	FROM LotoRotoNovo.dbo.Kombinacije
	WHERE kombinacija_id = 
		(SELECT dobitna_kombinacija_id
		FROM poslednje_kolo)
	),

tiketi_poslednjeg_kola AS
	(SELECT *
	FROM LotoRotoNovo.dbo.Tiketi
	WHERE fk_kola_id = 
		(SELECT pk_kola_id
		FROM poslednje_kolo)
	),

kombinacije_sa_tiketa AS
	(SELECT * 	
	FROM LotoRotoNovo.dbo.Kombinacije
	WHERE kombinacija_id IN 
		(SELECT tiket_kombinacija_id
		FROM tiketi_poslednjeg_kola)
	),

lista_pogodaka AS
	(SELECT kt.broj, kt.kombinacija_id
	FROM 
	dobitna_kombinacija dk
	INNER JOIN kombinacije_sa_tiketa kt ON dk.broj = kt.broj),

rezultat_kola AS
	(SELECT kombinacija_id, COUNT(*) AS vrsta_pogotka
	FROM lista_pogodaka
	GROUP BY kombinacija_id)

SELECT pk.pk_kola_id, pk.datum, pk.dobitna_kombinacija_id, rk.kombinacija_id, rk.vrsta_pogotka, t.pk_tiketi_id, k.ime, k.prezime, k.fk_racuni_id
FROM rezultat_kola rk
INNER JOIN LotoRotoNovo.dbo.Tiketi t ON t.tiket_kombinacija_id = rk.kombinacija_id
INNER JOIN LotoRotoNovo.dbo.Korisnici k ON K.pk_korisnici_id = t.fk_korisnici_id
CROSS JOIN poslednje_kolo pk 
WHERE rk.vrsta_pogotka > 3
ORDER BY rk.kombinacija_id;



--uplaćene kombinacije za poslednje kolo:
WITH 
poslednje_kolo AS 
	(SELECT pk_kola_id, datum, dobitna_kombinacija_id
	FROM LotoRotoNovo.dbo.Kola
	WHERE  LotoRotoNovo.dbo.Kola.pk_kola_id = 
		(SELECT MAX(LotoRotoNovo.dbo.Kola.pk_kola_id) 
			FROM LotoRotoNovo.dbo.Kola)
	),

tiketi_poslednjeg_kola AS
	(SELECT *
	FROM LotoRotoNovo.dbo.Tiketi
	WHERE fk_kola_id = 
		(SELECT pk_kola_id
		FROM poslednje_kolo)
	),

kombinacije_sa_tiketa AS
	(SELECT * 	
	FROM LotoRotoNovo.dbo.Kombinacije
	WHERE kombinacija_id IN 
		(SELECT tiket_kombinacija_id
		FROM tiketi_poslednjeg_kola)
	)

SELECT pk.pk_kola_id, pk.datum, k.ime, k.prezime, t.pk_tiketi_id
FROM LotoRotoNovo.dbo.Tiketi t
INNER JOIN LotoRotoNovo.dbo.Korisnici k ON t.fk_korisnici_id = k.pk_korisnici_id
INNER JOIN poslednje_kolo pk ON pk.pk_kola_id = t.fk_kola_id
ORDER BY k.ime, k.prezime, t.pk_tiketi_id;


EXEC ObradiTiketeNadjiDobitnike