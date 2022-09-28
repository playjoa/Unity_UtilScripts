using System.Collections.Generic;

namespace Utils.SceneLoader.Data
{
    public static class LoadingScenes
    {
        private static readonly Dictionary<GameScene, string> GameScenes = new Dictionary<GameScene, string>()
        {
            {GameScene.StartUp, APPSTARTUP_SCENE},
            {GameScene.Main, MAIN_SCENE},
            {GameScene.TestScene, TEST_SCENE},
        };

        public static string GetSceneId(GameScene gameScene)
        {
            return GameScenes.TryGetValue(gameScene, out var sceneIdFound) ? sceneIdFound : string.Empty;
        }

        private const string APPSTARTUP_SCENE = "StartUp";
        private const string MAIN_SCENE = "Main";
        private const string TEST_SCENE = "Test";
    }

    public enum GameScene
    {
        Undefined,
        ReloadCurrent,
        StartUp,
        Main,
        TestScene
    }
}