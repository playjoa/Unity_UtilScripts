using System;
using System.Collections.Generic;

namespace Utils.Extensions
{
    public static class ListExtensions
    {
        private static readonly Random Rng = new Random();
        
        public static T RandomElement<T>(this IList<T> list) => list[Rng.Next(list.Count)];
        
        public static T RandomElement<T>(this T[] array) => array[Rng.Next(array.Length)];
    }
}