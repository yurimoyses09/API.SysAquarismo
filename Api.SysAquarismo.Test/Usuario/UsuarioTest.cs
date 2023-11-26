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
            Ds_Email = "teste@teste.com",
            Ds_Nome_Usuario_Login = "teste_login",
            Ds_Pais = "Teste",
            Ds_Senha = "SenhaTeste",
            Ds_Telefone = "1199111111",
            Idade = 24,
            Id_Usuario = 1,
            Nome_Usuario = "Teste da Silva",
            Sexo = "2"
        };

        return usuario;
    }
}
