using App.Domain.DTO;
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
            try
            {
                var obj = _service.ListaCidades(nome, cep);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }


        [HttpPost("Salvar")]
        public JsonResult Salva([FromBody] Cidade obj)
        {
            try
            {
                _service.Salvar(obj);
                return Json(RetornoApi.Sucesso(true));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
             
        }

        [HttpDelete("Remover cidade por nome")]

        public JsonResult RemoverPorNome(string nome)
        { 
            _service.RemoverPorNome(nome);
            return Json(true);
        }

    }
}
