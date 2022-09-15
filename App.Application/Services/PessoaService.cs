using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class PessoaService : IPessoaService
    {

        private IRepositoryBase<Pessoa> _repository { get; set; }

        public PessoaService(IRepositoryBase<Pessoa> repository)
        {
            _repository = repository;
        }

        public Pessoa BuscaPorNome(string nome)
        {
            var retornoPessoa = _repository.Query(x => x.Nome == nome).FirstOrDefault();
            return retornoPessoa;
        }

        public List<Pessoa> ListaPessoas(string nome, int idade, char sexo)
        {
            var listaPessoas = _repository.Query(x => x.Nome.Contains(nome) && x.Idade == idade && x.Sexo == sexo).ToList();
            return listaPessoas;
        }

        public void Remover(Guid id)
        {
            _repository.Delete(id);

        }

        public void Salvar(Pessoa obj)
        {
            _repository.save(obj);
            _repository.SaveChanges();
        }


        
    }
}
