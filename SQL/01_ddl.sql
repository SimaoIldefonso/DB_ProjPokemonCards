CREATE DATABASE PokemonDB;
GO

USE PokemonDB;
GO

CREATE SCHEMA PokemonApp;
GO

CREATE TABLE PokemonApp.Utilizadores (
    ID_Utilizador INT PRIMARY KEY NOT NULL CHECK (ID_Utilizador >= 0) auto_increment,
    Nome VARCHAR(100) NOT NULL,
    Senha VARCHAR(100) NOT NULL
);
GO

CREATE TABLE PokemonApp.Carta (
    ID_Carta INT PRIMARY KEY auto_increment,
    Nome_Carta VARCHAR(100) NOT NULL,
    Habilidade TEXT,
    Imagem BLOB
);
GO

CREATE TABLE PokemonApp.Colecao (
    ID_Utilizador INT PRIMARY KEY NOT NULL CHECK (ID_Utilizador >= 0),
    ID_Carta INT NOT NULL CHECK (ID_Carta >= 0),
    Quantidade INT NOT NULL CHECK (Quantidade >= 0),
    
    FOREIGN KEY (ID_Utilizador) REFERENCES PokemonApp.Utilizadores(ID_Utilizador),
    FOREIGN KEY (ID_Carta) REFERENCES PokemonApp.Cartas(ID_Carta),
);
GO

CREATE TABLE PokemonApp.Troca (
    ID_Troca INT PRIMARY KEY , 
    ID_Utilizador1 INT NOT NULL , 
    ID_Utilizador2 INT NOT NULL, 
    ID_Carta1 INT NOT NULL,
    ID_Carta2 INT NOT NULL,
    Estado_Troca INT CHECK (Estado_Troca IN (0, 1, 2)) ,/* 0- PENDENTE 1-RECUSADA 2-ACEITE*/
    Tempo TIMESTAMP NOT NULL,

   FOREIGN KEY (ID_Utilizador1) REFERENCES PokemonApp.Utilizadores(ID_Utilizador), 
   FOREIGN KEY (ID_Utilizador2) REFERENCES PokemonApp.Utilizadores(ID_Utilizador)
); 
GO

CREATE TABLE PokemonApp.CartasColecao (
    ID_Utilizador INT NOT NULL,
    ID_Carta INT NOT NULL,

    PRIMARY KEY (ID_Carta,ID_Utilizador),
    FOREIGN KEY (ID_Utilizador) REFERENCES PokemonApp.Utilizadores(ID_Utilizador),
    FOREIGN KEY (ID_Carta) REFERENCES PokemonApp.Cartas(ID_Carta)	

);
GO

CREATE TABLE PokemonApp.BancoCartas(
    ID_Carta INT,
    Quantidade INT,
    PRIMARY KEY (ID_Carta),
    FOREIGN KEY (ID_Carta) REFERENCES PokemonApp.Cartas(ID_Carta)

);
GO
