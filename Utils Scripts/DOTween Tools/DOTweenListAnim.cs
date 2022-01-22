using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Utils.DOTweens
{
    public class DOTweenListAnim : MonoBehaviour
    {
        [Header("Animation Config:")]
        [SerializeField] private Ease easeInType = Ease.OutBack;
        [SerializeField] private Ease easeOutType = Ease.InBack;

        [SerializeField] private float delayOfAnim = 0.05f;
        [SerializeField] private float durationOfAnim = 0.35f;
        [SerializeField] private float delayOfNextCard = 0.05f;
        
        [Header("In Animation Callback:")]
        [SerializeField] private UnityEvent onInAnimationComplete;
        [Header("Out Animation Callback:")]
        [SerializeField] private UnityEvent onOutAnimationComplete;
        
        [Header("Targets to animate:")]
        [SerializeField] private List<Transform> transformChildrenToAnimate  = new List<Transform>();

        private bool HasTargetsToAnimate => transformChildrenToAnimate.Any();

        private void OnValidate() => transformChildrenToAnimate = GetChildren();

        private void OnEnable() => AnimateListIn();

        private List<Transform> GetChildren()
        {
            var allChildren = new List<Transform>();

            var children = transform.childCount;
            for (var i = 0; i < children; ++i)
                allChildren.Add(transform.GetChild(i));

            return allChildren;
        }

        public void AnimateListIn()
        {
            if (!HasTargetsToAnimate)
                transformChildrenToAnimate = GetChildren();

            for (var i = 0; i < transformChildrenToAnimate.Count; i++)
                AnimateCardIn(transformChildrenToAnimate[i], delayOfNextCard * i, easeInType,
                    i == transformChildrenToAnimate.Count - 1);
        }

        public void AnimateListOut()
        {            
            if (!HasTargetsToAnimate)
                transformChildrenToAnimate = GetChildren();

            for (var i = transformChildrenToAnimate.Count - 1; i >= 0; i--)
                AnimateCardOut(transformChildrenToAnimate[i], delayOfNextCard * i, easeInType, i == 0);
        }

        private void AnimateCardIn(Transform currentCard, float animationDelay, Ease ease, bool attachOnComplete)
        {
            currentCard.DOKill();
            currentCard.localScale = Vector3.zero;

            if (!attachOnComplete)
            {
                currentCard.DOScale(Vector3.one, durationOfAnim)
                    .SetDelay(delayOfAnim + animationDelay)
                    .SetEase(ease);
                return;
            }
            
            currentCard.DOScale(Vector3.one, durationOfAnim)
                .SetDelay(delayOfAnim + animationDelay)
                .SetEase(ease).OnComplete(() => onInAnimationComplete?.Invoke());
        }
        
        private void AnimateCardOut(Transform currentCard, float animationDelay, Ease typeAnim,  bool attachOnComplete)
        {
            currentCard.DOKill();

            if (!attachOnComplete)
            {
                currentCard.DOScale(Vector3.zero, durationOfAnim)
                    .SetDelay(delayOfAnim + animationDelay)
                    .SetEase(typeAnim);
                return;
            }

            currentCard.DOScale(Vector3.zero, durationOfAnim)
                .SetDelay(delayOfAnim + animationDelay)
                .SetEase(typeAnim).OnComplete(() => onOutAnimationComplete?.Invoke());
        }
    }
}