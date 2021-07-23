use covid;

GO
IF NOT EXISTS ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Countries') 
BEGIN
create table Countries(
	Id int NOT NULL IDENTITY(1,1),
	Name varchar(100) NOT NULL,
	primary key(Id)
);
END


GO
IF NOT EXISTS ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Results') 
BEGIN
	create table Results(
		Id int NOT NULL,
		Description varchar(50) NOT NULL,
		primary key(Id)
	);
END

GO
IF NOT EXISTS ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'DNA' ) 
BEGIN
	create table DNA(
		Id int NOT NULL IDENTITY(1,1),
		Description varchar(6) NOT NULL,
		primary key(Id)
	);

END

GO
IF NOT EXISTS ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'People') 
BEGIN
	create table People(
		Id int NOT NULL IDENTITY(1,1),
		Name varchar(100) NOT NULL,
		IdCountry int NOT NULL,
		IdResult int NOT NULL,
		primary key(Id),
		foreign key(IdCountry) references Countries(Id),
		foreign key(IdResult) references Results(Id)
		
	);
END

GO
IF EXISTS ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'DNA' ) 
AND EXISTS ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'People' ) 
AND NOT EXISTS ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'DNAPeople' ) 
BEGIN
	create table DNAPeople(
		Id int NOT NULL IDENTITY(1,1),
		IdDna int NOT NULL,
		IdPeople int NOT NULL,
		primary key(Id),		
		foreign key(IdDna) references DNA(Id),
		foreign key(IdPeople) references People(Id)
	);

END

