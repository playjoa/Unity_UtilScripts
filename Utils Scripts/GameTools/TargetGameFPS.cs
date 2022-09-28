using UnityEngine;

namespace Utils.GameTools
{
    public class TargetGameFPS : MonoBehaviour
    {
        private void Start()
        {
            var nativeRefreshRate = Screen.currentResolution.refreshRate;
            
            Debug.Log($"Native Refresh Rate: {nativeRefreshRate}");
            Debug.Log($"Native Resolution Width: {Screen.currentResolution.width} Height: {Screen.currentResolution.height}");
            
            Application.targetFrameRate = nativeRefreshRate;
            
            Debug.Log($"Current Target: {Application.targetFrameRate}");
        }
    }
}