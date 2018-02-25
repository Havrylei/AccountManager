using System;
using AccountManager.DAL.Infrastructure;
using AccountManager.DAL.Interfaces;

namespace AccountManager.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private bool disposed;
        private IUserRepository userRepository;
        private IUserRatingRepository userRatingRepository;

        public UnitOfWork(Context context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_context);
                }

                return userRepository;
            }
        }

        public IUserRatingRepository UserRatings
        {
            get
            {
                if (userRatingRepository == null)
                {
                    userRatingRepository = new UserRatingRepository(_context);
                }

                return userRatingRepository;
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
