namespace Utils.SceneLoader.Data
{
    public class LoadingSceneData
    {
        public GameScene GameScene { get; }
        public LoadingScreenType LoadingScreenType { get; }

        public LoadingSceneData(GameScene gameScene, LoadingScreenType loadingScreenType)
        {
            GameScene = gameScene;
            LoadingScreenType = loadingScreenType;
        }
    }
}