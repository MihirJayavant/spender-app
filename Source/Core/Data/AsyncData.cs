
namespace Core.Data
{

    public class AsyncData<T> where T : class
    {
        public AsyncDataState State { get; } = AsyncDataState.Initial;
        public T? Data { get; }
        public string Error { get; } = "";

        public bool IsLoaded => State == AsyncDataState.Loaded;
        public bool IsLoading => State == AsyncDataState.Loading;
        public bool HasError => State == AsyncDataState.Error;

        public AsyncData(T? data, AsyncDataState state = AsyncDataState.Initial, string error = "")
            => (Data, State, Error) = (data, state, error);

        public static AsyncData<T> Initial(T? data = null) => new AsyncData<T>(data);

        public static AsyncData<T> Loading(T? data = null) => new AsyncData<T>(data, AsyncDataState.Loading);

        public static AsyncData<T> Loaded(T data) => new AsyncData<T>(data, AsyncDataState.Loaded);

        public static AsyncData<T> ErrorMessage(string error, T? data = null)
            => new AsyncData<T>(data, AsyncDataState.Error, error);

    }
}
