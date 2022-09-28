using UnityEngine;

namespace Utils.SceneHeader
{
    public class SceneHeader : MonoBehaviour
    {
        public string title = "Header";

#if UNITY_EDITOR
        private void OnValidate()
        {
            SceneHeaderEditor.UpdateHeader(this);
        }
#endif

        private void OnDrawGizmos()
        {
            transform.position = Vector3.zero;
        }
    }
}