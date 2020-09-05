using System;

namespace Core.User
{
    public sealed class User
    {
        public int Id { get; }
        public string Name { get; }
        public bool IsDefault { get; }
        public DateTime Created { get; }

        public User(int id, string name, bool isDefault, DateTime created)
        {
            Id = id;
            Name = name;
            IsDefault = isDefault;
            Created = created;
        }
    }
}
