using System;
using DG.Tweening;
using UnityEngine;

namespace Utils.DOTweens.Components
{
    public static class DOTweenExtensions
    {
        public static void DOPopScale(this Transform transformToPop, float duration = 0.125f, Ease ease = Ease.OutBack, Action doAfter = null, float popMultiplier = 1.1f)
        {
            if (DOTween.IsTweening(transformToPop)) return;

            var originalScale = transformToPop.localScale.x;

            transformToPop.DOScale(originalScale * popMultiplier, duration).SetEase(ease);
            transformToPop.DOScale(originalScale, duration).SetDelay(duration).SetEase(ease)
                .OnComplete(() => doAfter?.Invoke());
        }
    }
}