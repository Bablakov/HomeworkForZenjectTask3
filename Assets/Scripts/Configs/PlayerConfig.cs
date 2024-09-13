using Scripts.Players;
using UnityEngine;

namespace Scripts.Configs
{
    [CreateAssetMenu(fileName = "new PlayerConfig", menuName = "Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public Player Player { get; private set; }
        [field: SerializeField] public PlayerSpecificationsConfig PlayerSpecificationsConfig { get; private set; }
    }
}