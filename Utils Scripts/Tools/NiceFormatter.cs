using UnityEngine;

namespace Utils.Tools
{
    public static class NiceFormatter
    {
        public static string NiceTimer(float timerCount)
        {
            var minutes = Mathf.FloorToInt(timerCount / 60f);
            var seconds = Mathf.FloorToInt(timerCount - minutes * 60);
            return $"{minutes:0}:{seconds:00}"; 
        }

        public static string FloatToPercentage(float progress)
        {
            return (progress * 100f).ToString("F2") + "% ";
        }
    }
}