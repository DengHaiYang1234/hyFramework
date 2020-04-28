using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace hyFramework.Rely
{
    public class CustomObjectPool<T> : Pool<T>
    {
        private Action<T> resetMethod;

        public CustomObjectPool(Func<T> factoryMethod, Action<T> resetMethod = null,int initCount = 0)
        {
            objectFactory = new CustomObjectFactory<T>(factoryMethod);
            this.resetMethod = resetMethod;

            for (int i = 0; i < initCount; i++)
            {
                objectCacheStack.Push(objectFactory.Creat());
            }
        }

        public override bool Recycle(T obj)
        {
            resetMethod.Invoke(obj);

            objectCacheStack.Push(obj);

            return true;
        }
    }
}
