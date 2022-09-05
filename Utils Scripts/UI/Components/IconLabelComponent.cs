using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Utils.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class IconLabelComponent : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;
        [SerializeField] private Image iconImage;

        public TextMeshProUGUI Text => textMeshProUGUI;
        public Image Icon => iconImage;
        
        private void OnValidate()
        {
            textMeshProUGUI = GetComponent<TextMeshProUGUI>();
            iconImage = GetComponentInChildren<Image>();
        }
    }
}