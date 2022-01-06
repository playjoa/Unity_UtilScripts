using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils.DOTweens.Data;
using Utils.UI;

namespace Utils.DOTweens
{
    [RequireComponent(typeof(ButtonComponent))]
    public class DOTweenButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [Header("Button Animations Config.")] 
        [SerializeField] private DOTweenAnimData clickData = new DOTweenAnimData(Ease.OutBack, 0.85f, 0.1f);
        [SerializeField] private DOTweenAnimData releaseData = new DOTweenAnimData(Ease.OutBack, animDuration: 0.1f);
        [SerializeField] private DOTweenAnimData negativeData = new DOTweenAnimData(Ease.InBack, 1.15f, 0.15f);

        private bool _givingNegativeFeedback;
        
        public void ExecuteAnimation(DOTweenAnimData animationData)
        {
            if (_givingNegativeFeedback) return;
            if (animationData.Ease == Ease.Unset) return;
                
            transform.DOKill();

            transform.DOScale( Vector3.one * animationData.Target, animationData.Duration)
                .SetDelay(animationData.Delay).SetEase(animationData.Ease)
                .OnComplete(() => animationData.OnAnimationComplete?.Invoke());
        }

        public void OnPointerDown(PointerEventData eventData) => ExecuteAnimation(clickData);
        public void OnPointerUp(PointerEventData eventData) => ExecuteAnimation(releaseData);

        public void NegativeFeedBack()
        {
            if (_givingNegativeFeedback) return;
            
            transform.DOKill();

            _givingNegativeFeedback = true;
            var duration = negativeData.Duration;
            var easeType = negativeData.Ease;
            var target = negativeData.Target;
            var onComplete = negativeData.OnAnimationComplete;

            transform.DOScale(Vector3.one * target, duration).SetEase(easeType);
            transform.DOScale(Vector3.one, duration).SetDelay(duration).SetEase(easeType)
                .OnComplete(() => 
                { 
                    _givingNegativeFeedback = false;
                    onComplete?.Invoke(); 
                });
        }
    }
}