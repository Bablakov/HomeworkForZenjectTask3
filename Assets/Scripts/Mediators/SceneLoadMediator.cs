using Scripts.Enums;

namespace Scripts.SceneLoaders
{
    public class SceneLoadMediator
    {
        private ISimpleSceneLoader _simpleSceneLoader;
        private ILevelLoader _levelLoader;

        public SceneLoadMediator(ISimpleSceneLoader simpleSceneLoader, ILevelLoader levelLoader)
        {
            _simpleSceneLoader = simpleSceneLoader;
            _levelLoader = levelLoader;
        }

        public void GoToGameplayLevel(LevelLoadingData levelLoadingData)
            => _levelLoader.Load(levelLoadingData);

        public void GoToMainMenu()
            => _simpleSceneLoader.Load(SceneID.MainMenu);
    }
}