using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Animations.Data
{
    [Serializable]
    public class DOTweenAnimData
    {
        [Header("General Animation Data")]
        [SerializeField] private Ease ease;
        [SerializeField] private float animDelay = 0f;
        [SerializeField] private float animDuration = 0.35f;
        [SerializeField] [Range(0f, 1.5f)] private float animationTarget = 1f;
        [SerializeField] private UnityEvent onComplete;
        
        public Ease Ease => ease;
        public float Delay => animDelay;
        public float Duration => animDuration;
        public float Target => animationTarget;
        public UnityEvent OnComplete => onComplete;
        
        public DOTweenAnimData(Ease ease, float animationTarget = 1f, float animDuration = 0.35f)
        {
            this.ease = ease;
            this.animationTarget = animationTarget;
            this.animDuration = animDuration;
        }
    }
}