using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.Loader.Controller;
using Utils.UI;

namespace Utils.Loader.Tools
{
    [RequireComponent(typeof(ButtonComponent))]
    public class GoToSceneButton : MonoBehaviour
    { 
        [Tooltip("Leave blank if you want to reload current scene!")]
        [Header("Scene Target")]
        [SerializeField] private string sceneTargetId;
        
        [Header("Button Config.")]
        [SerializeField] private ButtonComponent button;

        private void OnValidate() => button = GetComponent<ButtonComponent>();
        private bool ReloadCurrentScene => sceneTargetId.Equals(string.Empty);
        private string TargetScene => ReloadCurrentScene ? SceneManager.GetActiveScene().name : sceneTargetId;

        private void Awake() => button.onClick.AddListener(LoadScene);
        private void OnDestroy() => button.onClick.RemoveListener(LoadScene);
        private void LoadScene() => SceneLoaderController.ME.LoadScene(TargetScene);
    }
}
