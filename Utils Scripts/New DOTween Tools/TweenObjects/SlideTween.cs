using System.Collections.Generic;
using DG.Tweening;
using UI.Animations.Data;
using UnityEngine;
using Utils.DOTweens.Abstracts;

namespace Utils.DOTweens.TweenObjects
{
    public class SlideTween : TweenObject<DOTweenSlideAnimData>
    {
        [HideInInspector] 
        [SerializeField] private RectTransform objectRect;
        
        private readonly Dictionary<SlideDirection, Vector3> _targetDirections = new Dictionary<SlideDirection, Vector3>();

        private void OnValidate() => objectRect = GetComponent<RectTransform>();
        private void Awake() => GetDirectionsDictionary();
        private void OnEnable() => AnimateIn();
        
        private void GetDirectionsDictionary()
        {
            var topScreen = Screen.currentResolution.height;
            var screenWidth = Screen.currentResolution.width;
            var rect = objectRect.rect;
            var objectWidth = rect.width;
            var objectHeight = rect.height;

            _targetDirections.Add(SlideDirection.Down, new Vector3(0, - topScreen + objectHeight / 2f, 0));
            _targetDirections.Add(SlideDirection.Up, new Vector3(0, topScreen + objectHeight / 2f, 0));
            _targetDirections.Add(SlideDirection.Left, new Vector3(- screenWidth + objectWidth / 2f, 0, 0));
            _targetDirections.Add(SlideDirection.Right, new Vector3(screenWidth + objectWidth / 2f, 0, 0));
        }
        
        public override void AnimateIn()
        {
            objectRect.localPosition = _targetDirections[animateInData.Direction];
        
            objectRect.DOAnchorPos(animateInData.Target, animateInData.Duration)
                .SetDelay(animateInData.Delay).SetEase(animateInData.Ease)
                .OnComplete(() => animateInData.OnComplete?.Invoke());
        }

        public override void AnimateOut()
        {
            var targetToSlideTo = animateOutData.UseTarget ? animateOutData.Target : _targetDirections[animateOutData.Direction];
            
            objectRect.DOAnchorPos(targetToSlideTo, animateOutData.Duration)
                .SetDelay(animateOutData.Delay).SetEase(animateOutData.Ease)
                .OnComplete(() => animateOutData.OnComplete?.Invoke());
        }

        protected override void ComponentsToKillTweensOnDestroy()
        {
            objectRect.DOKill();
        }
    }
}