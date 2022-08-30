
using System.Collections.Generic;
using UnityGameFramework.Runtime;
using System;
namespace UGF_ECS
{
    /// <summary>
    /// 系统管理器
    /// </summary>
    public sealed class SystemManager
    {
        /// <summary>
        /// 系统列表
        /// </summary>
        private static List<BaseSystem> systemLi = new List<BaseSystem>();
        /// <summary>
        /// 待销毁的系统队列
        /// </summary>
        private static Queue<BaseSystem> disposeSystemQu = new Queue<BaseSystem>();
        /// <summary>
        /// 启动系统
        /// </summary>
        public static void Lanuch()
        {
            foreach (BaseSystem system in systemLi)
            {
                if(system==null)
                {
                    return;
                }
                system.Lanuch();
            }  
        }      
        /// <summary>
        /// 停止系统(指定某个系统类型进行停止)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Lanuch<T>()
        {
            foreach (BaseSystem system in systemLi)
            {
                if (system.GetType() == typeof(T))
                {
                    system.Lanuch();
                    return;
                }
            }
        }
        /// <summary>
        /// 停止系统(指定一系列系统类型进行停止)
        /// </summary>
        /// <param name="typeLi">系统类型列表</param>
        public static void Lanuch(List<Type> typeLi)
        {
            foreach (BaseSystem system in systemLi)
            {
                if (typeLi.Contains(system.GetType()))
                {
                    system.Lanuch();
                }
            }
        }
        /// <summary>
        /// 停止系统(所有系统停止)
        /// </summary>
        public static void Stop()
        {
            foreach (BaseSystem system in systemLi)
            {
                if (system == null)
                {
                    return;
                }
                system.Stop();
            }
        }
        /// <summary>
        /// 停止系统(指定某个系统类型进行停止)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Stop<T>()
        {
            foreach(BaseSystem system in systemLi)
            {
                if(system.GetType()== typeof(T))
                {
                    system.Stop();
                    return;
                }
            }
        }
        /// <summary>
        /// 停止系统(指定一系列系统类型进行停止)
        /// </summary>
        /// <param name="typeLi">系统类型列表</param>
        public static void Stop(List<Type> typeLi)
        {
            foreach (BaseSystem system in systemLi)
            {
                if (typeLi.Contains(system.GetType()))
                {
                    system.Stop();                     
                }
            }
        }
        /// <summary>
        /// 更新系统
        /// </summary>
        public static void Update()
        {
            foreach(BaseSystem system in systemLi)
            {
                if(system.IsDispose)
                {
                    continue;
                }
                system.Update();
            }
            if(disposeSystemQu.Count==0)
            {
                return;
            }
            BaseSystem tempSystem;
            for(int index= disposeSystemQu.Count; index > 0; index--)
            {
                tempSystem = disposeSystemQu.Peek();
                if (systemLi.Remove(tempSystem))
                {
                    Log.Debug("[UGF_ECS]系统:{0}移除成功!", tempSystem.GetType().Name);
                }
            }
            disposeSystemQu.Clear();
        }
        /// <summary>
        /// 添加系统
        /// </summary>
        /// <param name="system">系统</param>
        public static void Add(BaseSystem system)
        {
            if(systemLi.Contains(system))
            {
                return;
            }
            systemLi.Add(system);
        }
        /// <summary>
        /// 移除系统
        /// </summary>
        /// <param name="system">系统</param>
        public static void Remove(BaseSystem system)
        {
            if(!systemLi.Contains(system))
            {
                return;
            }
            system.Dispose();
            disposeSystemQu.Enqueue(system);
        }
    }
}
