create table Aluno(
codigo int primary key indentity(1,1) not null,
ra char(5) not null,
nome varchar(50) not null,
)

create table Professor(
codigo int primary key indentity(1,1) not null,
nome varchar(50) not null
)

create table Sala(
codigo int primary key indentity(1,1) not null,
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

create table Prova(
codigo int primary key indentity(1,1) not null,
numero int not null,
codSala int not null,
dataProva datetime not null,
constraint fkSalaProva foreign key(codSala) references Sala(codigo)
)


create table Projeto( //ESTEBAN AJUDOU A FAZER ESSA TABELA
codigo int primary key indentity(1,1) not null,
numero int not null,
codSala int not null,
dataEntrega datetime not null,
constraint fkSalaProva foreign key(codSala) references Sala(codigo)
)

create table AlunoProva(
codAluno int not null,
codProva int not null,
peso int not null,
nota int not null,
constraint fkAluno foreign key(codAluno) references Aluno(codigo),
constraint fkProva foreign key(codProva) references Prova(codigo)
)

create table AlunoProjeto(
codAluno int not null,
codProjeto int not null,
peso int not null,
nota int not null,
constraint fkAlunoProjeto foreign key(codAluno) references Aluno(codigo),
constraint fkProjeto foreign key(codProjeto) references Projeto(codigo)
)


