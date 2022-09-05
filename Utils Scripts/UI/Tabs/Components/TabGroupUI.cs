using System.Collections.Generic;
using System.Linq;
using Utils.UI.Tabs.Abstracts;
using UnityEngine;

namespace Utils.UI.Tabs.Components
{
    public class TabGroupUI : MonoBehaviour
    {
        [Header("Tabs")]
        [SerializeField] protected List<TabButtonUI> tabOptions;

        [Header("Configuration")] 
        [SerializeField] protected bool autoSelectFirstTabOnStart = true;
        [SerializeField] protected bool autoSelectFirstTabOnEnable = false;
        
        private TabButtonUI _currentSelectedTab;

        protected virtual void Start()
        {
            Initiate();
        }

        protected void OnEnable()
        {
            if (autoSelectFirstTabOnEnable)
            {
                SelectTab(tabOptions.FirstOrDefault());
            }
        }

        protected virtual void Reset()
        {
            tabOptions = new List<TabButtonUI>();
            foreach (Transform child in transform)
            {
                var tabOption = child.GetComponent<TabButtonUI>();

                if (tabOption != null)
                    tabOptions.Add(tabOption);
            }
        }

        protected virtual void Initiate()
        {
            foreach (var tabOption in tabOptions)
            {
                tabOption.Initiate(this);
                tabOption.Deselect();
            }
            
            if (autoSelectFirstTabOnStart)
            {
                SelectTab(tabOptions.FirstOrDefault());
            }
        }

        public virtual void SelectTab(TabButtonUI targetTab)
        {
            if (targetTab == null) return;

            if (_currentSelectedTab != null)
            {
                _currentSelectedTab.Deselect();
            }

            _currentSelectedTab = targetTab;
            _currentSelectedTab.Select();
        }
    }
}