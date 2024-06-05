using Cadastro_de_veiculos.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_de_veiculos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<VeiculoModel> veiculos {  get; set; } 
    }
}
