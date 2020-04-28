using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hyFramework.Rely
{
    public static class SingletonProperty<T> where T : class, ISingleton
    {
        #region privateField
        private static object mLock = new object();
        static T instance;
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

        public static void Dispose()
        {
            instance = null;
        }

        #endregion
    }
}
