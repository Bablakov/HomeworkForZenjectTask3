using Scripts.SceneLoaderImport.Loader;

namespace Scripts.SceneLoaderImport.Loader
{
    public interface ILevelLoader 
    {
        void Load(LevelLoadingData levelLoadingData);
    }
}