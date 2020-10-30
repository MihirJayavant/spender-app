
using System.Linq;

namespace Core.Transactional
{
    public static class Categories
    {
        public static ICategory[] Get => new ICategory[] 
        {
            new Category(CategoryType.Other, "Others"),
            new Category(CategoryType.Salary, "Salary")
        };
        public static ICategory Parse(string name) => Get.First(p => p.Name == name);
        public static ICategory Parse(CategoryType type) => Get.First(p => p.Type == type);
    }
}
