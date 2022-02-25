use AdventureWorksOBP
go

-------
--Kupac
create proc InsertKupac
	@ime nvarchar(50),
	@prezime nvarchar(50),
	@email nvarchar(100),
	@telefon nvarchar(50),
	@gradid int
as
begin
	insert into Kupac
	(Ime, Prezime, Email, Telefon, GradID)
	values(@ime, @prezime, @email, @telefon, @gradid)
end 
go

create proc DeleteKupac
	@id int
as
begin
	delete Kupac
	where IDKupac = @id
end
go

create proc GetKupac
	@id int
as
begin
	select * from Kupac
	where IDKupac = @id
end
go


create proc GetKupci
as
begin
	select *
	from Kupac
end
go

create proc UpdateKupac
	@id int,
	@ime nvarchar(50),
	@prezime nvarchar(50),
	@email nvarchar(100),
	@telefon nvarchar(50),
	@gradid int
as
begin
	update Kupac
	set Ime = @ime, Prezime = @prezime, Email = @email, Telefon = @telefon, GradID = @gradid
	where IDKupac = @id
end
go

------
--Grad

create proc GetGrad
	@id int
as
begin
	select * from Grad
	where IDGrad = @id
end
go

create proc GetGradovi
as
begin
	select * from Grad
end
go

create proc GetGradoviDrzave
	@id int
as
begin
	select * from Grad
	where DrzavaID = @id
end
go

--------
--Drzava

create proc GetDrzava
	@id int
as
begin
	select * from Drzava
	where IDDrzava = @id
end
go

create proc GetDrzave
as
begin
	select * from Drzava
end
go

----------
--Proizvod

create proc InsertProizvod
	@naziv nvarchar(100),
	@brojProizvoda nvarchar(50),
	@boja nvarchar(50),
	@minimalnaKolicina int,
	@cijena float,
	@potkategorija int
as
begin
	insert into Proizvod
	(Naziv, BrojProizvoda, Boja, MinimalnaKolicinaNaSkladistu, CijenaBezPDV, PotkategorijaID)
	values(@naziv, @brojProizvoda, @boja, @minimalnaKolicina, @cijena, @potkategorija)
end
go

create proc DeleteProizvod
	@id int
as
begin
	delete Stavka where ProizvodID = @id
	delete Proizvod where IDProizvod = @id
end
go

create proc GetProizvod
	@id int
as
begin
	select * from Proizvod
	where IDProizvod = @id
end
go

create proc GetProizvodi
as
begin
	select *
	from Proizvod
end
go

create proc UpdateProizvod
	@id int,
	@naziv nvarchar(100),
	@brojProizvoda nvarchar(50),
	@boja nvarchar(50),
	@minimalnaKolicina int,
	@cijena float,
	@potkategorija int
as
begin
	update Proizvod set Naziv = @naziv, BrojProizvoda = @brojProizvoda, Boja = @boja, MinimalnaKolicinaNaSkladistu = @minimalnaKolicina,
	CijenaBezPDV = @cijena, PotkategorijaID = @potkategorija
	where IDProizvod = @id
end
go

-------
--Racun

create proc GetRacun
	@id int
as
begin
	select * from Racun
	where IDRacun = @id
end
go


create proc GetRacuniKupca
	@kupacId int
as
begin
	select * from Racun
	where KupacID = @kupacId
end
go

--------
--Stavka

create proc GetStavka
	@id int
as
begin
	select * from Stavka
	where IDStavka = @id
end
go


create proc GetStavkeRacuna
	@id int
as
begin
	select * from Stavka
	where RacunID = @id
end
go


---------------
--Potkategorija

create proc InsertPotkategorija
	@naziv nvarchar(100), @id int
as
begin
	insert into Potkategorija
	(Naziv, KategorijaID)
	values(@naziv, @id)
end
go


create proc DeletePotkategorija
	@id int
as
begin
	delete Potkategorija where IDPotkategorija = @id
end
go

create proc GetPotkategorija
	@id int
as
begin
	select * from Potkategorija
	where IDPotkategorija = @id
end
go

create proc GetPotkategorije
as
begin 
	select * from Potkategorija
end
go

create proc UpdatePotkategorija
	@id int, 
	@naziv nvarchar(100),
	@idKat int
as
begin
	update Potkategorija 
	set Naziv = @naziv, KategorijaID = @idKat
	where IDPotkategorija = @id
end
go

------------
--Kategorija

create proc InsertKategorija
	@naziv nvarchar(50)
as
begin
	insert into Kategorija
	(Naziv)
	values(@naziv)
end
go


create proc UpdateKategorija
	@id int,
	@naziv nvarchar(100)
as
begin
	update Kategorija
	set Naziv = @naziv where IDKategorija = @id
end
go

create proc DeleteKategorija
	@id int
as
begin
	delete from Potkategorija where KategorijaID = @id
	delete from Kategorija where IDKategorija = @id
end
go

create proc GetKategorija
	@id int
as
begin
	select * from Kategorija
	where IDKategorija = @id
end
go

create proc GetKategorije
as
begin
	select * from Kategorija
end
go

---------------
--Komercijalist

create proc GetKomercijalist
	@id int
as
begin
	select * from Komercijalist
	where IDKomercijalist = @id
end
go

-----------------
--KreditnaKartica

create proc GetKreditnaKartica
	@id int
as
begin
	select * from KreditnaKartica
	where IDKreditnaKartica = @id
end
go

--------
--Pitura

create proc GetPiture
as
begin
	select distinct Boja 
	from Proizvod
end
go





















































