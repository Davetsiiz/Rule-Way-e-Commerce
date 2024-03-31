using CaseRW.Core.UnitOfWork;
using CaseRW.Repository.Context;

namespace CaseRW.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public void Commmit()
        {
            _appDbContext.SaveChanges();
        }
    }
}
