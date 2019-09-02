
using UnityEngine;
namespace Common.ObjectPool
{
    public class GameObjectPool : ObjectPool<GameObject>
    {
        public GameObject targetRoot;
        public GameObject root;
        public GameObject prefab;

        public virtual void Awake()
        {
            if (root == null)
            {
                root = new GameObject("inPools");
                root.transform.SetParent(transform, false);
            }
            Init();
        }

        public virtual void OnDestroy()
        {
            Dispose();
        }

        protected override GameObject CreateObject()
        {
            GameObject go;

            if (prefab != null)
            {
                go = UnityEngine.Object.Instantiate(prefab) as GameObject;
            }
            else
            {
                go = GameObject.CreatePrimitive(PrimitiveType.Cube);//创建基本物体
            }
            return go;
        }

        protected override void SetObject(GameObject t)
        {
            if (targetRoot != null)
            {
                t.transform.SetParent(targetRoot.transform, false);
            }
            t.transform.localPosition = Vector3.zero;
            t.transform.localRotation = Quaternion.identity;
            t.transform.localScale = Vector3.one;
            t.SetActive(true);
        }

        protected override void ResetObject(GameObject t)
        {
            ParticleSystem[] particleSystemArr = t.GetComponentsInChildren<ParticleSystem>(true);
            for(int i = 0, len = particleSystemArr.Length; i < len; i++)
            {
                ParticleSystem particleSystem = particleSystemArr[i];
                particleSystem.Clear(true);
                particleSystem.Stop(true);
            }
            t.transform.SetParent(root.transform, false);
//            t.transform.localPosition = Vector3.zero;
			t.transform.localPosition = new Vector3(0,-10000,0);
            t.transform.localRotation = Quaternion.Euler(Vector3.zero);
            t.transform.localScale = Vector3.one;
            t.SetActive(false);
        }

        protected override void DisposeObject(GameObject t)
        {
            UnityEngine.Object.Destroy(t);
        }

    }


}
