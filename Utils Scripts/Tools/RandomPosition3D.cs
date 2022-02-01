using UnityEngine;

namespace Utils.Tools
{
    public class RandomPosition3D : MonoBehaviour
    {
        [SerializeField] private Color GizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);

        private float xRange = 10f, yRange = 10f, zRange = 10f;
        private static float Range(float scale, float range) => scale + Random.Range(-range, range);

        private void OnDrawGizmos()
        {
            Gizmos.color = GizmosColor;
            Gizmos.DrawCube(transform.position, transform.localScale);
        }

        private void Awake()
        {
            Initialize();
        }

        //Gets stats from localscale of your spawn area
        private void Initialize()
        {
            xRange = transform.localScale.x / 2f;
            yRange = transform.localScale.y / 2f;
            zRange = transform.localScale.z / 2f;
        }

        ///<summary>
        ///Will choose a random position inside area choosing a random X, Z and with fixed Y value.
        ///</summary>
        public Vector3 SpawnPositionCustomHeight(float customY = 0)
        {
            var position = transform.position;
            return new Vector3(Range(position.x, xRange), customY, Range(position.z, zRange));
        }

        ///<summary>
        ///Will choose a random position in X, Y Z.
        ///</summary>
        public Vector3 SpawnPosition()
        {
            var position = transform.position;
            return new Vector3(Range(position.x, xRange), Range(position.y, yRange), Range(position.z, zRange));
        }
    }
}