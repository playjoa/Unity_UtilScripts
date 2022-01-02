using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.Tweens;

namespace Utils.UI
{
    public class ButtonComponent : Button
    {
        [SerializeField] private Image thisImage;
        [SerializeField] private Button thisButton;
        [SerializeField] private TextMeshProUGUI thisText;
        [SerializeField] private ButtonTweenAnimations thisButtonAnimations;
        
        public Image Image => thisImage;
        public Button Button => thisButton;
        public TextMeshProUGUI Text => thisText;
        public ButtonTweenAnimations ButtonAnimations => thisButtonAnimations;

        private const string TextName = "txtButtonInfo";

        private void OnValidate()
        {
            thisImage = GetComponent<Image>();
            thisButton = GetComponent<Button>();
            thisText = GetComponentInChildren<TextMeshProUGUI>();
            thisButtonAnimations = GetComponent<ButtonTweenAnimations>();

            if (thisButtonAnimations == null)
                thisButtonAnimations = gameObject.AddComponent<ButtonTweenAnimations>();
            
            if (thisText) thisText.name = TextName;
        }

        public void Disable() => thisButton.interactable = false;
        public void Enable() => thisButton.interactable = true;
    }
}