using Api.SysAquarismo.Domain.Enum;

namespace Api.SysAquarismo.Test.Peixe;

[TestClass]
public class PeixeTest
{
    [TestMethod]
    public void CreateObjectPeixe_Success()
    {
        Domain.Models.Peixe peixe = CreateObjectPeixe();

        Assert.IsNotNull(peixe);
    }

    private static Domain.Models.Peixe CreateObjectPeixe()
    {
        Domain.Models.Peixe peixe = new()
        {
            Ds_Data_Aquisicao = DateTime.Now,
            Ds_Data_Morte = DateTime.Now,
            Ds_Descricao = "",
            Ds_Doenca = "",
            Ds_Imagem = "",
            Ds_Nome_Especie = "",
            Ds_Nome_Peixe = "",
            Id_Peixe = 3,
            Id_Status_Saude = 2,
            Id_Usuario = 4,
            Sexo = 3,
            Vl_Peso = 4,
            Vl_Tamanho = 5,
        };

        return peixe;
    }
}
