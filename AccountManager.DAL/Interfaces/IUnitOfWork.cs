using System.Threading.Tasks;

namespace AccountManager.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IMessageRepository Messages { get; }
    }
}
