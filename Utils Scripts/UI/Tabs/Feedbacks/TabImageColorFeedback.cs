using Utils.UI.Tabs.Abstracts;
using Utils.UI.Tabs.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Utils.UI.Tabs.Feedbacks
{
    public class TabImageColorFeedback : TabFeedback
    {
        [Header("Images")]
        [SerializeField] private Image targetImage;

        [Header("Data")] 
        [SerializeField] private TabColorsData colorsData;
        
        protected override void OnSelectTabSelectHandler()
        {
            targetImage.color = colorsData.SelectedColor;
        }

        protected override void OnDeselectTabSelectHandler()
        {
            targetImage.color = colorsData.DeselectedColor;
        }
        
        protected override void OnTabHoverHandler(bool hoverState)
        {
            if (hoverState)
            {
                targetImage.color = colorsData.HoverColor;
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
                targetImage.color = colorsData.PressedColor;
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