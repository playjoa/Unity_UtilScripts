using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.DOTweens;

namespace Utils.UI
{
    public class ButtonComponent : Button
    {
        [SerializeField] private Image thisImage;
        [SerializeField] private TextMeshProUGUI thisText;
        [SerializeField] private DOTweenButton thisButtonAnimations;
        
        public Image Image => thisImage;
        public TextMeshProUGUI Text => thisText;
        public DOTweenButton ButtonAnimations => thisButtonAnimations;

        private const string TextName = "ButtonInfoText";

        private void OnValidate()
        {
            thisImage = GetComponent<Image>();
            thisText = GetComponentInChildren<TextMeshProUGUI>();
            thisButtonAnimations = GetComponent<DOTweenButton>();

            if (thisButtonAnimations == null)
                thisButtonAnimations = gameObject.AddComponent<DOTweenButton>();
            
            if (thisText) thisText.name = TextName;
        }

        public void Disable() => interactable = false;
        public void Enable() => interactable = true;
    }
}