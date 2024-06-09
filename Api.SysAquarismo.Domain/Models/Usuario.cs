namespace Api.SysAquarismo.Domain.Models;

public class Usuario
{
    public int id_usuario { get; set; }
    public string nome_usuario { get; set; }
    public int idade { get; set; }
    public string telefone { get; set; }
    public string email { get; set; }
    public string nome_login { get; set; }
    public string senha { get; set; }
    public int sexo { get; set; }
    public string pais { get; set; }
    public List<Peixe> peixes { get; set; }

    public Usuario() { }

    public Usuario(IEnumerable<Peixe> peixe, Usuario usuario)
    {
        id_usuario = usuario.id_usuario;
        nome_usuario = usuario.nome_usuario.ToString();
        telefone = usuario.telefone.ToString();
        idade = usuario.idade;
        nome_login = usuario.nome_login;
        peixes = new List<Peixe>();

        foreach (Peixe pe in peixe)
            peixes.Add(pe);
    }
}
