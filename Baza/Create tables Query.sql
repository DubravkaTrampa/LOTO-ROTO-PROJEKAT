-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************


-- ************************************** [dbo].[Racuni]

CREATE TABLE [dbo].[Racuni]
(
 [pk_racuni_id] int IDENTITY(1,1) NOT NULL ,
 [broj_racuna]  varchar(50) NOT NULL ,

 CONSTRAINT [PK_Racun] PRIMARY KEY CLUSTERED ([pk_racuni_id] ASC)
);
GO


-- ************************************** [dbo].[Transakcije]

CREATE TABLE [dbo].[Transakcije]
(
 [pk_transakcije_id] int IDENTITY(1,1) NOT NULL ,
 [iznos]             int NOT NULL ,
 [datum]             date NOT NULL ,
 [fk_racuni_id]      int NOT NULL ,

 CONSTRAINT [PK_Transakcija] PRIMARY KEY CLUSTERED ([pk_transakcije_id] ASC),
 CONSTRAINT [FK_66] FOREIGN KEY ([fk_racuni_id])  REFERENCES [dbo].[Racuni]([pk_racuni_id])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_66] ON [dbo].[Transakcije] 
 (
  [fk_racuni_id] ASC
 )

GO

-- ************************************** [dbo].[Korisnici]

CREATE TABLE [dbo].[Korisnici]
(
 [pk_korisnici_id] int IDENTITY(1,1)  NOT NULL ,
 [username]        varchar(50) NOT NULL ,
 [password]        varchar(50) NOT NULL ,
 [ime]             nvarchar(30) NOT NULL ,
 [prezime]         nvarchar(30) NOT NULL ,
 [datum_rodjenja]  date NOT NULL ,
 [log_in_date]     date NOT NULL ,
 [log_in_time]     time(7) NOT NULL ,
 [adresa]          nvarchar(50) NOT NULL ,
 [telefon]         nvarchar(50) NOT NULL ,
 [email]           nvarchar(50) NOT NULL ,
 [tip_korisnika]   varchar(5) NOT NULL ,
 [fk_racuni_id]    int NOT NULL ,

 CONSTRAINT [PK_Korisnik] PRIMARY KEY CLUSTERED ([pk_korisnici_id] ASC),
 CONSTRAINT [FK_72] FOREIGN KEY ([fk_racuni_id])  REFERENCES [dbo].[Racuni]([pk_racuni_id])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_72] ON [dbo].[Korisnici] 
 (
  [fk_racuni_id] ASC
 )

GO

-- ************************************** [dbo].[Fondovi]


CREATE TABLE [dbo].[Fondovi]
(
 [pk_fondovi_id]     int IDENTITY(1,1)  NOT NULL ,
 [stanje_na_fondu]   bigint NOT NULL,
 
 CONSTRAINT [PK_Fond] PRIMARY KEY CLUSTERED ([pk_fondovi_id] ASC),
 );
GO


CREATE NONCLUSTERED INDEX [fkIdx_87] ON [dbo].[Fondovi] 
 (
  [fk_transakcije_id] ASC
 )

GO

-- ************************************** [dbo].[Kola]

CREATE TABLE [dbo].[Kola]
(
 [pk_kola_id]             int IDENTITY(1,1) NOT NULL ,
 [datum]                  date NOT NULL ,
 [dobitna_kombinacija_id] int NOT NULL ,
 [redni_broj]             int NOT NULL ,

 CONSTRAINT [PK_Kolo] PRIMARY KEY CLUSTERED ([pk_kola_id] ASC)
);
GO

-- ************************************** [dbo].[Tiketi]

CREATE TABLE [dbo].[Tiketi]
(
 [pk_tiketi_id]         int IDENTITY(1,1) NOT NULL ,
 [fk_korisnici_id]      int NOT NULL ,
 [fk_kola_id]           int NOT NULL ,
 [tiket_kombinacija_id] int NOT NULL ,

 CONSTRAINT [PK_Tiket] PRIMARY KEY CLUSTERED ([pk_tiketi_id] ASC),
 CONSTRAINT [FK_42] FOREIGN KEY ([fk_korisnici_id])  REFERENCES [dbo].[Korisnici]([pk_korisnici_id]),
 CONSTRAINT [FK_78] FOREIGN KEY ([fk_kola_id])  REFERENCES [dbo].[Kola]([pk_kola_id])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_42] ON [dbo].[Tiketi] 
 (
  [fk_korisnici_id] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_78] ON [dbo].[Tiketi] 
 (
  [fk_kola_id] ASC
 )

GO



-- ************************************** [dbo].[Dobitnici]

-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [dbo].[Dobitnici]
USE LotoRotoNovo

CREATE TABLE [dbo].[Dobitnici]
(
 [pk_dobitnici_id]  int Identity(1,1) NOT NULL ,
 [vrsta_pogotka]   varchar(50) NOT NULL ,
 [fk_tiketi_id]    int NOT NULL ,
 [fk_racuni_id]    int NOT NULL ,
 [fk_kola_id]      int NOT NULL ,


 CONSTRAINT [FK_103] FOREIGN KEY ([fk_kola_id])  REFERENCES [dbo].[Kola]([pk_kola_id]),
 CONSTRAINT [FK_81] FOREIGN KEY ([fk_tiketi_id])  REFERENCES [dbo].[Tiketi]([pk_tiketi_id]),
 CONSTRAINT [FK_84] FOREIGN KEY ([fk_racuni_id])  REFERENCES [dbo].[Racuni]([pk_racuni_id])
);
GO


CREATE UNIQUE CLUSTERED INDEX [PK_Dobitnik] ON [dbo].[Dobitnici] 
 (
  [pk_dobitnici_id] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_103] ON [dbo].[Dobitnici] 
 (
  [fk_kola_id] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_81] ON [dbo].[Dobitnici] 
 (
  [fk_tiketi_id] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_84] ON [dbo].[Dobitnici] 
 (
  [fk_racuni_id] ASC
 )

GO



-- ************************************** [dbo].[Humanitarni_Fondovi]

CREATE TABLE [dbo].[Humanitarni_Fondovi]
(
 [pk_humanitarni_fondovi_id] int IDENTITY(1,1) NOT NULL ,
 [naziv]                     varchar(50) NOT NULL ,
 [fk_racuni_id]              int NOT NULL ,

 CONSTRAINT [PK_Humanitarni_Fond] PRIMARY KEY CLUSTERED ([pk_humanitarni_fondovi_id] ASC),
 CONSTRAINT [FK_69] FOREIGN KEY ([fk_racuni_id])  REFERENCES [dbo].[Racuni]([pk_racuni_id])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_69] ON [dbo].[Humanitarni_Fondovi] 
 (
  [fk_racuni_id] ASC
 )

GO

-- ************************************** [dbo].[Kombinacije]

CREATE TABLE [dbo].[Kombinacije]
(
 [pk_kombinacije_id] int IDENTITY(1,1) NOT NULL ,
 [broj]              int NOT NULL ,
 [kombinacija_id]    int NOT NULL ,

 CONSTRAINT [PK_Kombinacija] PRIMARY KEY CLUSTERED ([pk_kombinacije_id] ASC)
);
GO

-- ************** [dbo].[PostojiAktuelnoKolo]
CREATE TABLE [dbo].[PostojiAktuelnoKolo]
(
 pk_postoji_id int IDENTITY(1,1) NOT NULL ,
 [kolo_aktivno]  bit NOT NULL

 CONSTRAINT [PK_PostojiAktuelnoKolo] PRIMARY KEY CLUSTERED ([pk_postoji_id] ASC)
);
GO