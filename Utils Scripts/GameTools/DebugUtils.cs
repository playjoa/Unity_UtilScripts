using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Utils.Extensions;

namespace Utils.Tools
{
    public static class DebugUtils
    {
        public enum DebugType
        {
            Normal,
            Warning,
            Error
        }
        
        public static void DebugArray<T>(this T[] toLog, string description = null, DebugType debugType = DebugType.Normal)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("Log Array: ").Append(typeof(T).Name).Append(" (").Append(toLog.Length).Append(")");

            if (!string.IsNullOrEmpty(description))
                stringBuilder.Append(" - ").Append(description);

            stringBuilder.AddEnter();

            for (var i = 0; i < toLog.Length; i++)
            {
                stringBuilder.AddEnter();
                stringBuilder.Append("(").Append(i.ToString()).Append("): ").Append(toLog[i]);
            }

            stringBuilder.AddEnter();

            DebugWithType(stringBuilder.ToString(), debugType);
        }

        public static void DebugList<T>(this List<T> toLog, string description = null, DebugType debugType = DebugType.Normal)
        {
            var stringBuilder = new StringBuilder();

            var count = toLog.Count;
            stringBuilder.Append("Log List: ").Append(typeof(T).Name).Append(" (").Append(count).Append(")");

            if (!string.IsNullOrEmpty(description))
                stringBuilder.Append(" - ").Append(description);

            stringBuilder.AddEnter();

            for (var i = 0; i < count; i++)
            {
                stringBuilder.AddEnter();
                stringBuilder.Append("(").Append(i.ToString()).Append("): ").Append(toLog[i]);
            }

            stringBuilder.AddEnter();

            DebugWithType(stringBuilder.ToString(), debugType);
        }

        public static void DebugKeys<TKey, TValue>(this Dictionary<TKey, TValue> toLog, string description = null, DebugType debugType = DebugType.Normal)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("Log Dictionary Keys: ").Append(typeof(TKey).Name).Append(" (").Append(toLog.Count)
                .Append(")");

            if (!string.IsNullOrEmpty(description))
                stringBuilder.Append(" - ").Append(description);

            stringBuilder.AddEnter();

            var index = 0;
            foreach (var keyValuePair in toLog)
            {
                stringBuilder.AddEnter();
                stringBuilder.Append("(").Append(index).Append("): ").Append(keyValuePair.Key);
                index++;
            }

            stringBuilder.AddEnter();

            DebugWithType(stringBuilder.ToString(), debugType);
        }

        public static void DebugValues<TKey, TValue>(this Dictionary<TKey, TValue> toLog, string description = null, DebugType debugType = DebugType.Normal)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("Log Dictionary Keys: ").Append(typeof(TKey).Name).Append(" (").Append(toLog.Count).Append(")");

            if (!string.IsNullOrEmpty(description))
                stringBuilder.Append(" - ").Append(description);

            stringBuilder.AddEnter();

            var index = 0;
            foreach (var keyValuePair in toLog)
            {
                stringBuilder.AddEnter();
                stringBuilder.Append("(").Append(index).Append("): ")
                    .Append("Key: ").Append(keyValuePair.Key)
                    .Append(" - ").Append(keyValuePair.Value);
                index++;
            }

            stringBuilder.AddEnter();

            DebugWithType(stringBuilder.ToString(), debugType);
        }
        
        private static void DebugWithType(string info, DebugType debugType)
        {
            switch (debugType)
            {
                case DebugType.Normal:
                    Debug.Log(info);
                    break;
                case DebugType.Warning:
                    Debug.LogWarning(info);
                    break;
                case DebugType.Error:
                    Debug.LogError(info);
                    break;
                default:
                    Debug.Log(info);
                    break;
            }
        }
    }
}