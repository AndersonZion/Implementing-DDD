using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGenericApp<T> where T : class
    {
        Task<IEnumerable<T>> Obter();
        Task<T> ObterPorIdAsync(int id);
        Task AddAsync(T entity);
        Task DeletarAsync(T entity);
        Task Atualizar(T entity);
    }
}
