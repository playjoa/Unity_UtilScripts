using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.Tools;
using Utils_Scripts.Loaders.Data;

namespace Utils.Loader.Controller
{
    public class SceneLoaderController : MonoBehaviour
    {
        public static SceneLoaderController ME { get; private set; }
        
        public string ProgressPercentage { get; private set; }
        public float Progress { get; private set; }
        public bool LoadingAScene { get; private set; }

        public delegate void SceneLoaderHandler(LoadingSceneData sceneData);

        public static SceneLoaderHandler OnStartedToLoadScene;
        public static SceneLoaderHandler OnSceneLoaded;

        private readonly List<string> scenesAvailable = new List<string>();
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
        
        public void LoadScene(string sceneToLoad, LoadingSceneType loadingSceneType = LoadingSceneType.Standard)
        {
            if(sceneToLoad == string.Empty || LoadingAScene) return;
            if (!scenesAvailable.Contains(sceneToLoad))
            {
                Debug.LogError($"Scene: {sceneToLoad} is not valid!");
                return;
            }

            ResetValues();
            LoadingAScene = true;
            StartCoroutine(LoadSceneASync(sceneToLoad, new LoadingSceneData(sceneToLoad, loadingSceneType)));
        }
        
        private IEnumerator LoadSceneASync(string targetScene, LoadingSceneData sceneData)
        {
            OnStartedToLoadScene?.Invoke(sceneData);
            yield return startUpDelay;

            var operation = SceneManager.LoadSceneAsync(targetScene);

            while (!operation.isDone)
            {
                var progress = ProgressClamped(operation.progress);

                ProgressPercentage = progress.FloatToPercentage();
                Progress = progress;
                yield return null;
            }

            LoadingAScene = false;
            OnSceneLoaded?.Invoke(sceneData);
        }
    }
}