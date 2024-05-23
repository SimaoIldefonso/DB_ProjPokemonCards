--DROP PROCEDURE IF EXISTS PokemonApp.DeleteUserAndAllAssociations;
CREATE OR ALTER PROCEDURE PokemonApp.DeleteUserAndAllAssociations
    @UserID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Deletar trocas onde o usuário é um dos participantes
    DELETE FROM PokemonApp.Troca
    WHERE ID_Utilizador1 = @UserID OR ID_Utilizador2 = @UserID;

    -- Antes de deletar as cartas, atualizar o banco de cartas incrementando as quantidades
    UPDATE PokemonApp.BancoCartas
    SET Quantidade = Quantidade + 1
    FROM PokemonApp.BancoCartas bc
    JOIN PokemonApp.Carta c ON bc.Nome_Carta = c.Nome_Carta
    WHERE c.ID_Utilizador = @UserID;

    -- Deletar cartas do usuário
    DELETE FROM PokemonApp.Carta
    WHERE ID_Utilizador = @UserID;

    -- Deletar o usuário
    DELETE FROM PokemonApp.Utilizadores
    WHERE ID_Utilizador = @UserID;
END;
GO

/*---------------------*/
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
/*-------------------------------------*/
CREATE PROCEDURE PokemonApp.CheckUserExists
    @UserID INT
AS
BEGIN
    SELECT COUNT(*) FROM PokemonApp.Utilizadores WHERE ID_Utilizador = @UserID;
END
GO
/*-------------------------------------*/
--DROP PROCEDURE PokemonApp.GetPokemonsByUser;
CREATE PROCEDURE PokemonApp.GetPokemonsByUser
    @UserID INT
AS
BEGIN
    SELECT ID_CartaUnica, Nome_Carta FROM PokemonApp.Carta WHERE ID_Utilizador = @UserID;
END
GO


/*-------------------------------------*/
CREATE PROCEDURE PokemonApp.CreateTrade
    @UserID1 INT,
    @UserID2 INT,
    @CardUniqueID1 INT,
    @CardUniqueID2 INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Verify that User 1 owns Card 1
    IF NOT EXISTS (SELECT 1 FROM PokemonApp.Carta WHERE ID_CartaUnica = @CardUniqueID1 AND ID_Utilizador = @UserID1)
    BEGIN
        RAISERROR ('User 1 does not own the specified card.', 16, 1);
        RETURN;
    END

    -- Verify that User 2 owns Card 2
    IF NOT EXISTS (SELECT 1 FROM PokemonApp.Carta WHERE ID_CartaUnica = @CardUniqueID2 AND ID_Utilizador = @UserID2)
    BEGIN
        RAISERROR ('User 2 does not own the specified card.', 16, 1);
        RETURN;
    END

    -- Create the trade if both verifications are true
    INSERT INTO PokemonApp.Troca (ID_Utilizador1, ID_Utilizador2, ID_CartaUnica1, ID_CartaUnica2, Estado_Troca, Tempo)
    VALUES (@UserID1, @UserID2, @CardUniqueID1, @CardUniqueID2, 0, GETDATE());

    SELECT SCOPE_IDENTITY() AS NewTradeID;
END
GO

/*-------------------------------------*/
CREATE PROCEDURE PokemonApp.GetPendingTradesForUser
    @UserID INT
AS
BEGIN
    SELECT t.ID_Troca, u.Nome AS 'OfferedBy', c.Nome_Carta AS 'OfferedCard',
           c2.Nome_Carta AS 'RequestedCard', t.Estado_Troca
    FROM PokemonApp.Troca t
    JOIN PokemonApp.Utilizadores u ON t.ID_Utilizador1 = u.ID_Utilizador
    JOIN PokemonApp.Carta c ON t.ID_CartaUnica1 = c.ID_CartaUnica
    JOIN PokemonApp.Carta c2 ON t.ID_CartaUnica2 = c2.ID_CartaUnica
    WHERE t.ID_Utilizador2 = @UserID AND t.Estado_Troca = 0  -- 0 indica 'Pendente'
    ORDER BY t.ID_Troca;
END;
GO
/*-------------------------------------*/
/*drop procedure PokemonApp.AcceptTrade;*/
CREATE PROCEDURE PokemonApp.AcceptTrade
    @TradeID INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserID1 INT, @UserID2 INT, @CardID1 INT, @CardID2 INT;
    DECLARE @RowsAffected INT = 0;

    -- Seleciona os detalhes da troca apenas se estiver pendente
    SELECT @UserID1 = ID_Utilizador1, @UserID2 = ID_Utilizador2,
           @CardID1 = ID_CartaUnica1, @CardID2 = ID_CartaUnica2
    FROM PokemonApp.Troca
    WHERE ID_Troca = @TradeID AND Estado_Troca = 0; -- 0 para estado 'Pendente'

    IF @@ROWCOUNT > 0
    BEGIN
        -- Troca as cartas entre os usuários
        UPDATE PokemonApp.Carta
        SET ID_Utilizador = CASE ID_Utilizador
                                WHEN @UserID1 THEN @UserID2
                                WHEN @UserID2 THEN @UserID1
                            END
        WHERE ID_CartaUnica IN (@CardID1, @CardID2);

        SET @RowsAffected = @@ROWCOUNT;

        -- Atualiza o estado da troca para 'Aceita'
        UPDATE PokemonApp.Troca
        SET Estado_Troca = 2,  -- Considerando que 2 é o estado 'Aceita'
            Tempo = GETDATE()
        WHERE ID_Troca = @TradeID;

        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;
    END

    RETURN @RowsAffected;
END;
GO

/*-------------------------------------*/
CREATE PROCEDURE PokemonApp.RejectTrade
    @TradeID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Atualiza o estado da troca para 'Rejeitada'
    UPDATE PokemonApp.Troca
    SET Estado_Troca = 1,  -- Considerando que 1 é o estado 'Rejeitada'
        Tempo = GETDATE()
    WHERE ID_Troca = @TradeID;
END;
GO

/*-------------------------------------*/
CREATE OR ALTER PROCEDURE PokemonApp.DescartarCarta (@ID_CartaUnica INT)
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

    -- A trigger UpdateCardQuantityOnDelete já lidará com o aumento da quantidade no banco de cartas
END;
GO
