namespace Api.SysAquarismo.Test.Usuario;

[TestClass]
public class UsuarioTest
{
    [TestMethod]
    public void CreateObjectUsuario_Success()
    {
        Domain.Models.Usuario usuario = MockObjectUsuario();

        Assert.IsNotNull(usuario);
    }

    private static Domain.Models.Usuario MockObjectUsuario()
    {
        Domain.Models.Usuario usuario = new()
        {
            email = "teste@teste.com",
            nome_login = "teste_login",
            pais = "Teste",
            senha = "SenhaTeste",
            telefone = "1199111111",
            idade = 24,
            id_usuario = 1,
            nome_usuario = "Teste da Silva",
            sexo = 2
        };

        return usuario;
    }
}
