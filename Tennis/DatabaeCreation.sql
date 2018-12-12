
use Presentazioni;

create table autori(
id int identity(1,1) primary key,
nome varchar(25) not null,
email varchar(25) not null,
telefono varchar(25) not null,
skill varchar(25) not null);

create table presentazioni(
id int identity(1,1) primary key,
titolo varchar(25) not null,
inizio datetime not null,
fine datetime not null,
livello varchar(25) not null);

create table registrazioni(
autore int not null,
presentazione int not null,
constraint chiave_primaria primary key(autore,presentazione),
constraint chiave_esterna_autori foreign key(autore) references autori(id),
constraint chiave_esterna_presentazioni foreign key(presentazione) references presentazioni(id));
