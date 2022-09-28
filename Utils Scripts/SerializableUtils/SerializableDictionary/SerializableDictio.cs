using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.SerializableUtils
{
    [Serializable]
    public class SerializableDictio<TKeyValue, TValueType>
    {
        [SerializeField] private SerializableDictioValue<TKeyValue, TValueType>[] dictionaryValues;

        public bool Initialized { get; private set; }
        public Dictionary<TKeyValue, TValueType> GeneratedDictionary { get; private set; }

        public void Initiate()
        {
            GeneratedDictionary = new Dictionary<TKeyValue, TValueType>();

            foreach (var value in dictionaryValues)
            {
                if (value == null) continue;

                if (GeneratedDictionary.ContainsKey(value.Key))
                {
                    Debug.LogWarning($"Duplicated Key Values for key {value.Key}");
                    continue;
                }

                GeneratedDictionary.Add(value.Key, value.Value);
            }

            Initialized = true;
        }

        public bool TryGetValue(TKeyValue keyValue, out TValueType foundValue)
        {
            if (Initialized) return GeneratedDictionary.TryGetValue(keyValue, out foundValue);
            
            Debug.LogError($"Dictionary not initialized yet, returning default value for key: {keyValue}");
            foundValue = default;
            return false;
        }

        public bool ContainsKey(TKeyValue keyValue)
        {
            if (Initialized) return GeneratedDictionary.ContainsKey(keyValue);
            
            Debug.LogError($"Dictionary not initialized yet, returning default value for key: {keyValue}");
            return false;
        }  
    }
}