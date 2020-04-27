using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hyFramework.Rely
{
    /// <summary>
    /// 对象池基类
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    public abstract class Pool<T> : IPool<T>, ICountObserveAble
    {
        #region protected

        protected IObjectFactory<T> objectFactory;

        protected Stack<T> objectCacheStack = new Stack<T>();

        protected int maxCount = 12;

        #endregion

        #region public
        /// <summary>
        /// 对象分配内存
        /// </summary>
        /// <returns></returns>
        public virtual T Allocate()
        {
            return objectCacheStack.Count == 0 ? objectFactory.Creat() : objectCacheStack.Pop();
        }
        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public abstract bool Recycle(T obj);
        /// <summary>
        /// 缓存对象合计
        /// </summary>
        public int CurrentCount
        {
            get { return objectCacheStack.Count; }
        }
        #endregion
    }
}

