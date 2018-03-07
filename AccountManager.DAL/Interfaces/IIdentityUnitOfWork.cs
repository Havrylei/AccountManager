namespace AccountManager.DAL.Interfaces
{
    public interface IIdentityUnitOfWork
    {
        IUserRepository Users { get; }
    }
}
