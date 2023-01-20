using Domain.Common;

namespace Domain.Entities
{
    public class Corporate : AuditableEntity
    {
        public string CorporateName { get; set; }
    }
}
