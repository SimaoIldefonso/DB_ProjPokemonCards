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
('Boldore', 'pedra', 1, 500),
('Charizard', 'fogo', 2, 100),
('Charmander', 'fogo', 0, 200),
('Charmeleon', 'fogo', 1, 150),
('Dragonair', 'dragão', 2, 100),
('Dragonite', 'dragão', 3, 50),
('Dratini', 'dragão', 1, 150),
('Entei', 'fogo', 3, 50),
('Gigalith', 'pedra', 2, 100),
('Mew', 'psíquico', 3, 50),
('Pichu', 'eletrico', 0, 250),
('Pikachu', 'eletrico', 0, 500),
('Raichu', 'eletrico', 1, 150),
('Raikou', 'eletrico', 3, 50),
('Roggenrola', 'pedra', 0, 200);
GO

-- Inserir Detalhes das Cartas
INSERT INTO PokemonApp.Carta (ID_CartaUnica, Nome_Carta, ID_Utilizador)
VALUES
(1, 'Pikachu', 1),  -- Ash tem um Pikachu
(2, 'Charizard', 1),   -- Ash tem um Charizard
(3, 'Charmander', 1),   -- Ash tem um Charmander
(4, 'Charmeleon', 2),   -- Misty tem um Charmeleon
(5, 'Pichu', 2),  -- Misty tem um Pichu
(6, 'Entei', 3),   -- Brock tem um Entei
(7, 'Roggenrola', 3);  -- Brock tem um Roggenrola
GO
