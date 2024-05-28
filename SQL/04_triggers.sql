-- Trigger para limpar dados relacionados quando um usuário é deletado
CREATE TRIGGER trg_DeleteUser
ON PokemonApp.Utilizadores
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM PokemonApp.Troca
    WHERE ID_Utilizador1 IN (SELECT ID_Utilizador FROM deleted)
       OR ID_Utilizador2 IN (SELECT ID_Utilizador FROM deleted);

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

    UPDATE u
    SET Senha = PokemonApp.HashPassword(i.Senha)
    FROM PokemonApp.Utilizadores u
    JOIN inserted i ON u.ID_Utilizador = i.ID_Utilizador
    WHERE u.Senha <> PokemonApp.HashPassword(i.Senha)
END
GO


