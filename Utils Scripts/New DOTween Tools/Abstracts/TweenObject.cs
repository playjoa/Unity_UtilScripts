using Playgig.UI.Animations.Interfaces;
using UI.Animations.Data;
using UnityEngine;

namespace Utils.DOTweens.Abstracts
{
    public abstract class TweenObject : MonoBehaviour, ITweener
    {
        public virtual bool ObjectActive => gameObject.activeSelf;
        protected int AnimationIndex = 0;

        private void OnDestroy()
        {
            ComponentsToKillTweensOnDestroy();
            OnTweenObjectDestroy();
        }

        public virtual void OnTweenObjectDestroy()
        {
        }

        public void SetAnimationIndex(int newIndex)
        {
            AnimationIndex = newIndex;
        }
        
        public abstract void AnimateIn();
        public abstract void AnimateOut();
        protected abstract void ComponentsToKillTweensOnDestroy();
    }

    public abstract class TweenObject<TAnimData> : TweenObject where TAnimData : DOTweenAnimData
    {
        [Header("Animate In Data")]
        [SerializeField] protected TAnimData animateInData;

        [Header("Animate Out Data")] 
        [SerializeField] protected TAnimData animateOutData;
    }
}