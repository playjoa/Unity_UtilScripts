namespace Utils.Extensions
{
    public static class NumbersExtensions
    {
        public static int SecondsToMilliseconds(this int seconds) => seconds * 1000;
        
        public static string NiceCurrency(this int value) => value.ToString("N0");
        
        public static string FloatToPercentage(this float progress) => (progress * 100f).ToString("F2") + "%";
    }
}