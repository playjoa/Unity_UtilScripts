using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Utils.DOTweens.Data;

namespace Utils.DOTweens
{
    
    public class DOTweenSlideAnim : MonoBehaviour
    {
        [Header("Slide In Config")] 
        [SerializeField] private DOTweenSlideAnimData slideAnimationData = new DOTweenSlideAnimData(Ease.OutBack);
        [SerializeField] private DOTweenSlideAnimData slideOutData = new DOTweenSlideAnimData(Ease.InBack);

        [HideInInspector] 
        [SerializeField] private RectTransform objectRect;
        
        private readonly Dictionary<SlideDirection, Vector3> targetDirections = new Dictionary<SlideDirection, Vector3>();

        private void OnValidate()
        {
            objectRect = GetComponent<RectTransform>();
        }

        private void Awake()
        {
            GetDirectionsDictionary();
        }

        private void GetDirectionsDictionary()
        {
            var topScreen = Screen.currentResolution.height;
            var screenWidth = Screen.currentResolution.width;
            var rect = objectRect.rect;
            var objectWidth = rect.width;
            var objectHeight = rect.height;

            targetDirections.Add(SlideDirection.Down, new Vector3(0, - topScreen + objectHeight / 2f, 0));
            targetDirections.Add(SlideDirection.Up, new Vector3(0, topScreen + objectHeight / 2f, 0));
            targetDirections.Add(SlideDirection.Left, new Vector3(- screenWidth + objectWidth / 2f, 0, 0));
            targetDirections.Add(SlideDirection.Right, new Vector3(screenWidth + objectWidth / 2f, 0, 0));
        }

        private void OnEnable()
        {
            SlideIn();
        }

        public void SlideIn()
        {
            objectRect.localPosition = targetDirections[slideAnimationData.Direction];
            
            transform.DOLocalMove(slideAnimationData.Target, slideAnimationData.Duration)
                .SetDelay(slideAnimationData.Delay).SetEase(slideAnimationData.Ease)
                .OnComplete(() => slideAnimationData.SlideComplete?.Invoke());
        }

        public void SlideOut()
        {
            transform.DOLocalMove(targetDirections[slideOutData.Direction], slideOutData.Duration)
                .SetDelay(slideAnimationData.Delay).SetEase(slideAnimationData.Ease)
                .OnComplete(() => slideOutData.SlideComplete?.Invoke());
        }
    }
}