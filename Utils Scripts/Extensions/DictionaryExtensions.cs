using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils.Extensions
{
    public static class DictionaryExtensions
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
    }
}