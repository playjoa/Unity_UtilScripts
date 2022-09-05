using System.Collections.Generic;
using System.Linq;
using UI.Animations.Data;
using UnityEngine;
using Utils.DOTweens.Abstracts;

namespace Utils.DOTweens.TweenObjects
{
    public class ListTween : TweenObject<DOTweenAnimData>
    {
        [Header("Targets to animate:")]
        [SerializeField] private List<TweenObject> tweenChildObjects  = new List<TweenObject>();

        private bool HasTargetsToAnimate => tweenChildObjects.Any();
        
        private void OnValidate() => tweenChildObjects ??= GetChildren();

        private void OnEnable() => AnimateIn();

        private List<TweenObject> GetChildren()
        {
            var targetTweenObjects = new List<TweenObject>();
            var children = transform.childCount;
            
            for (var i = 0; i < children; ++i)
            {
                var targetChild = transform.GetChild(i);
                var targetTweenObject = targetChild.GetComponent<TweenObject>();

                if (targetTweenObject == null) continue;
                targetTweenObjects.Add(targetTweenObject);
            }

            return targetTweenObjects;
        }

        public override void AnimateIn()
        {
            if (!HasTargetsToAnimate)
                tweenChildObjects = GetChildren();

            for (var i = 0; i < tweenChildObjects.Count; i++)
            {
                tweenChildObjects[i].SetAnimationIndex(i);
                tweenChildObjects[i].AnimateIn();
            }
        }

        public override void AnimateOut()
        {            
            if (!HasTargetsToAnimate)
                tweenChildObjects = GetChildren();

            for (var i = tweenChildObjects.Count - 1; i >= 0; i--)
            {
                tweenChildObjects[i].SetAnimationIndex(tweenChildObjects.Count - i);
                tweenChildObjects[i].AnimateOut();
            }
        }

        protected override void ComponentsToKillTweensOnDestroy()
        {
            
        }
    }
}