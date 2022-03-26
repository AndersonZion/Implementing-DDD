using Domain.Interfaces.Genetics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesDomains
{
    public interface IPessoa: IGeneric<Pessoa>
    {
        Task<List<Pessoa>> ObterMuitos (Expression<Func<Pessoa, bool>> filter = null);
    }
}
