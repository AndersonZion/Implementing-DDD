using Domain.Interfaces.Genetics;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generics
{
    public class RepositoryGenerics<T> : IGeneric<T>, IDisposable where T : class
    {
        protected readonly ContextBase Db;
        protected readonly DbSet<T> DbSet;
        public RepositoryGenerics(ContextBase options)
        {
            Db = options;
            DbSet = Db.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity); //  throw new NotImplementedException();
        }

        public Task Atualizar(T entity)
        {
            DbSet.Update(entity);
            return Task.CompletedTask;
        }

        public Task DeletarAsync(T entity)
        {
            DbSet.Remove(entity);
            return Task.CompletedTask; 
        }

        public async Task<IEnumerable<T>> Obter()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> ObterPorIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Instantiate a SafeHandle instance.
        readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}
