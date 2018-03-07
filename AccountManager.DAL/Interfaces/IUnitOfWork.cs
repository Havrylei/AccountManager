namespace AccountManager.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRatingRepository UserRatings { get; }
        IMessageRepository Messages { get; }
    }
}
