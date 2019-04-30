
using System;
using System.Collections.Generic;
namespace Common.ObjectPool
{ 
    public abstract class ObjectPool< T> : UnityEngine.MonoBehaviour, IDisposable
    {
        public int countInit = 0;//初始化时的大小
        public int countMax = int.MaxValue;//对象池容量上限

        public List<T> inPools = new List<T>();
        private List<T> _outPools = new List<T>();

        public List<T> OutPools
        {
            get { return _outPools; }
        }

        protected void Init()
        {
            while (inPools.Count < countInit)
            {
                T t = CreateObject();
                ResetObject(t);
                inPools.Add(t);
            }
        }

        //销毁对象池
        public virtual void Dispose()
        {
            for (int i = 0, count = inPools.Count; i < count; i++)
            {
                T t = inPools[i];
                DisposeObject(t);
                t = default(T);
            }

            for (int i = 0, count = _outPools.Count; i < count; i++)
            {
                T t = _outPools[i];
                DisposeObject(t);
                t = default(T);
            }
            inPools.Clear();
            _outPools.Clear();
            inPools = null;
            _outPools = null;
        }

        public T ExitPool()
        {
            int bestIndex = inPools.Count - 1;
            if (bestIndex >= 0)
            {
                T t = inPools[bestIndex];
                _outPools.Add(t);
                inPools.RemoveAt(bestIndex);
                SetObject(t);
                return t;
            }

            if (inPools.Count + _outPools.Count < countMax)
            {
                T t = CreateObject();
                SetObject(t);
                _outPools.Add(t);
                return t;
            }

            //MDebug.LogError(string.Format("ObjectPool is arrived CountMax :{0}", countMax));
            return default(T);
        }

        public void EnterPool(T obj)
        {
            for (int i = 0, count = _outPools.Count; i < count; i++)
            {
                T t = _outPools[i];
                if (t.Equals(obj))
                {
                    ResetObject(t);
                    inPools.Add(t);
                    _outPools.RemoveAt(i);
                    break;
                }
            }
        }

        public void EnterAll()
        {
            inPools.AddRange(_outPools);
            for (int i = 0, count = _outPools.Count; i < count; i++)
            {
                T t = _outPools[i];
                ResetObject(t);
            }
            _outPools.Clear();
        }

        protected abstract T CreateObject();//创建一个对象
        protected abstract void SetObject(T t);
        protected abstract void ResetObject(T t);//重置一个对象
        protected abstract void DisposeObject(T t);//销毁一个对象

    }
}
