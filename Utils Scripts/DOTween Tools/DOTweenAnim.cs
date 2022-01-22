using DG.Tweening;
using UnityEngine;
using Utils.DOTweens.Data;

namespace Utils.DOTweens
{
    public class DOTweenAnim : MonoBehaviour
    {
        [Header("Open Animation Config:")]
        [SerializeField] private DOTweenAnimData openAnimationData = new DOTweenAnimData(Ease.OutBack);

        [Header("Close Animation Config:")] 
        [SerializeField] private DOTweenAnimData closeAnimationData = new DOTweenAnimData(Ease.InBack);

        private Vector3 initialSize;

        private void Awake() => GetInitialSize();
        private void OnEnable() => OpenAnimation();

        public void OpenAnimation()
        {
            if (openAnimationData.Ease == Ease.Unset) return;
            
            transform.localScale = Vector3.zero;
            transform.DOScale(initialSize, openAnimationData.Duration)
                .SetDelay(openAnimationData.Delay).SetEase(openAnimationData.Ease)
                .OnComplete(() => openAnimationData.OnAnimationComplete?.Invoke());
        }

        public void CloseAnimation()
        {
            if (openAnimationData.Ease == Ease.Unset)  return;
            
            transform.DOScale(Vector3.zero, closeAnimationData.Duration)
                .SetDelay(closeAnimationData.Delay).SetEase(closeAnimationData.Ease)
                .OnComplete(ToDoAfterCloseAnimation);
        }

        private void ToDoAfterCloseAnimation()
        {
            ResetCardSize();
            closeAnimationData.OnAnimationComplete?.Invoke();
        }

        private void GetInitialSize() => initialSize = transform.localScale;
        private void ResetCardSize() => transform.localScale = initialSize;
    }
}