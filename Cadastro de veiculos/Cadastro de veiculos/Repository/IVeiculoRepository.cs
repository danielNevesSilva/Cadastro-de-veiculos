using Cadastro_de_veiculos.Models;

namespace Cadastro_de_veiculos.Repository
{
    public interface IveiculoRepository
    {
        VeiculoModel GetById(int id);
        List<VeiculoModel> GetVeiculos();
        VeiculoModel Adicionar(VeiculoModel veiculoModel);
        VeiculoModel Atualizar(VeiculoModel veiculoModel);
        bool Desativar(int id);

        int GetQuantidadeVeiculosAtivos();
        int GetQuantidadeVeiculosAtivosUnidadeSul();
        int GetQuantidadeVeiculosAtivosUnidadeLeste();
    }
}
