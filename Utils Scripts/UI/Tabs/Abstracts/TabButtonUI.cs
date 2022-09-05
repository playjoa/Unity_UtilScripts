using System;
using Utils.UI.Tabs.Components;
using Utils.UI.Tabs.Data;
using Utils.UI.Tabs.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Utils.UI.Tabs.Abstracts
{
    public class TabButtonUI : MonoBehaviour, ITabButton, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("Target Button")] 
        [SerializeField] private ButtonComponent tabButton;

        [Header("Tab Actions")]
        [SerializeField] private TabActionsData tabActionsData;

        public event Action OnSelected;
        public event Action OnDeselected;
        public event Action<bool> OnHover;
        public event Action<bool> OnPressed;
        public bool IsSelected { get; private set; }
        
        private TabGroupUI _ownerGroupUI;
        
        private void Awake()
        {
            tabButton.onClick.AddListener(OnTabSSelectAttemptHandler);
        }

        private void OnDestroy()
        {
            tabButton.onClick.RemoveListener(OnTabSSelectAttemptHandler);
        }

        public virtual void Initiate(TabGroupUI tabGroupUI)
        {
            _ownerGroupUI = tabGroupUI;
            IsSelected = false;
        }

        public virtual void Select()
        {
            tabActionsData.TabSelected?.Invoke();
            OnSelected?.Invoke();
            IsSelected = true;
        }

        public virtual void Deselect()
        {
            tabActionsData.TabUnselected?.Invoke();
            OnDeselected?.Invoke();
            IsSelected = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Press(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Press(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Hover(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Hover(false);
        }

        private void Hover(bool hoverState)
        {
            tabActionsData.TabHover?.Invoke(hoverState);
            OnHover?.Invoke(hoverState);
            OnHoverHandler(hoverState);
        }

        private void Press(bool pressState)
        {
            tabActionsData.TabPressed?.Invoke(pressState);
            OnPressed?.Invoke(pressState);
            OnPressHandler(pressState);
        }
        
        private void OnTabSSelectAttemptHandler()
        {
            _ownerGroupUI.SelectTab(this);
        }
        
        protected virtual void OnHoverHandler(bool hoverState)
        {
        }

        protected virtual void OnPressHandler(bool pressState)
        {
        }
    }
}