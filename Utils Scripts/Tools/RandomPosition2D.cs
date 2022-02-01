using UnityEngine;

namespace Utils.Tools
{
    public class RandomPosition2D : MonoBehaviour
    {
        [SerializeField] private Color colorOfAreaInEditor = new Color(0.5f, 0.5f, 0.5f, 0.2f);

        private float xRange = 10f, yRange = 10f;
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
            xRange = localScale.x / 2f;
            yRange = localScale.y / 2f;
        }

        ///<summary>
        ///Will choose a random position inside this area (X, Y).
        ///</summary>
        public Vector2 RandomLocationInsideArea()
        {
            var position = transform.position;
            return new Vector3(OffSetValue(position.x, xRange), OffSetValue(position.y, yRange), 0);
        }
    }
}