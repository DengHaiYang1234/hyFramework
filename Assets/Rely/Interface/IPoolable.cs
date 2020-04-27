using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hyFramework.Rely
{
    public interface IPoolable
    {
        void OnRecycled();
        bool IsRectcled { get; set; }
    }
}
