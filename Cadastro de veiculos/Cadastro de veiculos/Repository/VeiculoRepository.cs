using Cadastro_de_veiculos.Data;
using Cadastro_de_veiculos.Models;

namespace Cadastro_de_veiculos.Repository
{
    public class veiculoRepository : IveiculoRepository
    {
        private readonly BancoContext _bancoContext;
        public veiculoRepository(BancoContext bancoContext) {
            _bancoContext = bancoContext;
        }
        public List<VeiculoModel> GetVeiculos()
        {
            return _bancoContext.veiculos.ToList();
         }
        public VeiculoModel GetById(int Id)
        {
            return _bancoContext.veiculos.FirstOrDefault(X => X.id == Id);
        }

        public int GetQuantidadeVeiculosAtivos() {

        return _bancoContext.veiculos.Count(v => v.Ativo);

        }
        public int GetQuantidadeVeiculosAtivosUnidadeSul()
        {
            return _bancoContext.veiculos.Count(v => v.Ativo && v.Unidade == "SUL");
        }
        public int GetQuantidadeVeiculosAtivosUnidadeLeste()
        {
            return _bancoContext.veiculos.Count(v => v.Ativo && v.Unidade == "LESTE");
        }



        public VeiculoModel Adicionar(VeiculoModel veiculoModel)
        {
            _bancoContext.veiculos.Add(veiculoModel);
            _bancoContext.SaveChanges();
            return veiculoModel;
        }

        public VeiculoModel Atualizar(VeiculoModel veiculo)
        {
            VeiculoModel veiculoDB = GetById(veiculo.id);
            if (veiculoDB == null) throw new System.Exception("Houve um erro na atualização do veiculo");

            veiculoDB.Placa = veiculo.Placa;
            veiculoDB.Marca = veiculo.Marca;
            veiculoDB.Modelo = veiculo.Modelo;
            veiculoDB.Tipo = veiculo.Tipo;
            veiculoDB.Unidade = veiculo.Unidade;
            veiculoDB.Renavam = veiculo.Renavam;
            veiculoDB.DataCriacao = veiculo.DataCriacao;

            _bancoContext.veiculos.Update(veiculoDB);
            _bancoContext.SaveChanges();
            return veiculoDB;
        }

        public bool Desativar(int id)
        {
            VeiculoModel veiculoDB = GetById(id);
            if (veiculoDB == null) throw new System.Exception("Houve um erro na deleção do veiculo");

            veiculoDB.Ativo = false;
            _bancoContext.SaveChanges();
            return true;    
        }

       
    }
}
