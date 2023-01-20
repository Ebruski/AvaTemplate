using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        ICorporateRepository CorporateService { get; }
        Task CommitAsync();
    }
}
