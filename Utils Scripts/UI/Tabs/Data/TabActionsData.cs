using System;
using UnityEngine;
using UnityEngine.Events;

namespace Utils.UI.Tabs.Data
{
    [Serializable]
    public struct TabActionsData
    {
        [Header("On Selected Configuration")] 
        [SerializeField] private UnityEvent onTabSelected;
        
        [Header("On Deselected Configuration")] 
        [SerializeField] private UnityEvent onTabDeselected;
        
        [Header("On Hover Configuration")] 
        [SerializeField] private UnityEvent<bool> onTabHover;
        
        [Header("On Press Configuration")] 
        [SerializeField] private UnityEvent<bool> onTabPressed;
        
        public UnityEvent TabSelected => onTabSelected;
        public UnityEvent TabUnselected => onTabDeselected;
        public UnityEvent<bool> TabHover => onTabHover;
        public UnityEvent<bool> TabPressed => onTabPressed;
    }
}