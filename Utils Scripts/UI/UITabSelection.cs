using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utils.UI
{
    public class UITabSelection : MonoBehaviour
    {
        [Header("Tabs")]
        [Tooltip("First One is Default")]
        [SerializeField] private List<UITab> tabOptions;

        [Header("Configuration")] 
        [SerializeField] private Color selectedColor = Color.green;
        [SerializeField] private Color notSelectedColor = Color.gray;
        [SerializeField] private bool resetOnEnable;
        
        private void Awake() => SetUpTabOptions();

        private void OnEnable()
        {
            if (resetOnEnable) 
                SetUpTabOptions();
        }

        private void SetUpTabOptions()
        {
            if(!tabOptions.Any()) return;

            var firstTab = tabOptions.FirstOrDefault();
            DeactivateTabs();
            SelectTab(firstTab);
        }

        public void RequestTabSwitch(string tabToGo)
        {
            tabToGo = tabToGo.ToLower();
            var targetTab = tabOptions.FirstOrDefault(tab => tab.TabId.Equals(tabToGo));

            if (targetTab == null) return;
            
            DeactivateTabs();
            SelectTab(targetTab);
        }

        private void SelectTab(UITab targetTab)
        {
            targetTab?.ToggleTab();            
            targetTab?.TabButton.SetButtonColor(selectedColor);
        }

        private void DeactivateTabs()
        {
            foreach (var tab in tabOptions)
            {
                tab.ToggleTab(false);
                tab.TabButton.SetButtonColor(notSelectedColor);
            }
        }
    }

    [Serializable]
    public class UITab
    {
        [SerializeField] private string tabId;
        [SerializeField] private GameObject targetTab;
        [SerializeField] private UITabButton tabButton;

        public void ToggleTab(bool valueToSet = true) => targetTab.SetActive(valueToSet);
        public string TabId => tabId.ToLower();
        public UITabButton TabButton => tabButton;
    }
}