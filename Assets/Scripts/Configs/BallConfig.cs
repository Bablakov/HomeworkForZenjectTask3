using Scripts.Balls;
using Scripts.Enums;
using UnityEngine;

namespace Scripts.Configs
{
    [CreateAssetMenu(fileName = "new BallConfig", menuName = "Configs/BallConfig")]
    public class BallConfig : ScriptableObject
    {
        [field: SerializeField] public Ball Ball { get; private set; }
        public BallColor BallColor => Ball.BallColor;
    }
}