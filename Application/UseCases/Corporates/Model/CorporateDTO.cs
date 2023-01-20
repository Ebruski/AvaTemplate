using Application.Common.Mappings;
using Domain.Entities;

namespace Application.UseCases.Corporates.Model
{
    public class CorporateDTO : IMapFrom<Corporate>
    {
        public string Id { get; set; }
        public string CorporateName { get; set; }
    }
}
