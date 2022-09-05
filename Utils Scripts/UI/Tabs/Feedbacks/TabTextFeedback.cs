using Utils.UI.Tabs.Abstracts;
using Utils.UI.Tabs.Data;
using TMPro;
using UnityEngine;

namespace Utils.UI.Tabs.Feedbacks
{
    public class TabTextFeedback : TabFeedback
    {
        [Header("Target Components")] 
        [SerializeField] private TextMeshProUGUI textMeshPro;

        [Header("Data")] 
        [SerializeField] private TabColorsData colorsData;

        protected override void OnSelectTabSelectHandler()
        {
            textMeshPro.color = colorsData.SelectedColor;
        }

        protected override void OnDeselectTabSelectHandler()
        {
            textMeshPro.color = colorsData.DeselectedColor;
        }

        protected override void OnTabHoverHandler(bool hoverState)
        {
            if (hoverState)
            {
                textMeshPro.color = colorsData.HoverColor;
            }
            else
            {
                ReturnToPreviousState(targetTabButton.IsSelected);
            }
        }

        protected override void OnPressTabHandler(bool pressState)
        {
            if (pressState)
            {
                textMeshPro.color = colorsData.PressedColor;
            }
            else
            {
                ReturnToPreviousState(targetTabButton.IsSelected);
            }
        }

        private void ReturnToPreviousState(bool isSelected)
        {
            if (isSelected)
            {
                OnSelectTabSelectHandler();
            }
            else
            {
                OnDeselectTabSelectHandler();
            }
        }
    }
}