using UnityEngine;

namespace Utils.UI.Tabs.Abstracts
{
    public abstract class TabFeedback : MonoBehaviour
    {
        [Header("Target Tab Option")]
        [SerializeField] protected TabButtonUI targetTabButton;

        protected virtual void Awake()
        {
            if (targetTabButton == null) return;

            targetTabButton.OnSelected += OnSelectTabSelectHandler;
            targetTabButton.OnDeselected += OnDeselectTabSelectHandler;
            targetTabButton.OnHover += OnTabHoverHandler;
            targetTabButton.OnPressed += OnPressTabHandler;
        }

        protected virtual void OnDestroy()
        {
            if (targetTabButton == null) return;
            
            targetTabButton.OnSelected -= OnSelectTabSelectHandler;
            targetTabButton.OnDeselected -= OnDeselectTabSelectHandler;
            targetTabButton.OnHover -= OnTabHoverHandler;
            targetTabButton.OnPressed -= OnPressTabHandler;
        }

        protected void Reset()
        {
            var tabOption = GetComponent<TabButtonUI>();

            if (tabOption != null)
            {
                targetTabButton = tabOption;
            }
        }

        protected virtual void OnSelectTabSelectHandler()
        {
        }
        
        protected virtual void OnDeselectTabSelectHandler()
        {
        }
        
        protected virtual void OnTabHoverHandler(bool hoverState)
        {
        }
        
        protected virtual void OnPressTabHandler(bool pressState)
        {
        }
    }
}