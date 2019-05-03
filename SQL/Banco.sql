create table Usuario(
codigo int primary key identity(1,1) not null,
ra char(5) not null,--?
nome varchar(50) not null,
nomeUsu varchar(50) not null,
cargo char(1) not null,
senha varchar(50) not null,
img varchar(100) not null,
email varchar(50) not null
)



create table Sala(
id int primary key identity(1,1) not null,
nome varchar(50) not null,
codUsuario int not null,
constraint fkcodProf foreign key(codUsuario) references Usuario(id)
)

create table UsuarioSala(
codUsuario int not null,
codSala int not null,
media int not null,
faltas int not null,
constraint fkcodUsuario foreign key(codUsuario) references Usuario(id),
constraint fkSala foreign key(codSala) references Sala(id)
)

create table Atividade(
id int primary key identity(1,1) not null,
numero int not null,
codSala int not null,
dataAtividade datetime not null,
constraint fkSalaAtividade foreign key(codSala) references Sala(id)
)




create table UsuarioAtividade(
codUsuario int not null,
codAtividade int not null,
peso int not null,
nota int not null,
constraint fkUsuario foreign key(codUsuario) references Usuario(id),
constraint fkAtividade foreign key(codAtividade) references Atividade(id)
)

create table Comunicado(
id int primary key identity(1,1) not null,
codSala int not null,
texto varchar(500) not null,
assunto varchar(50) not null,
constraint fkSalaComun foreign key (codSala) references Sala(codigo)
)



create table Compromisso(
id int primary key identity(1,1) not null,
texto varchar(500) not null,
dataComp datetime not null,
codUsuario int not null,
constraint fkUsuarioComp foreign key (codUsuario) references Usuario(codigo)
)

create proc SalaUsuario
@codSala int
as
select * from Usuario where codigo in (select codUsuario from UsuarioSala where codSala = @codSala)

create proc SalasUsuario
@codUsuario int
as
select * from Sala where codigo in (select codSala from UsuarioSala where codUsuario = @codUsuario)

create proc ComunicadoUsuario
@codUsuario int
as
select * from Comunicado where codSala in (select codSala from UsuarioSala where codUsuario = @codUsuario)






