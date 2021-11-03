using DataAccess.EFCore.Interfaces;
using Domain;
using System;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly TtnContext _context;

        private ISttnRepository _sttns;

        private IGenericRepository<Zttn> _zttns;

        public UnitOfWork(TtnContext context)
        {
            _context = context;
        }

        public ISttnRepository STTNs
        {
            get
            {
                if (_sttns == null)
                {
                    _sttns = new SttnRepository(_context);
                }

                return _sttns;
            }
        }

        public IGenericRepository<Zttn> ZTTNs
        {
            get
            {
                if (_zttns == null)
                {
                    _zttns = new GenericRepository<Zttn>(_context);
                }

                return _zttns;
            }
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
