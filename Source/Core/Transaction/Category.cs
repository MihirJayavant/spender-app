
namespace Core.Transaction
{
    public enum CategoryType
    {
        Entertainment = 1, Food = 2, Travel = 3,
        shopping = 4, Salary = 5, Other = 6
    }
    public interface ICategory
    {
        CategoryType Type { get; }
        string Name { get; }
    }

    public sealed class Category : ICategory
    {
        public string Name { get; }

        public CategoryType Type { get; }

        public Category(CategoryType type, string name) => (Type, Name) = (type, name);

        public override bool Equals(object obj)
            => obj switch
            {
                Category c => c.Type == Type,
                _ => false
            };

        public override int GetHashCode()
            => Name.GetHashCode();
    }
}
