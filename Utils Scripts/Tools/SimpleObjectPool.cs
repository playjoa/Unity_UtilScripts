using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utils.Tools
{
    public class SimpleObjectPool<TPoolObject> where TPoolObject : MonoBehaviour
    {
        private readonly TPoolObject _poolObjectModel;
        private readonly List<TPoolObject> _objectPool = new List<TPoolObject>();
        private readonly RectTransform _rectTransformTarget;
        private readonly Transform _transformTarget;

        public SimpleObjectPool(TPoolObject poolObjectModel) => this._poolObjectModel = poolObjectModel;
        
        public SimpleObjectPool(TPoolObject poolObjectModel, RectTransform rectTransformTarget)
        {
            this._poolObjectModel = poolObjectModel;
            this._rectTransformTarget = rectTransformTarget;
        }
        
        public SimpleObjectPool(TPoolObject poolObjectModel, Transform transformTarget)
        {
            this._poolObjectModel = poolObjectModel;
            this._transformTarget = transformTarget;
        }

        public TPoolObject RequestObject(bool objectActive = false)
        {
            var targetObject = _objectPool.FirstOrDefault(t => !t.gameObject.activeSelf);

            if (targetObject != null)
            {
                targetObject.gameObject.SetActive(objectActive);
                return targetObject;
            }

            var newPoolObject = InstantiateInPool();
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
            foreach (var poolObject in _objectPool)
                poolObject.gameObject.SetActive(false);
        }

        public void ClearPool()
        {
            foreach (var poolObject in _objectPool)
                Object.Destroy(poolObject);
            
            _objectPool.Clear();
        }

        private TPoolObject InstantiateInPool()
        {
            TPoolObject newObject;

            if (_rectTransformTarget != null)
                newObject = Object.Instantiate(_poolObjectModel, _rectTransformTarget);
            else if (_transformTarget != null)
                newObject = Object.Instantiate(_poolObjectModel, _transformTarget);
            else
                newObject = Object.Instantiate(_poolObjectModel);
            
            _objectPool.Add(newObject);
            return newObject;
        }
    }
}