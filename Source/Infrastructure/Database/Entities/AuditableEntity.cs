using System;

namespace Infrastructure.Database.Entities
{
    public class AuditableEntity : Entity
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
