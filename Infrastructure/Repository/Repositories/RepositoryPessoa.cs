using Domain.Interfaces.InterfacesDomains;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryPessoa : RepositoryGenerics<Pessoa>, IPessoa
    {
        public RepositoryPessoa(ContextBase context) : base(context) { }

        public async Task<List<Pessoa>> ObterMuitos(Expression<Func<Pessoa, bool>> filter = null)
        {
            return await Db.Pessoas.Where(filter).AsNoTracking().ToListAsync();
        }
    }
}
