using UnityEngine;

namespace Utils.Animations
{
    public class ObjectRotator : MonoBehaviour
    {
        [SerializeField] private bool rotateX = false, rotateY = false, rotateZ = true;
        [SerializeField] private float velRotation = 300f;

        private void Update()
        {
            RotateObject();
        }

        private void RotateObject()
        {
            if (rotateX)
                RotateTransform(new Vector3(velRotation * Time.deltaTime, 0, 0));

            if (rotateY)
                RotateTransform(new Vector3(0, velRotation * Time.deltaTime, 0));

            if (rotateZ)
                RotateTransform(new Vector3(0, 0, velRotation * Time.deltaTime));
        }

        private void RotateTransform(Vector3 rotationToSet) => transform.Rotate(rotationToSet, Space.Self);
    }
}