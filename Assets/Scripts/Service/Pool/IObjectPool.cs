namespace Service.Pool
{
    public interface IObjectPool<T> where T : class
    {
        T Get();
        void Release(T obj);
    }
}