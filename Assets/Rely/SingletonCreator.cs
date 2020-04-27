using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System;

namespace hyFramework.Rely
{
    public static class SingletonCreator
    {
        public static T CreatSingleton<T>() where T : class, ISingleton
        {
            //BindingFlags.Instance:指定实例成员要包括在搜索中。
            //BindingFlags.NonPublic:指定非公共成员要包括在搜索中。
            //总结就是获取私有的构造函数
            var ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);

            //私有的且无参的构造函数
            var ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);

            if (ctor == null)
            {
                throw new Exception("-------> 对象不存在无参的构造函数，创建单利失败！" + typeof(T));
            }

            //初始化构造函数
            var instance = ctor.Invoke(null) as T;
            instance.OnSingletonInit();

            return instance;
        }

    }
}
