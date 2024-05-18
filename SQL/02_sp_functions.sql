CREATE PROCEDURE PokemonApp.AbrirPack (@ID_Utilizador INT)
AS
BEGIN
    DECLARE @i INT = 0;
    DECLARE @Nome_Carta VARCHAR(100);
    DECLARE @raridade INT;
    DECLARE @total INT;
    DECLARE @rand FLOAT;

    WHILE @i < 5
    BEGIN
        -- Define a raridade com base em percentagens
        SET @rand = RAND();
        IF @rand < 0.6 SET @raridade = 0; -- 60% de chance de ser comum
        ELSE IF @rand < 0.85 SET @raridade = 1; -- 25% de chance de ser raro
        ELSE IF @rand < 0.95 SET @raridade = 2; -- 10% de chance de ser épico
        ELSE SET @raridade = 3; -- 5% de chance de ser lendário

        -- Seleciona uma carta aleatória do banco de cartas com a raridade selecionada onde a quantidade é maior que 0
        SELECT TOP 1 @Nome_Carta = Nome_Carta
        FROM PokemonApp.BancoCartas
        WHERE Raridade = @raridade AND Quantidade > 0
        ORDER BY NEWID();

        -- Diminui a quantidade da carta no banco de cartas
        UPDATE PokemonApp.BancoCartas
        SET Quantidade = Quantidade - 1
        WHERE Nome_Carta = @Nome_Carta;

        -- Adiciona a carta única à coleção do utilizador
        INSERT INTO PokemonApp.Carta (Nome_Carta, ID_Utilizador)
        VALUES (@Nome_Carta, @ID_Utilizador);

        SET @i = @i + 1;
    END;
END;
GO
/*---------------------*/
CREATE PROCEDURE PokemonApp.DescartarCarta (@ID_CartaUnica INT)
AS
BEGIN
    DECLARE @Nome_Carta VARCHAR(100);

    -- Obter o Nome_Carta da carta a ser descartada
    SELECT @Nome_Carta = Nome_Carta
    FROM PokemonApp.Carta
    WHERE ID_CartaUnica = @ID_CartaUnica;

    -- Remover a carta única da coleção do utilizador
    DELETE FROM PokemonApp.Carta
    WHERE ID_CartaUnica = @ID_CartaUnica;

    -- Aumentar a quantidade da carta no banco de cartas
    UPDATE PokemonApp.BancoCartas
    SET Quantidade = Quantidade + 1
    WHERE Nome_Carta = @Nome_Carta;
END;
GO
