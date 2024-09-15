using Scripts.UI;
using UnityEngine;

namespace Scripts.Configs
{
    [CreateAssetMenu(fileName = "new UIGameplayConfig", menuName = "Configs/UIGameplayConfig")]
    public class UIGameplayConfig : ScriptableObject
    {
        [field: SerializeField] public WinningPanel WinningPanel { get; private set; }
        [field: SerializeField] public DefeatPanel DefeatPanel { get; private set; }
    }
}