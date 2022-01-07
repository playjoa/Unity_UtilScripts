using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Utils.DOTweens
{
    public class DOTweenPopUp : MonoBehaviour
    {
        [Header("Open PopUp Config:")]
        [SerializeField] private Ease typePopUpAnim = Ease.OutBack;
        [SerializeField] private float delayOfOpenAnim = 0.05f;
        [SerializeField] private float durationOfOpenAnim = 0.35f;
        [SerializeField] private UnityEvent OnPopUpOpened;
        
        [Header("Close PopUp Config:")]
        [SerializeField] private Ease typeCloseAnim = Ease.InOutBack;
        [SerializeField] private float delayToClosePopUp = 3f;
        [SerializeField] private UnityEvent OnPopUpClosed;

        private Vector3 originalLocalScale;

        private void Awake() => SaveOriginalLocalScale();
        private void OnEnable() => AnimatePopUp();
        private void SaveOriginalLocalScale() => originalLocalScale = transform.localScale;
        private void SetSizeToZero() => transform.localScale = Vector3.zero;

        private void AnimatePopUp()
        {
            SetSizeToZero();

            transform.DOScale(originalLocalScale, durationOfOpenAnim)
                .SetDelay(delayOfOpenAnim).SetEase(typePopUpAnim)
                .OnComplete(HandlePopUpOpened);
            
            Invoke(nameof(CloseAnimation), delayToClosePopUp);
        }
        
        private void CloseAnimation()
        {
            transform.DOScale(Vector3.zero, durationOfOpenAnim)
                .SetDelay(delayOfOpenAnim).SetEase(typeCloseAnim)
                .OnComplete(HandlePopUpClosed);
        }

        private void HandlePopUpOpened() => OnPopUpOpened?.Invoke();

        private void HandlePopUpClosed()
        {
            OnPopUpClosed?.Invoke();
            gameObject.SetActive(false);
        }
    }
}