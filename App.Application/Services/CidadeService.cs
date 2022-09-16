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
    public class CidadeService : ICidadeService
    {

        private IRepositoryBase<Cidade> _repository { get; set; }

        public CidadeService(IRepositoryBase<Cidade> repository)
        {
            _repository = repository;
        }

        public Cidade BuscaPorCep(string cep)
        {
            var retornoCidade = _repository.Query(cidade => cidade.Cep == cep).FirstOrDefault();
            return retornoCidade;
        }

        public List<Cidade> ListaCidades(string? cep, string? nome)
        {
            var listaCidades = _repository.Query(

                x => (cep == null || x.Cep.Contains(cep))
                && (nome == null || x.Nome.Contains(nome))

                ).ToList();

            return listaCidades;
        }

        public void Remover(Guid id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();

        }

        public void Salvar(Cidade obj)
        {
            _repository.save(obj);
            _repository.SaveChanges();
        }

        public void RemoverPorNome(string nome)
        {
            var cidade = _repository.Query(x => x.Nome == nome).FirstOrDefault();
            if (cidade != null)
            {
                _repository.Delete(cidade.Id);
                _repository.SaveChanges();
            }
            else
            {
                throw new Exception("Cidade nao encontrada");
            }
         }
        }
    }
