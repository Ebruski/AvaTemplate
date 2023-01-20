using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class CorporateRepository : BaseRepository<Corporate>, ICorporateRepository
    {
        public CorporateRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> CorporateNameExist(string name)
           => await context.Corporates
                    .AnyAsync(c => c.CorporateName.ToLower() == name.ToLower() && !c.IsDeleted);
    }
}
