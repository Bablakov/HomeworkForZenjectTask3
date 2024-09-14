using Scripts.UI;
using UnityEngine;

namespace Scripts.Configs
{
    [CreateAssetMenu(fileName = "new UIConfig", menuName = "Configs/UIConfig")]
    public class UIConfig : ScriptableObject
    {
        [field: SerializeField] public WinningPanel WinningPanel { get; private set; }
        [field: SerializeField] public DefeatPanel DefeatPanel { get; private set; }
    }
}