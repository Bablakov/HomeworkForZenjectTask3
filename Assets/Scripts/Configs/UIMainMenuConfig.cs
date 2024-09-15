using Scripts.UI;
using UnityEngine;

namespace Scripts.Configs
{
    [CreateAssetMenu(fileName = "new UIMainMenuConfig", menuName = "Configs/UIMainMenuConfig")]
    public class UIMainMenuConfig : ScriptableObject
    {
        [field: SerializeField] public VictoryConditionSelectionPanel VictoryConditionSelectionPanel { get; private set; }
    }
}