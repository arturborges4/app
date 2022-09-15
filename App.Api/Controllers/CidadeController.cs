using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : Controller
    {
        private ICidadeService _service;

        public CidadeController(ICidadeService service)
        {
            _service = service; 
        }

        [HttpGet("BuscaPorCep")]
        public JsonResult BuscaPorCep(string cep)
        {
            var minhaCidade = _service.BuscaPorCep(cep);
            return Json(minhaCidade); 
        }

        [HttpGet("ListaCidades")]
        public JsonResult ListaCidades(string? nome, string? cep)
        {
            return Json(_service.ListaCidades(nome, cep));
        }


        [HttpPost("Salvar")]
        public JsonResult Salva(string cep, string nome, string estado)
        {
            var objCidade = new Cidade
            {
                Cep = cep,
                Estado = estado,
                Nome = nome
            };
            _service.Salvar(objCidade);
            return Json(true);
        }

        [HttpDelete("Remover cidade por nome")]

        public JsonResult RemoverPorNome(string nome)
        { 
            _service.RemoverPorNome(nome);
            return Json(true);
        }

    }
}
