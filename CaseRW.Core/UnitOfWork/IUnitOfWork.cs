namespace CaseRW.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commmit();
    }
}
