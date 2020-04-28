using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hyFramework.Rely
{
    public class CustomObjectPoolCache : ISingleton
    {
        readonly Dictionary<Type, object> objectPools;

        public CustomObjectPoolCache()
        {
            objectPools = new Dictionary<Type, object>();
        }

        public CustomObjectPool<T> GetObjectPool<T>(Func<bool, Func<T>> failCallback = null) where T : new()
        {
            object objectPool;
            var type = typeof(T);

            if (!objectPools.TryGetValue(type, out objectPool))
            {
                var f = failCallback(false);
                objectPool = new CustomObjectPool<T>(f);
                objectPools.Add(type, objectPool);
            }

            return objectPool as CustomObjectPool<T>;
        }

        public T Get<T>(Func<bool, Func<T>> failCallback = null) where T : new()
        {
            return GetObjectPool<T>(failCallback).Allocate();
        }

        public void Push<T>(T obj) where T : new()
        {
            GetObjectPool<T>().Recycle(obj);
        }

        public void RegisterCustomObjectPool<T>(CustomObjectPool<T> objectPool)
        {
            objectPools.Add(typeof(T), objectPool);
        }

        public void Reset()
        {
            objectPools.Clear();
        }

        public void OnSingletonInit()
        {

        }
    }
}
