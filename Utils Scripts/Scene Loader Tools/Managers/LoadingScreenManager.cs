using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.Loader.Controller;
using Utils.Loaders.Data;

namespace Utils.Loader.Managers
{
    public class LoadingScreenManager : MonoBehaviour
    {
        [Header("Loading Screen Reference:")]
        [SerializeField] private GameObject loadingScreen;
        
        [Header("Loading Scene Feedback Info:")]
        [SerializeField] private Image slLoadingBar;
        [SerializeField] private TextMeshProUGUI txtPercentage;

        private bool ShowingLoadingScreen => loadingScreen.activeSelf;
        private SceneLoaderController SceneLoader => SceneLoaderController.ME;
        
        private void Awake()
        {
            SceneLoaderController.OnStartedToLoadScene += StartedLoading;
            SceneLoaderController.OnSceneLoaded += FinishedLoading;
        }

        private void OnDestroy()
        {
            SceneLoaderController.OnStartedToLoadScene -= StartedLoading;
            SceneLoaderController.OnSceneLoaded -= FinishedLoading;
        }

        private void StartedLoading(LoadingSceneData sceneBeingLoaded)
        {
            loadingScreen.SetActive(true);
        }

        private void FinishedLoading(LoadingSceneData sceneLoaded)
        {
            loadingScreen.SetActive(false);
        }

        private void UpdateLoadingProgress()
        {
            if(!ShowingLoadingScreen) return;

            slLoadingBar.fillAmount = SceneLoader.Progress;
            txtPercentage.text = SceneLoader.ProgressPercentage;
        }

        private void LateUpdate()
        {
            UpdateLoadingProgress();
        }
    }
}