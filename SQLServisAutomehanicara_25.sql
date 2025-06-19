create database ServisAutoMehanicara_25
use ServisAutoMehanicara_25

create table Vlasnik(
	vlasnik_id int Primary Key Identity(1,1),
	ime nvarchar(50),
	prezime nvarchar(50),
	email nvarchar(50),
	lozinka nvarchar(50),
	JMBG nvarchar(13),
)

create table Auto(
	auto_id int Primary Key Identity(1,1),
	marka nvarchar(50),
	registracija varchar(50),
	usluga_id int,
	vlasnik_id int
)

create table Usluga(
	usluga_id int Primary Key Identity(1,1),
	naziv nvarchar(50),
	cena int,
	datum_pocetka datetime,
	datum_zavrsetka datetime
)


create table Zaposleni(
	zaposleni_id int Primary Key Identity(1,1),
	ime nvarchar(50),
	prezime nvarchar(50),
	JMBG nvarchar(13),
	plata int,
	usluga_id int
)


Alter Table Auto
Add Constraint FK_Auto_Vlasnik
Foreign Key (vlasnik_id) References
Vlasnik(vlasnik_id)

Alter Table Auto
Add Constraint FK_Auto_Usluga
Foreign Key (usluga_id) References
Usluga(usluga_id)

Alter Table Zaposleni
Add Constraint FK_Zaposleni_Usluga
Foreign Key (usluga_id) References
Usluga(usluga_id)


/*Store Procedure TABELA Vlasnik*/
GO
Create PROC dbo.Vlasnik_Email
@email nvarchar(50),
@loz nvarchar(100)
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS(SELECT TOP 1 email FROM Vlasnik
	WHERE email = @email and lozinka=@loz)
	Begin
	RETURN 0
	end
	RETURN 1
END TRY
BEGIN CATCH
	RETURN @@error;
END CATCH
GO
/**/
GO
CREATE PROC Vlasnik_Insert
@ime nvarchar(50),
@prezime nvarchar(50),
@email nvarchar(50),
@loz nvarchar(50),
@jmbg nvarchar(13)
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
IF EXISTS (SELECT TOP 1 email FROM Vlasnik
	WHERE email = @email  )
	Return 1
	else
	Insert Into Vlasnik(ime,prezime,email,lozinka,jmbg)
	Values(@ime,@prezime,@email,@loz,@jmbg)
		RETURN 0;
END TRY
	
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
/**/
GO
Create PROC dbo.Vlasnik_Update
@ime nvarchar(50),
@prezime nvarchar(50),
@email nvarchar(50),
@loz nvarchar(50),
@jmbg nvarchar(13)
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS (SELECT TOP 1 email FROM dbo.Vlasnik
	WHERE email = @email  )

	BEGIN
	
	Update Vlasnik  Set ime=@ime, prezime = @prezime, lozinka = @loz, jmbg = @jmbg  where email=@email 
		RETURN 0;
	END
	RETURN -1;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
/**/
GO
Create Proc Vlasnik_Delete
@email nvarchar(100)
as
Begin TRY
Delete from Vlasnik where email=@email
RETURN 0
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
/**/
/*Store Procedure tabela Auto*/
GO
CREATE PROC Auto_Insert
@marka nvarchar(50),
@registracija nvarchar(50),
@usluga_id int,
@vlasnik_id int
AS
SET LOCK_TIMEOUT 3000;

BEGIN TRY
IF EXISTS (SELECT TOP 1 registracija FROM Auto
	WHERE registracija = @registracija  )
	Return 1
	else
	Insert Into Auto(marka,registracija,usluga_id,vlasnik_id)
	Values(@marka, @registracija, @usluga_id, @vlasnik_id)
		RETURN 0;
END TRY
	

BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
/**/
GO
Create Proc Auto_Delete
@registracija nvarchar(50)
as
Begin TRY
Delete from Auto where registracija=@registracija
RETURN 0
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
/**/
GO
Create PROC Auto_Update
@auto_id int,
@marka nvarchar(50),
@registracija nvarchar(50),
@usluga_id int,
@vlasnik_id int
AS
SET LOCK_TIMEOUT 3000;

BEGIN TRY
	IF EXISTS (SELECT TOP 1 registracija FROM Auto
	WHERE auto_id = @auto_id )

	BEGIN
	
	Update Auto  Set marka=@marka, registracija = @registracija, usluga_id = @usluga_id, vlasnik_id = @vlasnik_id  where auto_id=@auto_id
		RETURN 0;
	END
	RETURN -1;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
