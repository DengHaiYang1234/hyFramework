using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hyFramework.Rely
{
    public interface IPool<T>
    {
        //分配内存
        T Allocate();
        //回收
        bool Recycle(T obj);
    }
}

