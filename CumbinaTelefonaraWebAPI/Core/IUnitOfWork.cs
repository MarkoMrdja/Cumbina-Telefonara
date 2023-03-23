namespace CumbinaTelefonaraWebAPI.Core
{
    public interface IUnitOfWork
    {
        IPhoneRepository Phones { get; }
        Task CompleteAsync();
    }
}
