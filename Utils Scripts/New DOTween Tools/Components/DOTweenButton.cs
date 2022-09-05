using DG.Tweening;
using UI.Animations.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils.UI;

namespace Utils.DOTweens.Components
{
    [RequireComponent(typeof(ButtonComponent))]
    public class DOTweenButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [Header("Button Animations Config.")] 
        [SerializeField] private DOTweenAnimData clickData = new DOTweenAnimData(Ease.OutBack, 0.85f, 0.1f);
        [SerializeField] private DOTweenAnimData releaseData = new DOTweenAnimData(Ease.OutBack, animDuration: 0.1f);

        [Header("Negative Feedback Config.")] 
        [SerializeField] private float duration = 0.5f;
        [SerializeField] private float strength = 20f;
        [SerializeField] private int vibrato = 30;
        
        public void OnPointerDown(PointerEventData eventData) => ExecuteAnimation(clickData);
        public void OnPointerUp(PointerEventData eventData) => ExecuteAnimation(releaseData);
        
        public void ExecuteAnimation(DOTweenAnimData animationData)
        {
            if (animationData.Ease == Ease.Unset) return;
            
            transform.DOScale( Vector3.one * animationData.Target, animationData.Duration)
                .SetDelay(animationData.Delay).SetEase(animationData.Ease)
                .OnComplete(() => animationData.OnComplete?.Invoke());
        }
        
        public void NegativeFeedBack()
        {
            transform.DOShakePosition(duration, strength, vibrato, fadeOut: true);
        }
    }
}