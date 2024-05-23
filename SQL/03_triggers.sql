-- Trigger para limpar dados relacionados quando um usuário é deletado
CREATE TRIGGER trg_DeleteUser
ON PokemonApp.Utilizadores
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Deletar trocas relacionadas ao usuário deletado
    DELETE FROM PokemonApp.Troca
    WHERE ID_Utilizador1 IN (SELECT ID_Utilizador FROM deleted)
       OR ID_Utilizador2 IN (SELECT ID_Utilizador FROM deleted);

    -- Deletar cartas relacionadas ao usuário deletado
    DELETE FROM PokemonApp.Carta
    WHERE ID_Utilizador IN (SELECT ID_Utilizador FROM deleted);
END;
GO