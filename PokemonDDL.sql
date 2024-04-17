CREATE DATABASE PokemonDB;
GO

USE PokemonDB;
GO

CREATE SCHEMA PokemonApp;
GO

CREATE TABLE PokemonApp.Utilizadores (
    ID_Utilizador INT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Senha VARCHAR(100) NOT NULL
);
GO

CREATE TABLE PokemonApp.Cartas (
    ID_Carta INT PRIMARY KEY,
    Nome_Carta VARCHAR(100) NOT NULL,
    Descricao TEXT,
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

CREATE TABLE PokemonApp.Trocas (
   ID_Troca INT PRIMARY KEY , 
   ID_Utilizador1 INT NOT NULL , 
   ID_Utilizador2 INT NOT NULL, 
   Estado_Troca INT CHECK (Estado_Troca IN (0, 1, 2)) ,/* 0- PENDENTE 1-RECUSADA 2-ACEITE*/

   FOREIGN KEY (ID_Utilizador1) REFERENCES PokemonApp.Utilizadores(ID_Utilizador), 
   FOREIGN KEY (ID_Utilizador2) REFERENCES PokemonApp.Utilizadores(ID_Utilizador)
); 
GO

CREATE TABLE PokemonApp.DetalhesTroca (
  ID_Troca INT, 
  ID_Carta INT, 
  
  FOREIGN KEY (ID_Troca) REFERENCES PokemonApp.Trocas(ID_Troca), 
  FOREIGN KEY (ID_Carta) REFERENCES PokemonApp.Cartas(ID_Carta),

PRIMARY KEY (ID_Troca, ID_Carta)
);
GO
