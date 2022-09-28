using UnityEngine;

namespace Utils.GameTools
{
    public class RandomPosition2D : MonoBehaviour
    {
        [SerializeField] private Color colorOfAreaInEditor = new Color(0.5f, 0.5f, 0.5f, 0.2f);

        private float _xRange = 10f;
        private float _yRange = 10f;
        private static float OffSetValue(float valueToOffSet, float range) => valueToOffSet + Random.Range(-range, range);

        private void OnDrawGizmos()
        {
            Gizmos.color = colorOfAreaInEditor;
            var transform1 = transform;
            Gizmos.DrawCube(transform1.position, transform1.localScale);
        }

        private void Awake()
        {
            InitializeRangeValues();
        }

        private void InitializeRangeValues()
        {
            var localScale = transform.localScale;
            _xRange = localScale.x / 2f;
            _yRange = localScale.y / 2f;
        }

        ///<summary>
        ///Will choose a random position inside this area (X, Y).
        ///</summary>
        public Vector2 RandomLocationInsideArea()
        {
            var position = transform.position;
            return new Vector3(OffSetValue(position.x, _xRange), OffSetValue(position.y, _yRange), 0);
        }
    }
}