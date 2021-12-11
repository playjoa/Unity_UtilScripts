using UnityEngine;

namespace Utils.Tools
{
    public static class PlayerPrefsBool
    {
        public static void SetBool(string playerPrefID, bool valueToSet)
        {
            if (!valueToSet)
            {
                PlayerPrefs.SetInt(playerPrefID, 0);
                return;
            }

            PlayerPrefs.SetInt(playerPrefID, 1);
        }

        public static bool GetBool(string playerPrefID)
        {
            return PlayerPrefs_IntToBool(playerPrefID);
        }

        public static bool GetBool(string playerPrefID, bool startingValue)
        {
            if (PlayerPrefs.HasKey(playerPrefID)) return PlayerPrefs_IntToBool(playerPrefID);
            SetBool(playerPrefID, startingValue);
            return true;

        }

        static bool PlayerPrefs_IntToBool(string playerPrefID)
        {
            return PlayerPrefs.GetInt(playerPrefID) != 0;
        }
    }
}