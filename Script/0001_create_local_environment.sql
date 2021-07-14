create database covid;


use covid;





GO
IF NOT EXISTS ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Countries') 
BEGIN
create table Countries(
	Id varchar(36) NOT NULL,
	Name varchar(100) NOT NULL,
	primary key(Id)
);
END


GO
IF NOT EXISTS ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Results') 
BEGIN
	create table Results(
		Id varchar(36) NOT NULL,
		Description varchar(6) NOT NULL,
		primary key(Id)
	);
END

GO
IF NOT EXISTS ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'People') 
BEGIN
	create table People(
		Id varchar(36) NOT NULL,
		Name varchar(100) NOT NULL,
		IdCountry varchar(36) NOT NULL,
		IdResult varchar(36) NOT NULL,
		primary key(Id),
		foreign key(IdCountry) references Countries(Id),
		foreign key(IdResult) references Results(Id)
		
	);
END


GO
IF NOT EXISTS ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'DNA' ) 
AND EXISTS ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'People' ) 
BEGIN
	create table DNA(
		Id varchar(36) NOT NULL,
		Description varchar(6) NOT NULL,
		IdPerson varchar(36) NOT NULL,
		primary key(Id),
		foreign key (IdPerson) references People(Id)
	);

END