

using System.Collections.Generic;

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

    public class PaginatedResult<T> : Paginated<IList<T>>
    {
        public PaginatedResult(IList<T> data, int limit, int offset): base(data, limit, offset)
        {

        }
    }
}
