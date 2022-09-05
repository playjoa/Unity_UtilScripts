using UnityEngine;

namespace Utils.Animations
{
    public class ObjectRotator : MonoBehaviour
    {
        [Header("Target Transform")]
        [SerializeField] private Transform targetTransform;

        [Header("Axis Configuration")] 
        [SerializeField] private bool rotateX = false;
        [SerializeField] private bool rotateY = false;
        [SerializeField] private bool rotateZ = true;
        
        [Header("Speed Configuration")]
        [SerializeField] private float rotationVelocity = 300f;
        
        private const float DEFAULT_ROTATE_VALUE = 0;
        private bool Rotating => rotateX || rotateY || rotateZ;
        
#if UNITY_EDITOR
        private void OnValidate() => Awake();
#endif
        
        private void Awake() => targetTransform ??= GetComponent<Transform>();

        private void Update()
        {
            RotateObject();
        }

        private void RotateObject()
        {
            if (Rotating) return;
            
            var easedVelocity = rotationVelocity * Time.deltaTime;
            
            if (rotateX)
                RotateTransform(new Vector3(easedVelocity, DEFAULT_ROTATE_VALUE, DEFAULT_ROTATE_VALUE));

            if (rotateY)
                RotateTransform(new Vector3(DEFAULT_ROTATE_VALUE, easedVelocity, DEFAULT_ROTATE_VALUE));

            if (rotateZ)
                RotateTransform(new Vector3(DEFAULT_ROTATE_VALUE, DEFAULT_ROTATE_VALUE, easedVelocity));
        }

        private void RotateTransform(Vector3 rotationToSet) => targetTransform.Rotate(rotationToSet, Space.Self);
    }
}