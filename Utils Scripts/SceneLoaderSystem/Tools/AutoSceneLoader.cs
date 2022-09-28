using UnityEngine;
using Utils.SceneLoader.Controller;
using Utils.SceneLoader.Data;

namespace Utils.Loader.Tools
{
    public class AutoSceneLoader : MonoBehaviour
    {
        [Header("Scene Target")]
        [SerializeField] private GameScene targetGameScene;

        [Header("Load Configuration")] 
        [SerializeField] private LoadTrigger loadTrigger = LoadTrigger.AtStart;
        [SerializeField] private float loadDelayInSeconds = 0.5f;
        
        private void Awake()
        {
            if (AtTrigger(LoadTrigger.AtAwake))
                TriggerLoadDelayed();
        }

        private void OnEnable()
        {
            if (AtTrigger(LoadTrigger.AtEnable))
                TriggerLoadDelayed();
        }

        private void Start()
        {
            if (AtTrigger(LoadTrigger.AtStart))
                TriggerLoadDelayed();
        }

        private void TriggerLoadDelayed()
        {
            Invoke(nameof(LoadScene), loadDelayInSeconds);
        }

        public void LoadScene()
        {
            SceneLoaderController.ME.LoadScene(targetGameScene);
        }

        private bool AtTrigger(LoadTrigger targetTrigger)
        {
            return loadTrigger.Equals(targetTrigger);
        }
    }
}