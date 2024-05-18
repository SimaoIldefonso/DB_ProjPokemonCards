CREATE DATABASE PokemonDB;
GO

USE PokemonDB;
GO

CREATE SCHEMA PokemonApp;
GO

CREATE TABLE PokemonApp.Utilizadores (
    ID_Utilizador INT PRIMARY KEY NOT NULL CHECK (ID_Utilizador >= 0) IDENTITY(1,1),
    Nome VARCHAR(100) NOT NULL,
    Senha VARCHAR(100) NOT NULL
);
GO

CREATE TABLE PokemonApp.BancoCartas (
    ID_Carta INT PRIMARY KEY IDENTITY(1,1),
    Nome_Carta VARCHAR(100) NOT NULL,
    Tipo VARCHAR(100) NOT NULL, /* eletrico, fogo, água */
    Raridade INT NOT NULL, /* 0-Comum, 1-Raro, 2-Épico, 3-Lendário */
    Quantidade INT NOT NULL CHECK (Quantidade >= 0)
);
GO

CREATE TABLE PokemonApp.Carta (
    ID_Carta INT PRIMARY KEY,
    Habilidade TEXT,
    Imagem VARBINARY(MAX),
    
    FOREIGN KEY (ID_Carta) REFERENCES PokemonApp.BancoCartas(ID_Carta)
);
GO

CREATE TABLE PokemonApp.Colecao (
    ID_Utilizador INT NOT NULL CHECK (ID_Utilizador >= 0),
    ID_Carta INT NOT NULL CHECK (ID_Carta >= 0),
    Quantidade INT NOT NULL CHECK (Quantidade >= 0),
    
    PRIMARY KEY (ID_Utilizador, ID_Carta),
    FOREIGN KEY (ID_Utilizador) REFERENCES PokemonApp.Utilizadores(ID_Utilizador),
    FOREIGN KEY (ID_Carta) REFERENCES PokemonApp.BancoCartas(ID_Carta)
);
GO

CREATE TABLE PokemonApp.Troca (
    ID_Troca INT PRIMARY KEY IDENTITY(1,1), 
    ID_Utilizador1 INT NOT NULL, 
    ID_Utilizador2 INT NOT NULL, 
    ID_Carta1 INT NOT NULL,
    ID_Carta2 INT NOT NULL,
    Estado_Troca INT CHECK (Estado_Troca IN (0, 1, 2)), /* 0- PENDENTE 1-RECUSADA 2-ACEITE*/
    Tempo TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

    FOREIGN KEY (ID_Utilizador1) REFERENCES PokemonApp.Utilizadores(ID_Utilizador), 
    FOREIGN KEY (ID_Utilizador2) REFERENCES PokemonApp.Utilizadores(ID_Utilizador),
    FOREIGN KEY (ID_Carta1) REFERENCES PokemonApp.BancoCartas(ID_Carta),
    FOREIGN KEY (ID_Carta2) REFERENCES PokemonApp.BancoCartas(ID_Carta)
); 
GO

CREATE TABLE PokemonApp.CartasColecao (
    ID_Utilizador INT NOT NULL,
    ID_Carta INT NOT NULL,

    PRIMARY KEY (ID_Carta, ID_Utilizador),
    FOREIGN KEY (ID_Utilizador) REFERENCES PokemonApp.Utilizadores(ID_Utilizador),
    FOREIGN KEY (ID_Carta) REFERENCES PokemonApp.BancoCartas(ID_Carta)
);
GO

-- Índices para melhorar a performance das buscas
CREATE INDEX IDX_Utilizadores_Nome ON PokemonApp.Utilizadores (Nome);
CREATE INDEX IDX_BancoCartas_Nome_Tipo_Raridade ON PokemonApp.BancoCartas (Nome_Carta, Tipo, Raridade);
CREATE INDEX IDX_Carta ON PokemonApp.Carta (ID_Carta);
CREATE INDEX IDX_Colecao_Utilizador ON PokemonApp.Colecao (ID_Utilizador);
CREATE INDEX IDX_Troca_Utilizadores ON PokemonApp.Troca (ID_Utilizador1, ID_Utilizador2);
CREATE INDEX IDX_CartasColecao_Utilizador ON PokemonApp.CartasColecao (ID_Utilizador);
GO
