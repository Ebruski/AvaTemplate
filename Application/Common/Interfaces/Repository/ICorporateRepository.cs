using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface ICorporateRepository : IRepository<Corporate>
    {
        Task<bool> CorporateNameExist(string name);
    }
}