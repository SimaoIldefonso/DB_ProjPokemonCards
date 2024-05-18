-- Trigger para adicionar uma carta ao banco de cartas quando uma carta é eliminada da coleção do utilizador
CREATE TRIGGER trg_AddToBancoCartas 
AFTER DELETE ON PokemonApp.Colecao
FOR EACH ROW
BEGIN
    UPDATE PokemonApp.BancoCartas
    SET Quantidade = Quantidade + OLD.Quantidade
    WHERE ID_Carta = OLD.ID_Carta;
END;
GO
