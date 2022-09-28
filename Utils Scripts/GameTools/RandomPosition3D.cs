using UnityEngine;

namespace Utils.GameTools
{
    public class RandomPosition3D : MonoBehaviour
    {
        [SerializeField] private Color gizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);

        private Transform _areaTransform;
        
        private float _xRange = 10f;
        private float _yRange = 10f;
        private float _zRange = 10f;
        
        private static float Range(float scale, float range) => scale + Random.Range(-range, range);

        private void OnDrawGizmos()
        {
            Gizmos.color = gizmosColor;
            Gizmos.DrawCube(transform.position, transform.localScale);
        }

        private void Awake()
        {
            Initialize();
        }

        //Gets stats from localscale of your spawn area
        private void Initialize()
        {
            _areaTransform = transform;
            var localScale = _areaTransform.localScale;
            _xRange = localScale.x / 2f;
            _yRange = localScale.y / 2f;
            _zRange = localScale.z / 2f;
        }

        ///<summary>
        ///Will choose a random position inside area choosing a random X, Z and with fixed Y value.
        ///</summary>
        public Vector3 SpawnPositionCustomHeight(float customY = 0)
        {
            var position = transform.position;
            return new Vector3(Range(position.x, _xRange), customY, Range(position.z, _zRange));
        }

        ///<summary>
        ///Will choose a random position in X, Y Z.
        ///</summary>
        public Vector3 SpawnPosition()
        {
            var position = transform.position;
            return new Vector3(Range(position.x, _xRange), Range(position.y, _yRange), Range(position.z, _zRange));
        }
    }
}