/**/
/*Store Procedure tabela Usluga*/
GO
CREATE PROC Usluga_Insert
@naziv nvarchar(50),
@cena int,
@datum_pocetka datetime,
@datum_zavrsetka datetime
AS
SET LOCK_TIMEOUT 3000;

BEGIN TRY
IF EXISTS (SELECT TOP 1 naziv FROM Usluga
	WHERE naziv = @naziv)
	Return 1
	else
	Insert Into Usluga(naziv,cena,datum_pocetka,datum_zavrsetka)
	Values(@naziv, @cena, @datum_pocetka, @datum_zavrsetka)
		RETURN 0;
END TRY
	

BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
/**/
GO
Create Proc Usluga_Delete
@naziv nvarchar(50)
as
Begin TRY
Delete from Usluga where naziv=@naziv
RETURN 0
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
/**/
GO
Create PROC Usluga_Update
@usluga_id int,
@naziv nvarchar(50),
@cena int,
@datum_pocetka datetime,
@datum_zavrsetka datetime
AS
SET LOCK_TIMEOUT 3000;

BEGIN TRY
	IF EXISTS (SELECT TOP 1 naziv FROM Usluga
	WHERE usluga_id = @usluga_id )

	BEGIN
	
	Update Usluga  Set naziv=@naziv, cena = @cena, datum_pocetka=@datum_pocetka, datum_zavrsetka=@datum_zavrsetka  where usluga_id=@usluga_id
		RETURN 0;
	END
	RETURN -1;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
/**/
/*Store Procedure tabela Zaposleni*/
GO
CREATE PROC Zaposleni_Insert
@ime nvarchar(50),
@prezime nvarchar(50),
@jmbg nvarchar(13),
@plata int,
@usluga_id int
AS
SET LOCK_TIMEOUT 3000;

BEGIN TRY
IF EXISTS (SELECT TOP 1 jmbg FROM Zaposleni
	WHERE jmbg = @jmbg)
	Return 1
	else
	Insert Into Zaposleni(ime, prezime, jmbg, plata, usluga_id)
	Values(@ime, @prezime, @jmbg, @plata, @usluga_id)
		RETURN 0;
END TRY
	

BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
/**/
GO
Create Proc Zaposleni_Delete
@jmbg nvarchar(13)
as
Begin TRY
Delete from Zaposleni where jmbg=@jmbg
RETURN 0
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
/**/
GO
Create PROC Zaposleni_Update
@zaposleni_id int,
@ime nvarchar(50),
@prezime nvarchar(50),
@jmbg nvarchar(13),
@plata int,
@usluga_id int
AS
SET LOCK_TIMEOUT 3000;

BEGIN TRY
	IF EXISTS (SELECT TOP 1 jmbg FROM Zaposleni
	WHERE zaposleni_id = @zaposleni_id)

	BEGIN
	
	Update Zaposleni  Set ime=@ime, prezime = @prezime, jmbg = @jmbg, plata = @plata, usluga_id = @usluga_id  where zaposleni_id=@zaposleni_id
		RETURN 0;
	END
	RETURN -1;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
/**/

GO
CREATE PROC ZaposleniDelete
@id int
AS 
BEGIN TRY
DELETE FROM Zaposleni where zaposleni_id = @id
RETURN 0
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH;
GO


GO
CREATE PROC UslugaDelete
@id int
AS 
BEGIN TRY
DELETE FROM Usluga where usluga_id = @id
RETURN 0
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH;
GO

GO
CREATE PROC VlasnikDelete
@id int
AS 
BEGIN TRY
DELETE FROM Vlasnik where vlasnik_id = @id
RETURN 0
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH;
GO

GO
CREATE PROC AutoDelete
@id int
AS 
BEGIN TRY
DELETE FROM Auto where auto_id = @id
RETURN 0
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH;
GO

GO
CREATE PROC Vlasnik_Info
@email nvarchar(50)
AS
SELECT v.ime, v.prezime, v.email, v.lozinka, v.JMBG FROM Vlasnik v
WHERE v.email = @email
GO

GO
CREATE PROC Usluga_Info
@id int
AS
SELECT u.naziv, u.cena, u.datum_pocetka, u.datum_zavrsetka FROM Usluga u
WHERE u.usluga_id = @id
GO

GO
CREATE PROC Auto_Info
@id int
AS
SELECT a.marka, a.registracija, a.usluga_id FROM Auto a
WHERE a.auto_id = @id
GO

GO
CREATE PROC Zaposleni_Info
@id int
AS
SELECT z.ime, z.prezime, z.JMBG, z.plata, z.usluga_id FROM Zaposleni z
WHERE z.zaposleni_id = @id
GO

