using DG.Tweening;
using UnityEngine;

namespace Utils.Animations
{
    public class PulseAnimation : MonoBehaviour
    {
        [SerializeField] private float baseSize = 1;

        private void OnDisable()
        {
            transform.localScale = Vector3.one * baseSize;
        }

        private void Update()
        {
            Animate();
        }

        private void Animate()
        {
            if (DOTween.IsTweening(gameObject.transform)) return;

            var anim = baseSize + Mathf.Sin(Time.time * 5.5f) * baseSize / 30f;
            transform.localScale = Vector3.one * anim;
        }
    }
}
