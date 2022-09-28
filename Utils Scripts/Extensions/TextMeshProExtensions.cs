using System.Text;
using TMPro;
using UnityEngine;

namespace Utils.Extensions
{
    public static class TextMeshProExtensions
    {
        public static StringBuilder AddEnter(this StringBuilder stringBuilder)
        {
            if (stringBuilder is null) return new StringBuilder();

            stringBuilder.Append("\n");

            return stringBuilder;
        }
        
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

        public static string Colored(this string message, Color color)
        {
            return $"<color={color.ToHex()}>{message}</color>";
        }

        public static string Colored(this string message, string colorCode)
        {
            return $"<color={colorCode}>{message}</color>";
        }

        public static string Underlined(this string message)
        {
            return $"<u>{message}</u>";
        }
        
        public static string Bold(this string message)
        {
            return $"<b>{message}</b>";
        }
        
        public static string Italics(this string message)
        {
            return $"<i>{message}</i>";
        }
    }
}