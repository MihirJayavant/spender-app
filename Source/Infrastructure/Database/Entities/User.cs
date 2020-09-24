using u = Core.Transactional;

namespace Infrastructure.Database.Entities
{
    public class User : AuditableEntity
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }

        public u.User ToCore()
            => new u.User(id: Id, name: Name, isDefault: IsDefault, 
                            created: Created);
    }
}
