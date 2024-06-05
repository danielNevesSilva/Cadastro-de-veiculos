using Cadastro_de_veiculos.Models;
using Cadastro_de_veiculos.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace Cadastro_de_veiculos.Controllers
{
    public class CadastrodeVeiculos : Controller
    {
        private readonly IveiculoRepository _veiculoRepository;
        public CadastrodeVeiculos(IveiculoRepository VeiculoRepository)
        {
            _veiculoRepository = VeiculoRepository;
        }
        public IActionResult Index(String pesquisa, int page =1, int pageSize=5)
        {
         
            
            List<VeiculoModel> veiculos = _veiculoRepository.GetVeiculos();

            if (!String.IsNullOrEmpty(pesquisa))
            {
                string pesquisaUpper = pesquisa.ToUpper();
                veiculos = veiculos.Where(v =>
                    v.Placa.ToUpper().Contains(pesquisaUpper) ||
                    v.Marca.ToUpper().Contains(pesquisaUpper) ||
                    v.Modelo.ToUpper().Contains(pesquisaUpper) ||
                    v.Tipo.ToUpper().Contains(pesquisaUpper) ||
                    v.Unidade.ToUpper().Contains(pesquisaUpper) ||
                    v.DataCriacao.ToString().Contains(pesquisaUpper)
                ).ToList();
            }
            int startIndex = (page - 1) * pageSize;
            List<VeiculoModel> veiculosAtivos = veiculos.Where(v => v.Ativo).Skip(startIndex).Take(pageSize).ToList();

            int quantidadeVeiculosAtivos = _veiculoRepository.GetQuantidadeVeiculosAtivos();
            int quantidadeVeiculosAtivosUnidadeSul = _veiculoRepository.GetQuantidadeVeiculosAtivosUnidadeSul();
            int quantidadeVeiculosAtivosUnidadeLeste = _veiculoRepository.GetQuantidadeVeiculosAtivosUnidadeLeste();


            int totalPages = (int)Math.Ceiling((double)quantidadeVeiculosAtivos / pageSize);
            page = Math.Max(1, Math.Min(page, totalPages));

            ViewBag.QuantidadeVeiculosAtivos = quantidadeVeiculosAtivos;
            ViewBag.QuantidadeVeiculosAtivosUnidadeSul = quantidadeVeiculosAtivosUnidadeSul;
            ViewBag.QuantidadeVeiculosAtivosUnidadeLeste = quantidadeVeiculosAtivosUnidadeLeste;
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;
            return View(veiculosAtivos);
        }

        public IActionResult NovoVeiculo()
        {
            return View();
        }
        public IActionResult EditarVeiculo(int id )
        {
           VeiculoModel veiculo = _veiculoRepository.GetById(id);

            return View(veiculo);
        }
        public IActionResult RemoverVeiculo(int id)
        {
            VeiculoModel veiculo = _veiculoRepository.GetById(id);
            return View(veiculo);
        }

        [HttpPost]
        public IActionResult NovoVeiculo(VeiculoModel veiculo)
        {

            _veiculoRepository.Adicionar(veiculo);

            return RedirectToAction("Index");

        }

        public IActionResult Desativar(int id)
        {
            _veiculoRepository.Desativar(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Alterar(VeiculoModel veiculo)
        {

            _veiculoRepository.Atualizar(veiculo);

            return RedirectToAction("Index");

        }
       
    }
}
