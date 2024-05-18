USE PokemonDB;
GO

-- Inserir Utilizadores
INSERT INTO PokemonApp.Utilizadores (Nome, Senha)
VALUES 
('Ash_Ketchum', 'pikachu123'),
('Misty_Waterflower', 'starmie456'),
('Brock_Harrison', 'onix789');
GO

-- Inserir Cartas no BancoCartas
INSERT INTO PokemonApp.BancoCartas (Nome_Carta, Tipo, Raridade, Quantidade)
VALUES
('Boldore', 'pedra', 1, 15),
('Charizard', 'fogo', 2, 10),
('Charmander', 'fogo', 0, 20),
('Charmeleon', 'fogo', 1, 15),
('Dragonair', 'dragão', 2, 10),
('Dragonite', 'dragão', 3, 5),
('Dratini', 'dragão', 1, 15),
('Entei', 'fogo', 3, 5),
('Gigalith', 'pedra', 2, 10),
('Mew', 'psíquico', 3, 5),
('Pichu', 'eletrico', 0, 25),
('Pikachu', 'eletrico', 0, 50),
('Raichu', 'eletrico', 1, 15),
('Raikou', 'eletrico', 3, 5),
('Roggenrola', 'pedra', 0, 20);
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
