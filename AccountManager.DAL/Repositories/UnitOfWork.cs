using System;
using AccountManager.DAL.Infrastructure;
using AccountManager.DAL.Interfaces;

namespace AccountManager.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private bool disposed;
        private IUserRepository nodeRepository;

        public UnitOfWork(Context context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public IUserRepository Users
        {
            get
            {
                if (nodeRepository == null)
                {
                    nodeRepository = new UserRepository(_context);
                }

                return nodeRepository;
            }
        }

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
