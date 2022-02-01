using System.Collections.Generic;

namespace Utils.Loaders.Data
{
    public static class LoadingScenes
    {
        private static readonly Dictionary<GameScene, string> GameScenes = new Dictionary<GameScene, string>()
        {
            {GameScene.StartUp, APPSTARTUP_SCENE},
            {GameScene.Main, MAIN_SCENE},
            {GameScene.TestScene, TEST_SCENE},
            {GameScene.Suburbs, SUBURBS_SCENE},
            {GameScene.Office, OFFICE_SCENE},
            {GameScene.Beach, BEACH_SCENE},
            {GameScene.Industries, INDUSTRIES_SCENE}
        };

        public static string GetSceneId(GameScene gameScene)
        {
            return GameScenes.TryGetValue(gameScene, out var sceneIdFound) ? sceneIdFound : string.Empty;
        }

        private const string APPSTARTUP_SCENE = "StartUp";
        private const string MAIN_SCENE = "Main";
        private const string TEST_SCENE = "TestScene";
        private const string SUBURBS_SCENE = "Suburbs";
        private const string OFFICE_SCENE = "Office";
        private const string BEACH_SCENE = "Beach";
        private const string INDUSTRIES_SCENE = "Industries";
    }

    public enum GameScene
    {
        None,
        ReloadCurrent,
        StartUp,
        Main,
        TestScene,
        Suburbs,
        Office,
        Beach,
        Industries
    }
}