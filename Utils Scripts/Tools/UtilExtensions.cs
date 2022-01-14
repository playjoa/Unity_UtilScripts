using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;

namespace Utils.Tools
{
    public static class UtilExtensions
    {
        private static readonly Random Rng = new Random();

        public static TValue RandomValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            return dictionary.ElementAt(Rng.Next(dictionary.Count)).Value;
        }
        
        public static TKey RandomKey<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            return dictionary.ElementAt(Rng.Next(dictionary.Count)).Key;
        }

        public static T RandomElement<T>(this IList<T> list) => list[Rng.Next(list.Count)];
        
        public static T RandomElement<T>(this T[] array) => array[Rng.Next(array.Length)];
        
        public static int SecondsToMilliseconds(this int seconds) => seconds * 1000;
        
        public static string NiceCurrency(this int value) => value.ToString("N0");

        public static void SetCustomText(this TMP_Text tmpText, string text, string prefix = "", string suffix = "")
        {
            if (tmpText == null) return;
            tmpText.text = $"{prefix}{text}{suffix}";
        }
        
        public static string FloatToPercentage(this float progress) => (progress * 100f).ToString("F2") + "%";
    }
}