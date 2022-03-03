using UnityEngine;

namespace Utils.Extensions
{
    public static class PlayerPrefsExtension
    {
        private static bool PrefsIntToBool(string prefId) => PlayerPrefs.GetInt(prefId) != 0;
        
        public static void SetBool(string prefId, bool valueToSet)
        {
            PlayerPrefs.SetInt(prefId, valueToSet ? 1 : 0);
        }
        
        public static bool GetBool(string prefId, bool initialValue = false)
        {
            if (PlayerPrefs.HasKey(prefId)) return PrefsIntToBool(prefId);
            SetBool(prefId, initialValue);
            return true;
        }
        
        public static void IncInt(string prefId)
        {
            PlayerPrefs.SetInt(prefId, PlayerPrefs.GetInt(prefId) + 1);
        }
    }
}