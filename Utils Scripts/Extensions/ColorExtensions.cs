using UnityEngine;
using UnityEngine.UI;

namespace Utils.Extensions
{
    public static class ColorExtensions
    {
        public static Color SetAlpha(this Color color, float a)
        {
            return new Color(color.r, color.g, color.b, a);
        }

        public static void SetAlpha(this Graphic graphic, float a)
        {
            graphic.color = graphic.color.SetAlpha(a);
        }

        public static void SetAlpha(this SpriteRenderer renderer, float a)
        {
            renderer.color = renderer.color.SetAlpha(a);
        }

        public static string ToHex(this Color color)
        {
            return $"#{(int) (color.r * 255):X2}{(int) (color.g * 255):X2}{(int) (color.b * 255):X2}";
        }
    }
}