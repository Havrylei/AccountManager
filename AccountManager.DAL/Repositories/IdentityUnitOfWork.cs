using System;
using AccountManager.DAL.Entities;
using AccountManager.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AccountManager.DAL.Repositories
{
    public class IdentityUnitOfWork : IIdentityUnitOfWork, IDisposable
    {
        private readonly UserManager<User> _manager;
        private bool disposed;
        private IUserRepository userRepository;

        public IdentityUnitOfWork(UserManager<User> manager)
        {
            _manager = manager
                ?? throw new ArgumentNullException(nameof(manager));
        }

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_manager);
                }

                return userRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _manager.Dispose();
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
