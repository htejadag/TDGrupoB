using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDB.Ms.Producto.Infraestructura.Context
{
    internal class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IMongoDbContext _context;

        private readonly IClientSessionHandle _session;

        private bool IsInTransaction;

        public UnitOfWork(IMongoDbContext context)
        {
            _context = context;
            _session = _context.Client.StartSession();
        }

        public async Task AbortTransaction()
        {
            if (IsInTransaction)
            {
                await _session.AbortTransactionAsync();
            }
        }

        public async Task Commit()
        {
            try
            {
                if (IsInTransaction)
                {
                    _session.CommitTransaction();
                    IsInTransaction = false;
                }
            }
            catch (Exception ex)
            {
                _ = ex;
                if (IsInTransaction)
                {
                    await _session.AbortTransactionAsync();
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IClientSessionHandle GetSession()
        {
            return _session;
        }

        public void StartTransaction()
        {
            _session.StartTransaction();
            IsInTransaction = true;
        }
    }
}
