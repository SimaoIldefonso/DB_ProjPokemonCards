USE PokemonDB;
GO

-- Inserir Utilizadores
INSERT INTO PokemonApp.Utilizadores (Nome, Senha)
VALUES 
('Ash_Ketchum', 'pikachu123'),
('Misty_Waterflower', 'starmie456'),
('Brock_Harrison', 'onix789');
GO

USE PokemonDB;
GO

-- Inserir Cartas no BancoCartas
INSERT INTO PokemonApp.BancoCartas (Nome_Carta, Tipo, Raridade, Quantidade)
VALUES
('Boldore', 'Stone', 1, 500),
('Charizard', 'Fire', 2, 100),
('Charmander', 'Fire', 0, 200),
('Charmeleon', 'Fire', 1, 150),
('Dragonair', 'Dragon', 2, 100),
('Dragonite', 'Dragon', 3, 50),
('Dratini', 'Dragon', 1, 150),
('Entei', 'Fire', 3, 50),
('Gigalith', 'Stone', 2, 100),
('Mew', 'Psychic', 3, 50),
('Pichu', 'Electric', 0, 250),
('Pikachu', 'Electric', 0, 500),
('Raichu', 'Electric', 1, 150),
('Raikou', 'Electric', 3, 50),
('Roggenrola', 'Stone', 0, 200);
GO

