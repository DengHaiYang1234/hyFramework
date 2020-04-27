using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hyFramework.Rely
{
    public interface ICountObserveAble
    {
        //记录所分配的对象计数
        int CurrentCount { get; }
    }
}
