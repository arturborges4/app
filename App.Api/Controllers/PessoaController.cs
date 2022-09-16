using App.Domain.DTO;
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
            try
            {
                var minhaPessoa = _service.BuscaPorNome(nome);
                return Json(RetornoApi.Sucesso(BuscaPorNome));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpPost("Salvar")]
        public JsonResult Salva(string nome, int idade, char sexo)
        {
            try
            {
                var objPessoa = new Pessoa
                {
                    Nome = nome,
                    Idade = idade,
                    Sexo = sexo
                };
                _service.Salvar(objPessoa);
                return Json(RetornoApi.Sucesso(objPessoa));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpDelete("Remover pessoa por nome")]
        public JsonResult RemoverPorNome(string nome)
        {
            try
            {
                _service.RemoverPorNome(nome);
                return Json(RetornoApi.Sucesso(true));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }

        }

        [HttpGet("ListaPessoas")]
        public JsonResult ListaPessoas(string? nome, int? idade, char? sexo)
        {
            try
            {
                var obj = _service.ListaPessoas(nome, idade, sexo);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

    }
}
