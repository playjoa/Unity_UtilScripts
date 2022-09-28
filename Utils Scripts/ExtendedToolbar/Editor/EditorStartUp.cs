using UnityEditor;
using UnityEditor.SceneManagement;

namespace Utils.EditorTools
{
    public static class EditorStartUp
    {
        private const string StartUpScenePath = "Assets/Scenes/StartUp.unity";
        private const string TestEnvironmentScenePath = "Assets/Scenes/Test.unity";
        private const string MainScenePath = "Assets/Scenes/Main.unity";
        
        public const string PlayFromStartUpInfo = "DevTools/Navigate/Play-Stop From StartUp";
        public const string OpenTestEnvironmentInfo = "DevTools/Navigate/Open Test Scene";
        public const string OpenMainSceneInfo = "DevTools/Navigate/Open Main Scene";

        [MenuItem(PlayFromStartUpInfo)]
        public static void PlayFromStartUp()
        {
            if (EditorApplication.isPlaying)
            {
                EditorApplication.isPlaying = false;
                return;
            }

            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene(StartUpScenePath);
            EditorApplication.isPlaying = true;
        }
        
        [MenuItem(OpenTestEnvironmentInfo)]
        public static void OpenTestEnvironment()
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene(TestEnvironmentScenePath);
        }
        
        [MenuItem(OpenMainSceneInfo)]
        public static void OpenMainScene()
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene(MainScenePath);
        }
    }
}

