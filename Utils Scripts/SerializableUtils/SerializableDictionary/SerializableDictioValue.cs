using System;
using UnityEngine;

namespace Utils.SerializableUtils
{
    [Serializable]
    public class SerializableDictioValue<TValue, TType>
    {
        [Tooltip("Key Values Should Be Unique!")]
        [SerializeField] private TValue key;
        [SerializeField] private TType value;

        public TValue Key => key;
        public TType Value => value;
    }
}