using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : Controller
    {
        private IPessoaService _service;

        public PessoaController(IPessoaService service)
        {
            _service = service;
        }

        [HttpGet("BuscaPorNome")]
        public JsonResult BuscaPorNome(string nome)
        {
            var minhaPessoa = _service.BuscaPorNome(nome);
            return Json(minhaPessoa);
        }

        [HttpPost("Salvar")]
        public JsonResult Salva(string nome, int idade, char sexo)
        {
            var objPessoa = new Pessoa
            {
                Nome = nome,
                Idade = idade,
                Sexo = sexo
            };
            _service.Salvar(objPessoa);
            return Json(true);
        }

    }
}
