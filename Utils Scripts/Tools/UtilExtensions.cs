using System;
using System.Collections.Generic;
using TMPro;

namespace Utils.Tools
{
    public static class UtilExtensions
    {
        private static readonly Random Rng = new Random();

        public static T RandomElement<T>(this IList<T> list) => list[Rng.Next(list.Count)];
        public static T RandomElement<T>(this T[] array) => array[Rng.Next(array.Length)];
        public static int SecondsToMilliseconds(this int seconds) => seconds * 1000;
        public static string NiceCurrency(this int value) => value.ToString("N0");
        
        public static void SetCustomText(this TMP_Text textFieldTarget, string content, string prefix = "", string suffix ="")
        {
            if(textFieldTarget == null) return;
            textFieldTarget.text = $"{prefix}{content}{suffix}";
        }
    }
}