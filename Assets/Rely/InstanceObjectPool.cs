using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hyFramework.Rely
{
    //实例对象池
    public class InstanceObjectPool<T> : Pool<T>, ISingleton where T : IPoolable, new()
    {
        #region privateField

        private int maxCount;
        #endregion

        #region protected

        protected InstanceObjectPool()
        {
            objectFactory = new CreatInstaceObjectFactory<T>();
        }

        #endregion

        #region public
        /// <summary>
        /// 对象栈最大缓存数量
        /// </summary>
        public int MaxCacheCount
        {
            get { return maxCount; }
            set
            {
                maxCount = value;
                if (objectCacheStack != null)
                {
                    if (maxCount > 0)
                    {
                        if (maxCount < objectCacheStack.Count)
                        {
                            int removeCount = objectCacheStack.Count - maxCount;
                            while (removeCount > 0)
                            {
                                objectCacheStack.Pop();
                                --removeCount;
                            }
                        }
                    }
                }
            }
        }

        public static InstanceObjectPool<T> Instacne
        {
            get { return SingletonProperty<InstanceObjectPool<T>>.Instance; }
        }

        /// <summary>
        /// 分配内存，创建实例
        /// </summary>
        /// <returns> 对象实例 </returns>
        public override T Allocate()
        {
            var result = base.Allocate();
            result.IsRecycled = false;
            return result;
        }
        
        /// <summary>
        /// 初始化对象池最大个数和初始化格式
        /// </summary>
        /// <param name="maxCount"> 最大缓存个数 </param>
        /// <param name="initCount"> 初始缓存个数 </param>
        public void Init(int maxCount, int initCount)
        {
            MaxCacheCount = maxCount;

            if (maxCount > 0)
            {
                initCount = Mathf.Min(maxCount, initCount);
            }


            if (CurrentCount < initCount)
            {
                for (int i = CurrentCount; i < initCount; i++)
                {
                    Recycle(new T());
                }
            }
        }

        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="t"> 对象 </param>
        /// <returns> 是否完成回收 </returns>
        public override bool Recycle(T t)
        {
            if (t == null || t.IsRecycled)
            {
                return false;
            }


            if (maxCount > 0)
            {
                if (objectCacheStack.Count >= maxCount)
                {
                    t.OnRecycled();
                    return false;
                }
            }

            //表示当前对象已经回收
            t.IsRecycled = true;
            //对象释放
            t.OnRecycled();
            objectCacheStack.Push(t);

            return true;
        }

        public void OnSingletonInit()
        {
            
        }

        public void DisPose()
        {
            SingletonProperty<InstanceObjectPool<T>>.Dispose();
        }

        #endregion
    }
}
