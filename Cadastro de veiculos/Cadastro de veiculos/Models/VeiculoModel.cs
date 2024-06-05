using Microsoft.VisualBasic;


namespace Cadastro_de_veiculos.Models
{
    public class VeiculoModel
    {

        public int id {  get; set; }
        public String Placa { get; set; }
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Tipo { get; set; }
        public String Unidade { get; set; }
        public String Renavam { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCriacao { get; set; }

        public VeiculoModel()
        {
            Ativo = true;
            DataCriacao = DateTime.Today;
        }
    }
}
