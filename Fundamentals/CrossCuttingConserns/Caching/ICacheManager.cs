namespace Fundamentals.CrossCuttingConserns.Caching
{
    public interface ICacheManager
    {
        T GetT<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}