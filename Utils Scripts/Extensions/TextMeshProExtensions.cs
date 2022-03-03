using TMPro;

namespace Utils.Extensions
{
    public static class TextMeshProExtensions
    {
        public static void SetCustomText(this TMP_Text tmpText, string text, string prefix = "", string suffix = "")
        {
            if (tmpText == null) return;
            tmpText.text = $"{prefix}{text}{suffix}";
        }
        
        public static string SetTextMeshProSize(this string text, int textSize)
        {
            return $"<size={textSize}>{text}</size>";
        }
        
        public static string SetTextMeshProSize(this int text, int textSize)
        {
            return $"<size={textSize}>{text}</size>";
        }
    }
}