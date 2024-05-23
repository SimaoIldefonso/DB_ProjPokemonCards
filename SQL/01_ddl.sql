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
    Nome_Carta VARCHAR(100) PRIMARY KEY,
    Tipo VARCHAR(100) NOT NULL, /* eletrico, fogo, água */
    Raridade INT NOT NULL, /* 0-Comum, 1-Raro, 2-Épico, 3-Lendário */
    Quantidade INT NOT NULL CHECK (Quantidade >= 0)
);
GO

CREATE TABLE PokemonApp.Carta (
    ID_CartaUnica INT PRIMARY KEY IDENTITY(1,1),
    Nome_Carta VARCHAR(100) NOT NULL,
    ID_Utilizador INT NOT NULL,
    
    FOREIGN KEY (Nome_Carta) REFERENCES PokemonApp.BancoCartas(Nome_Carta),
    FOREIGN KEY (ID_Utilizador) REFERENCES PokemonApp.Utilizadores(ID_Utilizador) ON DELETE CASCADE
);
GO

CREATE TABLE PokemonApp.Troca (
    ID_Troca INT PRIMARY KEY IDENTITY(1,1),
    ID_Utilizador1 INT NOT NULL,
    ID_Utilizador2 INT NOT NULL,
    ID_CartaUnica1 INT NOT NULL,
    ID_CartaUnica2 INT NOT NULL,
    Estado_Troca INT CHECK (Estado_Troca IN (0, 1, 2)),  -- 0- Pendente, 1- Recusada, 2- Aceite
    Tempo DATETIME NOT NULL DEFAULT GETDATE(),

    FOREIGN KEY (ID_Utilizador1) REFERENCES PokemonApp.Utilizadores(ID_Utilizador)
        ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (ID_Utilizador2) REFERENCES PokemonApp.Utilizadores(ID_Utilizador)
        ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (ID_CartaUnica1) REFERENCES PokemonApp.Carta(ID_CartaUnica)
        ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (ID_CartaUnica2) REFERENCES PokemonApp.Carta(ID_CartaUnica)
        ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE INDEX IDX_Utilizadores_Nome ON PokemonApp.Utilizadores (Nome);
CREATE INDEX IDX_BancoCartas_Nome_Tipo_Raridade ON PokemonApp.BancoCartas (Nome_Carta, Tipo, Raridade);
CREATE INDEX IDX_Carta_Nome_Carta ON PokemonApp.Carta (Nome_Carta);
CREATE INDEX IDX_Troca_Utilizadores ON PokemonApp.Troca (ID_Utilizador1, ID_Utilizador2);
GO