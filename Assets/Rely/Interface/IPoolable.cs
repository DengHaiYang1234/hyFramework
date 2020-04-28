using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hyFramework.Rely
{
    public interface IPoolable
    {
        //回收
        void OnRecycled();
        //是否已回收
        bool IsRecycled { get; set; }
    }
}
