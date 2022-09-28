using UnityEngine;
using Utils.SceneLoader.Controller;
using Utils.SceneLoader.Data;

namespace Utils.SceneLoader.Abstracts
{
    public abstract class SceneLoaderObject : MonoBehaviour
    {
        protected virtual void Awake()
        {
            SceneLoaderController.OnStartedToLoadScene += OnStartedToLoadSceneHandler;
            SceneLoaderController.OnSceneLoaded += OnSceneLoadedHandler;
        }
        
        protected virtual void OnDestroy()
        {
            SceneLoaderController.OnStartedToLoadScene -= OnStartedToLoadSceneHandler;
            SceneLoaderController.OnSceneLoaded -= OnSceneLoadedHandler;
        }

        protected virtual void OnStartedToLoadSceneHandler(LoadingSceneData loadingSceneData)
        {
        }
        
        protected virtual void OnSceneLoadedHandler(LoadingSceneData loadingSceneData)
        {
        }
    }
}