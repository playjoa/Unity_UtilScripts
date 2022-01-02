using UnityEngine;

namespace Utils.UI
{
    [RequireComponent(typeof(ButtonComponent))]
    public class UITabButton : MonoBehaviour
    {
        [Header("Tab Selection")] 
        [SerializeField] private UITabSelection tabSelection;

        [Header("Tab Configuration")] 
        [SerializeField] private string targetTabId = "skins";

        [SerializeField] private ButtonComponent buttonComponent;

        private void OnValidate() => buttonComponent = GetComponent<ButtonComponent>();
        private void Awake() => buttonComponent.onClick.AddListener(ButtonTabClickHandler);
        private void OnDestroy() => buttonComponent.onClick.RemoveListener(ButtonTabClickHandler);
        private void ButtonTabClickHandler() => tabSelection.RequestTabSwitch(targetTabId);
        public void SetButtonColor(Color colorToSet) => buttonComponent.Image.color = colorToSet;
    }
}