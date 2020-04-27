using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hyFramework.Rely
{
    public abstract class Singleton<T> : ISingleton where T : Singleton<T>
    {
        #region privateField

        private static object mLock = new object();
        #endregion

        #region protected
        protected static T instance;
        #endregion
        
        #region public

        public static T Instance
        {
            get
            {
                lock (mLock)
                {
                    if (instance == null)
                        instance = SingletonCreator.CreatSingleton<T>();
                }

                return instance;
            }
        }

        //对象初始化
        public virtual void OnSingletonInit()
        {

        }

        //释放对象
        public virtual void Dispose()
        {
            
        }
        #endregion
    }
}
