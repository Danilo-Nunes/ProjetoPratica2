create table Aluno(
codigo int primary key identity(1,1) not null,
ra char(5) not null,--?
nome varchar(50) not null,
nomeUsu varchar(50) not null,
senha varchar(50) not null,
email varchar(50) not null
)

create table Professor(
codigo int primary key identity(1,1) not null,
nome varchar(50) not null,
nomeUsu varchar(50) not null,
senha varchar(50) not null,
email varchar(50) not null
)

create table Sala(
codigo int primary key identity(1,1) not null,
nome varchar(50) not null,
codProfessor int not null,
constraint fkcodProf foreign key(codProfessor) references Professor(codigo)
)

create table AlunoSala(
codAluno int not null,
codSala int not null,
media int not null,
faltas int not null,
constraint fkcodAluno foreign key(codAluno) references Aluno(codigo),
constraint fkSala foreign key(codSala) references Sala(codigo)
)

create table Atividade(
codigo int primary key identity(1,1) not null,
numero int not null,
codSala int not null,
dataAtividade datetime not null,
constraint fkSalaAtividade foreign key(codSala) references Sala(codigo)
)


create table AlunoAtividade(
codAluno int not null,
codAtividade int not null,
peso int not null,
nota int not null,
constraint fkAluno foreign key(codAluno) references Aluno(codigo),
constraint fkAtividade foreign key(codAtividade) references Atividade(codigo)
)

create table Comunicado(
codComunicado int primary key identity(1,1) not null,
codSala int not null,
texto varchar(500) not null,
assunto varchar(50) not null,
constraint fkSala foreign key (codSala) references Sala(codigo)
)

create table Compromissos(
codCompromisso int primary key identity(1,1) not null,
texto varchar(500) not null,
dataComp datetime not null,
codAluno int not null,
constraint fkAlunoComp foreign key (codAluno) references Aluno(codigo)
)

create proc SalaAlunos
@codSala int
as
select * from Aluno where codigo in (select codAluno from AlunoSala where codSala = @codSala)

create proc SalasAluno
@codAluno int
as
select * from Sala where codigo in (select codSala from AlunoSala where codAluno = @codAluno)

create proc ComunicadoAluno
@codAluno int
as
select * from Comunicado where codSala in (select codSala from AlunoSala where codAluno = @codAluno)







