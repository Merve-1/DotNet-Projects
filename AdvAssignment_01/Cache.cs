namespace AdvAssignment_01;

using System;
using System.Collections.Generic;

class CacheItem<T>
{
    public T Value { get; set; }
    public DateTime Expiration { get; set; }
}

class Cache<TKey, TValue>
{
    private Dictionary<TKey, CacheItem<TValue>> cache
        = new Dictionary<TKey, CacheItem<TValue>>();

    public void Add(TKey key, TValue value, int seconds)
    {
        cache[key] = new CacheItem<TValue>
        {
            Value = value,
            Expiration = DateTime.Now.AddSeconds(seconds)
        };
    }

    public TValue Get(TKey key)
    {
        if (!cache.ContainsKey(key))
            return default;

        var item = cache[key];

        if (DateTime.Now > item.Expiration)
        {
            cache.Remove(key);
            return default;
        }

        return item.Value;
    }

    public bool Contains(TKey key)
    {
        return cache.ContainsKey(key);
    }

    public void Remove(TKey key)
    {
        cache.Remove(key);
    }

}