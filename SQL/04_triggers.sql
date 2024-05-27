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
/*--------------------------*/
CREATE TRIGGER EncryptUsersPassword
ON PokemonApp.Utilizadores
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Aplicar hash à senha somente se for inserida ou alterada
    UPDATE u
    SET Senha = PokemonApp.HashPassword(i.Senha)
    FROM PokemonApp.Utilizadores u
    JOIN inserted i ON u.ID_Utilizador = i.ID_Utilizador
    WHERE u.Senha <> PokemonApp.HashPassword(i.Senha) -- Evitar hash múltiplo
END
GO


