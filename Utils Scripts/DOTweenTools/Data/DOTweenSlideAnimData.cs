using System;
using DG.Tweening;
using UnityEngine;

namespace UI.Animations.Data
{
    [Serializable]
    public class DOTweenSlideAnimData : DOTweenAnimData
    {
        [Header("Slide In Data")]
        [SerializeField] private SlideDirection slideDirection = SlideDirection.Down;
        
        [Space]
        [SerializeField] private bool useTarget;
        [SerializeField] private Vector3 slideRectTransformTarget = Vector3.zero;
        
        public SlideDirection Direction => slideDirection;
        public bool UseTarget => useTarget;
        public new Vector3 Target => slideRectTransformTarget;
        
        public DOTweenSlideAnimData(Ease ease) : base(ease)
        {
        }
    }
}