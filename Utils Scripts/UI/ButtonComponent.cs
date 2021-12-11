using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Utils.UI
{
    [RequireComponent(typeof(Button))]
    public class ButtonComponent : MonoBehaviour
    {
        [SerializeField] private Button thisButton;
        [SerializeField] private TextMeshProUGUI thisText;

        public Button Button => thisButton;
        public TextMeshProUGUI Text => thisText;

        private const string TextName = "txtButtonInfo";
        
        private void OnValidate()
        {
            thisButton = GetComponent<Button>();
            thisText = GetComponentInChildren<TextMeshProUGUI>();

            if (thisText) thisText.name = TextName;
        }
    }
}