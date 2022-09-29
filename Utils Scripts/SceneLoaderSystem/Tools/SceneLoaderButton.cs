using UnityEngine;
using UnityEngine.UI;
using Utils.SceneLoader.Controller;
using Utils.SceneLoader.Data;

namespace Utils.Loader.Tools
{
    [RequireComponent(typeof(Button))]
    public class SceneLoaderButton : MonoBehaviour
    {
        [Header("Scene Target")]
        [SerializeField] private GameScene targetGameScene;
        
        [Header("Button Config.")]
        [SerializeField] private Button button;

        private void OnValidate() => button = GetComponent<Button>();
        private void Awake() => button.onClick.AddListener(LoadScene);
        private void OnDestroy() => button.onClick.RemoveListener(LoadScene);
        private void LoadScene() => SceneLoaderController.ME.LoadScene(targetGameScene);
    }
}
