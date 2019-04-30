
namespace Common.ObjectPool
{
    public interface IRefObject
    {
        void AddRef();
        void RemoveRef();
    }

    public abstract class RefObject : IRefObject
    {
        private int _refCount;
        protected abstract void Release();
        public void AddRef()
        {
            _refCount++;
        }

        public void RemoveRef()
        {
            _refCount--;
            if (_refCount <= 0)
            {
                _refCount = 0;
                Release();
            }
        }

    }
}
