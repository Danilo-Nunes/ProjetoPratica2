create table Filmes(
id int identity(1,1) not null primary key,
nome varchar(30) not null,
sinopse ntext,
genero varchar(20) not null,
duracao int not null,
trailer varchar(10)
)

insert into Filmes values('Pedrão conquista a américa','O pequeno e tetudo Pedro Gomes Moreira vioaja com seus subordinados, Felipe Scherer Vicentin e Guilherme Salim de Barros em busca de altas aventuras para um mar de tesouros, durante a viagem enfrentam vários obstáculos os quais pedrão mata com um corte, então acabou e todo mundo morreu','Aventura', 8000,'arroz')
insert into Filmes values('Malignos','666','666', 666,'666')

