using Domain.Interfaces.InterfacesDomains;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using Entities.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServicePessoa : IServicePessoa
    {

        private readonly IPessoa _IPessoa;
        //private readonly IUnitOfWork _IUnitOfWork;

        public ServicePessoa(IPessoa IPessoa)
        {
            _IPessoa = IPessoa;
        }
        public async Task AdicionarComRegra(Pessoa pessoa)
        {
            //Capaz de adicionar jogadores
            pessoa = Evalido(pessoa);
            if (pessoa.Notificas.Any()) return;

            await _IPessoa.AddAsync(pessoa);
        }

        public async Task AtualizarComRegra(Pessoa pessoa)
        {
            await _IPessoa.Atualizar(pessoa);
        }

        private static Pessoa Evalido(Pessoa pessoa)
        {
            if (!pessoa.Valido()) return pessoa;
            //Verifique se o nome excede
            pessoa = VerifiquaSeNomeExcede(pessoa);
            return pessoa;
        }

        //Verifique se o nome excede
        private static Pessoa VerifiquaSeNomeExcede(Pessoa pessoa)
        {
            if (pessoa.Nome.Length > 10)
                pessoa.Notificas.Add(new Notificar 
                { Mensagem = string.Format("Minimum 9 characters!"), Propriedade = "Nome" });
            return pessoa;
        }

        public Task<List<Pessoa>> ObterMuitos()
        {
            return _IPessoa.ObterMuitos(x => x.Nome.ToLower() != x.SobreNome.ToLower());
        }
    }
}
