using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.Tools;

namespace Utils.Loader.Controllers
{
    public class SceneLoaderController : MonoBehaviour
    {
        public static SceneLoaderController ME { get; private set; }
        
        public string ProgressPercentage { get; private set; }
        public float Progress { get; private set; }
        public bool LoadingAScene { get; private set; }

        public delegate void SceneLoaderHandler(string scene);

        public static SceneLoaderHandler OnStartedToLoadScene;
        public static SceneLoaderHandler OnSceneLoaded;

        private readonly List<string> scenesAvailable = new List<string>();
        private string targetSceneToLoad;
        private readonly WaitForSeconds startUpDelay = new WaitForSeconds(0.5f);
        
        private void Awake()
        {
            if (ME == null)
            {
                ME = this;
                DontDestroyOnLoad(this);
                GetAvailableScenes();
                return;
            }
            DestroyImmediate(this);
        }

        private void GetAvailableScenes()
        {
            for (var i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                var scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                var lastSlash = scenePath.LastIndexOf("/", StringComparison.Ordinal);
                scenesAvailable.Add(scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".", StringComparison.Ordinal) - lastSlash - 1));
            }
        }

        private float ProgressClamped(float progress) => Mathf.Clamp01(progress / .9f);

        private void ResetValues()
        {
            ProgressPercentage = "0%";
            Progress = 0f;
        }
        
        public void LoadScene(string sceneToLoad)
        {
            if(sceneToLoad == string.Empty || LoadingAScene) return;
            if (!scenesAvailable.Contains(sceneToLoad))
            {
                Debug.LogError($"Scene: {sceneToLoad} is not valid!");
                return;
            }

            ResetValues();
            targetSceneToLoad = sceneToLoad;
            LoadingAScene = true;
            StartCoroutine(LoadSceneASync(targetSceneToLoad));
        }
        
        private IEnumerator LoadSceneASync(string targetScene)
        {
            OnStartedToLoadScene?.Invoke(targetScene);
            yield return startUpDelay;

            var operation = SceneManager.LoadSceneAsync(targetScene);

            while (!operation.isDone)
            {
                var progress = ProgressClamped(operation.progress);

                ProgressPercentage = NiceFormatter.FloatToPercentage(progress);
                Progress = progress;
                yield return null;
            }

            LoadingAScene = false;
            OnSceneLoaded?.Invoke(targetScene);
        }
    }
}