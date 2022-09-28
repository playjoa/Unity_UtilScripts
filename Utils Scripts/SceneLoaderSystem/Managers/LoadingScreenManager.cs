using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.SceneLoader.Controller;
using Utils.SceneLoader.Data;
using Utils.SceneLoader.Abstracts;

namespace Utils.SceneLoader.Managers
{
    public class LoadingScreenManager : SceneLoaderObject
    {
        [Header("Loading Screen Reference:")]
        [SerializeField] private GameObject loadingScreen;
        
        [Header("Loading Scene Feedback Info:")]
        [SerializeField] private Image slLoadingBar;
        [SerializeField] private TextMeshProUGUI txtPercentage;

        private bool ShowingLoadingScreen => loadingScreen.activeSelf;
        private static SceneLoaderController SceneLoader => SceneLoaderController.ME;

        protected override void OnStartedToLoadSceneHandler(LoadingSceneData loadingSceneData)
        {
            loadingScreen.SetActive(true);
        }

        protected override void OnSceneLoadedHandler(LoadingSceneData loadingSceneData)
        {
            loadingScreen.SetActive(false);
        }
        
        private void UpdateLoadingProgress()
        {
            if (!ShowingLoadingScreen) return;

            slLoadingBar.fillAmount = SceneLoader.Progress;
            txtPercentage.text = SceneLoader.ProgressPercentage;
        }

        private void LateUpdate()
        {
            UpdateLoadingProgress();
        }
    }
}