-- Função para abrir um pack e adicionar as cartas à coleção do utilizador
CREATE PROCEDURE AbrirPack (@ID_Utilizador INT)
AS
BEGIN
    DECLARE @i INT = 0;
    DECLARE @ID_Carta INT;

    WHILE @i < 5
    BEGIN
        -- Seleciona uma carta aleatória do banco de cartas onde a quantidade é maior que 0
        SELECT TOP 1 @ID_Carta = ID_Carta
        FROM PokemonApp.BancoCartas
        WHERE Quantidade > 0
        ORDER BY NEWID();

        -- Adiciona a carta à coleção do utilizador
        INSERT INTO PokemonApp.Colecao (ID_Utilizador, ID_Carta, Quantidade)
        VALUES (@ID_Utilizador, @ID_Carta, 1)
        ON DUPLICATE KEY UPDATE Quantidade = Quantidade + 1;

        -- Diminui a quantidade da carta no banco de cartas
        UPDATE PokemonApp.BancoCartas
        SET Quantidade = Quantidade - 1
        WHERE ID_Carta = @ID_Carta;

        SET @i = @i + 1;
    END;
END;
GO
