namespace AccountManager.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRatingRepository UserRatings { get; }
        IMessageRepository Messages { get; }
        ICountryRepository Countries { get; }
        IGenderRepository Genders { get; }
    }
}
