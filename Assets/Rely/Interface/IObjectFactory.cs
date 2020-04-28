using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace hyFramework.Rely
{
    public interface IObjectFactory<T>
    {
        //创建实例
        T Creat();
    }


    public class CreatInstaceObjectFactory<T> : IObjectFactory<T> where T : new()
    {
        public T Creat()
        {
            return new T();
        }
    }


    public class CustomObjectFactory<T> : IObjectFactory<T>
    {
        protected Func<T> factoryMethod;

        public CustomObjectFactory(Func<T> factorymethod)
        {
            this.factoryMethod = factorymethod;
        }

        public T Creat()
        {
            return factoryMethod();
        }
    }
}
