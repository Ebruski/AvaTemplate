using Application.Common.Interfaces.Repository;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.DbConfiguration
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext,
            ICorporateRepository corporateService)
        {
            _dbContext = dbContext;
            CorporateService = corporateService;
        }
        public ICorporateRepository CorporateService { get; private set; }
        public Task CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}