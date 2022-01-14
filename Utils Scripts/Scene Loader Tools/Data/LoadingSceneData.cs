namespace Utils_Scripts.Loaders.Data
{
    public class LoadingSceneData
    {
        public string SceneId { get; }
        public LoadingSceneType LoadingSceneType { get; }

        public LoadingSceneData(string sceneId, LoadingSceneType loadingSceneType)
        {
            SceneId = sceneId;
            LoadingSceneType = loadingSceneType;
        }
    }
}