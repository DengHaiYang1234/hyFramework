using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hyFramework.Rely
{
    public interface IObjectFactory<T>
    {
        //创建实例
        T Creat();
    }


    public class CreatDefaultObjectFactory<T> : IObjectFactory<T> where T : new()
    {
        public T Creat()
        {
            return new T();
        }
    }
}
