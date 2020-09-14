using System;

namespace Infrastructure.Database.Entities
{
    public class User : AuditableEntity
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    }
}
