create table Books
(
	[Id] uniqueidentifier not null primary key,
	[Name] nvarchar(max) null,
	[Price] int not null,
)