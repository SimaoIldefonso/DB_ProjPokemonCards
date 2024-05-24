-- Função para contar cartas por raridade
CREATE OR ALTER FUNCTION CountCardsByRarity(@UserID INT, @Rarity INT)
RETURNS INT
AS
BEGIN
    DECLARE @Total INT;
    SELECT @Total = COUNT(*)
    FROM PokemonApp.Carta AS c
    JOIN PokemonApp.BancoCartas AS bc ON c.Nome_Carta = bc.Nome_Carta
    WHERE c.ID_Utilizador = @UserID AND bc.Raridade = @Rarity;
    RETURN @Total;
END;
GO

