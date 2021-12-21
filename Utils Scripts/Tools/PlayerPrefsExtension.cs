using UnityEngine;

namespace Utils.Tools
{
    public static class PlayerPrefsExtension
    {
        private static bool PlayerPrefs_IntToBool(string playerPrefID) => PlayerPrefs.GetInt(playerPrefID) != 0;
        
        public static void SetBool(string playerPrefID, bool valueToSet)
        {
            PlayerPrefs.SetInt(playerPrefID, valueToSet ? 1 : 0);
        }
        
        public static bool GetBool(string playerPrefID, bool initialValue = false)
        {
            if (PlayerPrefs.HasKey(playerPrefID)) return PlayerPrefs_IntToBool(playerPrefID);
            SetBool(playerPrefID, initialValue);
            return true;
        }
        
        public static void IncInt(string playerPrefID)
        {
            PlayerPrefs.SetInt(playerPrefID, PlayerPrefs.GetInt(playerPrefID) + 1);
        }
    }
}