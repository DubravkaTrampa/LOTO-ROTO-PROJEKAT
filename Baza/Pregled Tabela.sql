/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [pk_fondovi_id]
	  ,[stanje_na_fondu]
  FROM [LotoRotoNovo].[dbo].[Fondovi]

  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [pk_dobitnici_id]
      ,[vrsta_pogotka]
      ,[fk_tiketi_id]
      ,[fk_racuni_id]
	  ,[fk_kola_id]
  FROM [LotoRotoNovo].[dbo].[Dobitnici]

  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [pk_humanitarni_fondovi_id]
      ,[naziv]
      ,[fk_racuni_id]
	  ,[opis_humanitarnog_fonda]
  FROM [LotoRotoNovo].[dbo].[Humanitarni_Fondovi]

  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [pk_kola_id]
      ,[datum]
      ,[dobitna_kombinacija_id]
      ,[redni_broj]
  FROM [LotoRotoNovo].[dbo].[Kola]

  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [pk_kombinacije_id]
      ,[broj]
      ,[kombinacija_id]
  FROM [LotoRotoNovo].[dbo].[Kombinacije]

  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [pk_korisnici_id]
      ,[username]
      ,[password]
      ,[ime]
      ,[prezime]
      ,[datum_rodjenja]
      ,[log_in_date]
      ,[log_in_time]
      ,[adresa]
      ,[telefon]
      ,[email]
      ,[tip_korisnika]
      ,[fk_racuni_id]
  FROM [LotoRotoNovo].[dbo].[Korisnici]

  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [pk_racuni_id]
      ,[broj_racuna]
  FROM [LotoRotoNovo].[dbo].[Racuni]

  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [pk_tiketi_id]
      ,[fk_korisnici_id]
      ,[fk_kola_id]
      ,[tiket_kombinacija_id]
  FROM [LotoRotoNovo].[dbo].[Tiketi]

  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [pk_transakcije_id]
      ,[iznos]
      ,[datum]
      ,[fk_racuni_id]
	  ,[tip_transakcije]
  FROM [LotoRotoNovo].[dbo].[Transakcije]

  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [pk_postoji_id]
      ,[kolo_aktivno]
  FROM [LotoRotoNovo].[dbo].[PostojiAktuelnoKolo]