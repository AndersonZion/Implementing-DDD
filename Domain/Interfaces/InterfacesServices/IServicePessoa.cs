using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IServicePessoa
    {
        //Métodos customizados regra de negocios

        Task AdicionarComRegra(Pessoa pessoa);
        Task AtualizarComRegra(Pessoa pessoa);
        Task<List<Pessoa>> ObterMuitos();
    }
}
