using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Utils.DOTweens.Data
{
    [Serializable]
    public class DOTweenAnimData
    {
        [SerializeField] private Ease ease;
        [SerializeField] private float animDelay = 0f;
        [SerializeField] private float animDuration = 0.35f;
        [SerializeField] [Range(0f, 1.5f)] private float animationTarget = 1f;
        [SerializeField] private UnityEvent onAnimationComplete;
        
        public DOTweenAnimData(Ease leanTween, float animationTarget = 1f, float animDuration = 0.35f)
        {
            ease = leanTween;
            this.animationTarget = animationTarget;
            this.animDuration = animDuration;
        }
        
        public Ease Ease => ease;
        public float Delay => animDelay;
        public float Duration => animDuration;
        public float Target => animationTarget;
        public UnityEvent OnAnimationComplete => onAnimationComplete;
    }
}