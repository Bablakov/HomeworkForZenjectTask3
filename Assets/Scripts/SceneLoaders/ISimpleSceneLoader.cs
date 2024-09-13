using Scripts.Enums;

namespace Scripts.SceneLoaders
{
    public interface ISimpleSceneLoader
    {
        public void Load(SceneID sceneID);
    }
}