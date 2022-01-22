using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Utils.DOTweens.Data
{
    [Serializable]
    public class DOTweenSlideAnimData
    {
        [SerializeField] private SlideDirection slideDirection = SlideDirection.Down;
        [SerializeField] private Ease ease = Ease.OutBack;
        [SerializeField] private float slideDelay = 0f;
        [SerializeField] private float slideDuration = 0.35f;
        [SerializeField] private bool useTarget;
        [SerializeField] private Vector3 slideRectTransformTarget = Vector3.zero;
        [SerializeField] private UnityEvent onSlideComplete;

        public DOTweenSlideAnimData(SlideDirection slideDirection)
        {
            this.slideDirection = slideDirection;
        }
        
        public DOTweenSlideAnimData(Ease leanTween, bool useTarget = false)
        {
            ease = leanTween;
            this.useTarget = useTarget;
        }
        
        public SlideDirection Direction => slideDirection;
        public Ease Ease => ease;
        public float Delay => slideDelay;
        public float Duration => slideDuration;
        public bool UseTarget => useTarget;
        public Vector3 Target => slideRectTransformTarget;
        public UnityEvent SlideComplete => onSlideComplete;
    }
    
    public enum SlideDirection
    {
        Up,
        Down,
        Left,
        Right
    }
}