using UnityEngine;
using Utils.Loader.Controller;
using Utils.Loaders.Data;
using Utils.UI;

namespace Utils.Loader.Tools
{
    [RequireComponent(typeof(ButtonComponent))]
    public class GoToSceneButton : MonoBehaviour
    {
        [Header("Scene Target")]
        [SerializeField] private GameScene targetGameScene;
        
        [Header("Button Config.")]
        [SerializeField] private ButtonComponent button;

        private void OnValidate() => button = GetComponent<ButtonComponent>();
        private void Awake() => button.onClick.AddListener(LoadScene);
        private void OnDestroy() => button.onClick.RemoveListener(LoadScene);
        private void LoadScene() => SceneLoaderController.ME.LoadScene(targetGameScene);
    }
}
