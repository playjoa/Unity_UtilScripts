using System;
using DG.Tweening;
using UnityEngine;

namespace Utils.DOTweens
{
    public static class DOTweenExtensions
    {
        public static void DOPopScale(this Transform transformToPop, float duration = 0.125f, Ease ease = Ease.OutBack,
            Action doAfter = null)
        {
            if (DOTween.IsTweening(transformToPop)) return;

            var originalScale = transformToPop.localScale.x;

            transformToPop.DOScale(originalScale * 1.1f, duration).SetEase(ease);
            transformToPop.DOScale(originalScale, duration).SetDelay(duration).SetEase(ease)
                .OnComplete(() => doAfter?.Invoke());
        }
    }
}