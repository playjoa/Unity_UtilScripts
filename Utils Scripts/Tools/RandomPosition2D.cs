using UnityEngine;

namespace Utils.Tools
{
    public class RandomPosition2D : MonoBehaviour
    {
        [SerializeField] private Color colorOfAreaInEditor = new Color(0.5f, 0.5f, 0.5f, 0.2f);

        private float xRange = 10f, yRange = 10f;
        private float OffSetValue(float valueToOffSet, float range) => valueToOffSet + Random.Range(-range, range);

        private void OnDrawGizmos()
        {
            Gizmos.color = colorOfAreaInEditor;
            Gizmos.DrawCube(transform.position, transform.localScale);
        }

        private void Awake()
        {
            InitializeRangeValues();
        }

        private void InitializeRangeValues()
        {
            xRange = transform.localScale.x / 2f;
            yRange = transform.localScale.y / 2f;
        }

        ///<summary>
        ///Will choose a random position inside this area (X, Y).
        ///</summary>
        public Vector2 RandomLocationInsideArea()
        {
            return new Vector3(OffSetValue(transform.position.x, xRange), OffSetValue(transform.position.y, yRange), 0);
        }
    }
}