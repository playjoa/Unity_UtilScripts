namespace Utils.Loaders.Data
{
    public class LoadingSceneData
    {
        public GameScene GameScene { get; }
        public LoadingSceneType LoadingSceneType { get; }

        public LoadingSceneData(GameScene gameScene, LoadingSceneType loadingSceneType)
        {
            GameScene = gameScene;
            LoadingSceneType = loadingSceneType;
        }
    }
}