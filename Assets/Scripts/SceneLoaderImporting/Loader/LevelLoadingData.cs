using Scripts.VictoryCondition;

namespace Scripts.SceneLoaderImport.Loader
{
    public class LevelLoadingData
    {
        public LevelLoadingData(TypeCondition typeCondition)
            =>  Level = typeCondition;

        public TypeCondition Level { get; }
    }
}