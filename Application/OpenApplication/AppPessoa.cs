using Application.Interfaces;
using Domain.Interfaces.InterfacesDomains;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.OpenApplication
{
    public class AppPessoa : IPessoaApp
    {

        readonly IPessoa _IPessoa;
        readonly IServicePessoa _IServicePessoa;

        public AppPessoa(IPessoa IPessoa, IServicePessoa IServicePessoa)
        {
            _IPessoa = IPessoa;
            _IServicePessoa = IServicePessoa;
        }

        public async Task AddAsync(Pessoa pessoa)
        {
           await _IPessoa.AddAsync(pessoa); 
        }

        public async Task AdicionarComRegra(Pessoa pessoa)
        {
            await _IServicePessoa.AdicionarComRegra(pessoa);
        }

        public async Task Atualizar(Pessoa pessoa)
        {
            await _IPessoa.Atualizar(pessoa);
        }

        public async Task AtualizarComRegra(Pessoa pessoa)
        {
            await _IServicePessoa.AtualizarComRegra(pessoa);
        }

        public async Task DeletarAsync(Pessoa pessoa)
        {
            await _IPessoa.DeletarAsync(pessoa);
        }

        public async Task<IEnumerable<Pessoa>> Obter()
        {
           return await _IPessoa.Obter();
        }

        public async Task<List<Pessoa>> ObterMuitos()
        {
           return await _IPessoa.ObterMuitos(x => x.Nome.ToUpper() != x.SobreNome.ToUpper());
        }

        public async Task<Pessoa> ObterPorIdAsync(int id)
        {
            return await _IPessoa.ObterPorIdAsync(id);
        }
    }
}
