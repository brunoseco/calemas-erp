using Common.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Common.Orm
{
    public class UnitOfWork<T> : IUnitOfWork
    {

        private DbContext _ctx;
        private bool _disposed;

        public UnitOfWork(T _ctx)
        {
            this._ctx = _ctx as DbContext;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public int Commit()
        {
            return this._ctx.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await this._ctx.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {

            if (!_disposed)
            {
                if (disposing)
                {
                    _ctx.Dispose();
                }
            }

        }

    }
}
