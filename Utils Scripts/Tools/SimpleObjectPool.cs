using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utils.Tools
{
    public class SimpleObjectPool<TPoolObject> where TPoolObject : MonoBehaviour
    {
        private readonly TPoolObject poolObjectModel;
        private readonly List<TPoolObject> objectPool = new List<TPoolObject>();
        private readonly RectTransform rectTransformTarget;
        private readonly Transform transformTarget;

        public SimpleObjectPool(TPoolObject poolObjectModel) => this.poolObjectModel = poolObjectModel;
        
        public SimpleObjectPool(TPoolObject poolObjectModel, RectTransform rectTransformTarget)
        {
            this.poolObjectModel = poolObjectModel;
            this.rectTransformTarget = rectTransformTarget;
        }
        
        public SimpleObjectPool(TPoolObject poolObjectModel, Transform transformTarget)
        {
            this.poolObjectModel = poolObjectModel;
            this.transformTarget = transformTarget;
        }

        public TPoolObject RequestObject(bool objectActive = false)
        {
            var targetObject = objectPool.FirstOrDefault(t => !t.gameObject.activeSelf);

            if (targetObject != null)
            {
                targetObject.gameObject.SetActive(objectActive);
                return targetObject;
            }

            var newPoolObject = InstantiateInPool();
            objectPool.Add(newPoolObject);
            return newPoolObject;
        }
        
        public TPoolObject RequestActiveObject()
        {
            var targetObject = RequestObject();
            targetObject.gameObject.SetActive(true);
            return targetObject;
        }

        public void DeactivatePool()
        {
            foreach (var poolObject in objectPool)
                poolObject.gameObject.SetActive(false);
        }

        public void ClearPool()
        {
            foreach (var poolObject in objectPool)
                Object.Destroy(poolObject);
            
            objectPool.Clear();
        }

        private TPoolObject InstantiateInPool()
        {
            TPoolObject newObject;

            if (rectTransformTarget != null)
                newObject = Object.Instantiate(poolObjectModel, rectTransformTarget);
            else if (transformTarget != null)
                newObject = Object.Instantiate(poolObjectModel, transformTarget);
            else
                newObject = Object.Instantiate(poolObjectModel);
            
            objectPool.Add(newObject);
            return newObject;
        }
    }
}