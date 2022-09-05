using DG.Tweening;
using UI.Animations.Data;
using UnityEngine;
using Utils.DOTweens.Abstracts;

namespace Utils.DOTweens.TweenObjects
{
    public class PopUpTween : TweenObject<DOTweenAnimData>
    {
        [SerializeField] private RectTransform targetTransformToTween;

        private Vector3 _initialSize;
        
        private void Awake() => GetInitialSize();

        private void GetInitialSize()
        {
            _initialSize = targetTransformToTween.localScale;
        }

        private void ResetCardSize()
        {
            targetTransformToTween.localScale = _initialSize;
        }
        
        public override void AnimateIn()
        {
            if (DOTween.IsTweening(targetTransformToTween)) return;
            
            gameObject.SetActive(true);
            
            targetTransformToTween.localScale = Vector3.zero;
            targetTransformToTween.DOScale(_initialSize, animateInData.Duration)
                .SetDelay(animateInData.Delay * AnimationIndex).SetEase(animateInData.Ease)
                .OnComplete(() => animateInData.OnComplete?.Invoke());
        }

        public override void AnimateOut()
        {
            if (DOTween.IsTweening(targetTransformToTween)) return;
            
            targetTransformToTween.DOScale(Vector3.zero, animateOutData.Duration)
                .SetDelay(animateOutData.Delay * AnimationIndex).SetEase(animateOutData.Ease)
                .OnComplete(ToDoAfterCloseAnimation);
        }

        protected override void ComponentsToKillTweensOnDestroy()
        {
            targetTransformToTween.DOKill();
        }
        
        private void ToDoAfterCloseAnimation()
        {
            ResetCardSize();
            animateOutData.OnComplete?.Invoke();
            gameObject.SetActive(false);
        }
    }
}