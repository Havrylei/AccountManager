﻿namespace AccountManager.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
    }
}
