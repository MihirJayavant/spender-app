

namespace Core.Data
{
    public class Paginated<T>
    {
        public int Limit { get; }
        public int Offset { get; }
        public T Data { get; }

        public Paginated(T data, int limit, int offset)
            => (Data, Limit, Offset) = (data, limit, offset);
    }
}
