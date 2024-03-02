-- MAGASIN


create table marque(
    id varchar(20) primary key default nextval('marque_seq'),
    label varchar(200) not null 
);

create table reference(
    id varchar(20) primary key default nextval('reference_seq'),
    id_marque varchar(20) references marque(id),
    label varchar(200) not null 
);

create table processeur(
    id varchar(20) primary key default nextval('processeur_seq'),
    label varchar(200),
    frequence float not null ,
    coeur int not null ,
    gravure int not null 
);

create table ram(
    id varchar(20) primary key default nextval('ram_seq'),
    label varchar(200) not null ,
    puissance int not null 
);

create table disque_dur(
    id varchar(20) primary key default nextval('disque_dur_seq'),
    label varchar(200) not null ,
    stockage int not null ,
    rotation int not null ,
    taille int not null 
);

create table ecran(
    id varchar(20) primary key default nextval('ecran_seq'),
    label varchar(200) not null ,
    taille int
);

create table laptop(
    id varchar(20) primary key default nextval('laptop_seq'),
    id_reference varchar(20) references reference(id),
    id_processeur varchar(20) references processeur(id),
    id_ram varchar(20) references ram(id),
    id_ecran varchar(20) references ecran(id),
    id_disque_dur varchar(20) references disque_dur(id)
);

create table mouvement(
    id varchar(20) primary key default nextval('mouvement_seq'),
    date_mouvement timestamp not null ,
    id_laptop varchar(20) references laptop(id),
    entree int,
    sortie int
);

create table report (
    id serial primary key ,
    id_laptop varchar(20) references laptop(id),
    date_report timestamp not null ,
    nombre int not null 
);

create table point_de_vente(
   id varchar(20) primary key default nextval('point_de_vente_seq'),
   label varchar(20) not null,
   adresse varchar(200) not null ,
   longitude double precision,
   latitude double precision
);

create table mouvement_point_de_vente(
    id serial primary key ,
    id_laptop varchar(20) references laptop(id),
    id_point_de_vente varchar(20) references point_de_vente(id),
    entree int,
    sortie int
);

create table report_point_de_vente (
    id serial primary key ,
    id_point_de_vente varchar(20) references point_de_vente(id),
    id_laptop varchar(20) references laptop(id),
    date_report timestamp not null ,
    nombre int not null
);

create table utilisateur(
    id varchar(20) primary key default nextval('utilisateur_seq'),
    nom varchar(500) not null ,
    prenom varchar(200),
    date_embauche date,
    date_resilliation date,
    id_point_de_vente varchar(20) references point_de_vente(id)
);

