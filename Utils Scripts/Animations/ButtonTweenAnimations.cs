using UnityEngine;
using UnityEngine.EventSystems;
using Utils.Tweens;
using Utils.UI;

namespace Utils.Animations
{
    [RequireComponent(typeof(ButtonComponent))]
    public class ButtonTweenAnimations : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [Header("Click Animation Config.")] [SerializeField]
        private TweenAnimationData clickData = new TweenAnimationData(LeanTweenType.easeOutBack, 0.85f, 0.1f);

        [Header("Release Animation Config.")] [SerializeField]
        private TweenAnimationData releaseData = new TweenAnimationData(LeanTweenType.easeOutBack, animDuration: 0.1f);

        [Header("Negative Feedback Animation Config.")] [SerializeField]
        private TweenAnimationData negativeData = new TweenAnimationData(LeanTweenType.easeShake, animDuration: 0.35f);

        public void ExecuteAnimation(TweenAnimationData animationData)
        {
            if (animationData.EaseType == LeanTweenType.notUsed) return;

            if (LeanTween.isTweening(gameObject))
                LeanTween.cancel(gameObject);

            LeanTween.scale(gameObject, Vector3.one * animationData.Target, animationData.Duration)
                .setDelay(animationData.Delay).setEase(animationData.EaseType)
                .setOnComplete(() => animationData.OnAnimationComplete?.Invoke());
        }

        public void OnPointerDown(PointerEventData eventData) => ExecuteAnimation(clickData);

        public void OnPointerUp(PointerEventData eventData) => ExecuteAnimation(releaseData);

        public void NegativeFeedBack()
        {
            if (LeanTween.isTweening(gameObject))
                LeanTween.cancel(gameObject);

            var duration = negativeData.Duration;
            var easeType = negativeData.EaseType;

            LeanTween.scale(gameObject, Vector3.one * 1.05f, duration).setEase(easeType);
            LeanTween.scale(gameObject, Vector3.one, duration).setDelay(duration).setEase(easeType);
        }
    }
}