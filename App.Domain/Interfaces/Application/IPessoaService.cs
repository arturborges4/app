using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Application
{
    public interface IPessoaService
    {
        Pessoa BuscaPorNome(string nome);
        void Remover(Guid id);
        void RemoverPorNome(string nome);
        void Salvar(Pessoa obj);
        List<Pessoa> ListaPessoas(string? nome, int? idade, char? sexo);
    }
}
