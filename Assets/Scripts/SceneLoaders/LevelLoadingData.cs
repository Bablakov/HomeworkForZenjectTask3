using Scripts.Enums;

namespace Scripts.SceneLoaders
{
    public class LevelLoadingData
    {
        public LevelLoadingData(TypeCondition typeCondition)
            =>  Level = typeCondition;

        public TypeCondition Level { get; }
    }
}