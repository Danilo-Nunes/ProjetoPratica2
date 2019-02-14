create table Aluno(
codigo int primary key indentity(1,1) not null,
ra char(5) not null,
nome varchar(50) not null,
nomeUsu varchar(50) not null,
senha varchar(50) not null
)

create table Professor(
codigo int primary key indentity(1,1) not null,
nome varchar(50) not null
nomeUsu varchar(50) not null,
senha varchar(50) not null
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

create table Atividade(
codigo int primary key indentity(1,1) not null,
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


