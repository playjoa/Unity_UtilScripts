using System;
using UnityEngine;

namespace Utils.UI.Tabs.Data
{
    [Serializable]
    public struct TabColorsData
    {
        [Header("On Selected Configuration")] 
        [SerializeField] private Color selectedColor;

        [Header("On Deselected Configuration")] 
        [SerializeField] private Color deselectedColor;
        
        [Header("On Hover Configuration")] 
        [SerializeField] private Color hoverColor;
        
        [Header("On Press Configuration")] 
        [SerializeField] private Color pressedColor;
        
        public Color SelectedColor => selectedColor;
        public Color DeselectedColor => deselectedColor;
        public Color HoverColor => hoverColor;
        public Color PressedColor => pressedColor;
    }
}