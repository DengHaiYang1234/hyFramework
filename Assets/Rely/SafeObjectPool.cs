using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hyFramework.Rely
{
    public class SafeObjectPool<T> : Pool<T>, ISingleton where T : IPoolable, new()
    {
        #region privateField
        #endregion

        #region protected

        protected SafeObjectPool()
        {
            objectFactory = new CreatDefaultObjectFactory<T>();
        }

        #endregion

        #region public

        public static SafeObjectPool<T> Instacne
        {
            //TODO
            get { return Singleton<SafeObjectPool<T>>.Instance; }
        }

        public override bool Recycle(T obj)
        {
            throw new System.NotImplementedException();
        }

        public void OnSingletonInit()
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region private
        #endregion





    }
}
