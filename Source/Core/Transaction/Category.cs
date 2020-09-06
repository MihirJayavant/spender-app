using System.Drawing;

namespace Core.Transaction
{
    public interface ICategory
    {
        public string Name { get; }
        public string Icon { get; }
        public Color Color { get; }
    }
}
