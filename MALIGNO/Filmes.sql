create table Filmes(
id int identity(1,1) not null primary key,
nome varchar(20) not null,
sinopse varchar(100),
genero varchar(15) not null,
duracao int not null,
trailer varchar(10)
)