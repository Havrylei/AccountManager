using System;
using AccountManager.DAL.Infrastructure;
using AccountManager.DAL.Interfaces;

namespace AccountManager.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Context _context;
        private bool disposed;
        private IUserRatingRepository userRatingRepository;
        private IMessageRepository messageRepository;
        private ICountryRepository countryRepository;
        private IGenderRepository genderRepository;

        public UnitOfWork(Context context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
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

        public IMessageRepository Messages
        {
            get
            {
                if (messageRepository == null)
                {
                    messageRepository = new MessageRepository(_context);
                }

                return messageRepository;
            }
        }

        public ICountryRepository Countries
        { 
            get
            {
                if (countryRepository == null)
                {
                    countryRepository = new CountryRepository(_context);
                }

                return countryRepository;
            }
        }

        public IGenderRepository Genders
        {
            get
            {
                if (genderRepository == null)
                {
                    genderRepository = new GenderRepository(_context);
                }

                return genderRepository;
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
